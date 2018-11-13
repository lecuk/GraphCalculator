using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GraphCalculator.Model
{
    class PostfixFunction
    {
        public static readonly string[] DEFAULT_FUNCTIONS = new string[] { "sin", "cos", "tg", "ctg", "log", "abs", "sqrt", "ln", "nroot", "pow", "exp" };
        public static readonly string[] OPERATORS = new string[] { "+-", "*/%", "^", "!"};
        public const string RIGHT_ASSOCIATIVE_OPERATORS = "^";

        public static readonly string[] UNARY = new string[] { "!", "sin", "cos", "tg", "ctg", "abs", "ln", "sqrt", "exp" };
        public static readonly string[] BINARY = new string[] { "+", "-", "*", "/", "%", "^", "log", "nroot", "pow" };

        public readonly string[] ArgumentNames;
        public readonly ReadOnlyCollection<Variable> Variables;
        
        private string equation;
        public string Equation
        {
            get
            {
                return equation;
            }

            set
            {
                equation = value;
                EquationTokens = value.Split(' ');
            }
        }
        public string[] EquationTokens { get; private set; }

        public bool IsValid { get; set; }

        public event EventHandler EvaluationSuccessful;
        public event EventHandler EvaluationFailed;
        
        string PrintStack<T>(Stack<T> stack)
        {
            return string.Join(", ", stack.Reverse());
        }

        public double Evaluate(params double[] arguments)
        {
            if (!IsValid)
            {
                EvaluationFailed?.Invoke(this, new EventArgs());
                return double.NaN;
            }

            if (arguments.Length != ArgumentNames.Length)
            {
                EvaluationFailed?.Invoke(this, new EventArgs());
                return double.NaN;
            }

            Stack<double> values = new Stack<double>();
            foreach (string token in EquationTokens)
            {
                double tokenValue;
                if (IsLiteral(token, out tokenValue) || IsVariable(token, Variables, out tokenValue))
                {
                    values.Push(tokenValue);
                    //Console.WriteLine($"Number loaded into stack: {token}.");
                }
                else if (IsArgument(token, ArgumentNames, out int index))
                {
                    values.Push(arguments[index]);
                    //Console.WriteLine($"Argument loaded into stack: {token}.");
                }
                else if (IsFunction(token) || IsOperator(token, out int priority, out bool leftAssociative))
                {
                    if (IsUnary(token))
                    {
                        if (values.Count > 0)
                        {
                            double a = values.Pop();
                            double result = EvaluateUnaryToken(token, a);
                            values.Push(result);
                            //Console.WriteLine($"Operation: {token}, Param1 = {a}, Result = {result}");
                        }
                    }
                    else if (IsBinary(token))
                    {
                        //swapped A and B because it's stack popping
                        if (values.Count > 1)
                        {
                            double b = values.Pop();
                            double a = values.Pop();
                            double result = EvaluateBinaryToken(token, a, b);
                            values.Push(result);
                            //Console.WriteLine($"Operation: {token}, Param1 = {a}, Param2 = {b}, Result = {result}");
                        }
                    }
                }
                //Console.WriteLine($"Stack: {printStack(values)}");
            }
            if (values.Count != 1)
            {
                EvaluationFailed?.Invoke(this, new EventArgs());
                return double.NaN;
            }
            return values.Single();
        }

        public Curve PlotFunction(double a, double b)
        {
            double[] arguments = MathPlus.Interpolate(a, b, 300);
            Vector2[] nodes = new Vector2[arguments.Length];

            for (int i = 0; i < arguments.Length; i++)
            {
                double x = arguments[i];
                double y = Evaluate(x);
                Vector2 node = new Vector2(x, y);
                nodes[i] = node;
            }

            return new Curve(nodes);
        }

        public static double EvaluateUnaryToken(string token, double a)
        {
            switch(token)
            {
                case "!": return MathPlus.Factorial(a);
                case "sin": return Math.Sin(a);
                case "cos": return Math.Cos(a);
                case "tg": return Math.Tan(a);
                case "ctg": return 1.0 / Math.Tan(a);
                case "abs": return Math.Abs(a);
                case "ln": return Math.Log(a);
                case "sqrt": return Math.Sqrt(a);
                case "exp": return Math.Exp(a);
                default: throw new Exception("Unknown function/operator name.");
            }
        }

        public static double EvaluateBinaryToken(string token, double a, double b)
        {
            switch (token)
            {
                case "+": return a + b;
                case "-": return a - b;
                case "*": return a * b;
                case "/": return a / b;
                case "%": return a % b;
                case "^": return Math.Pow(a, b);
                case "pow": return Math.Pow(a, b);
                case "log": return Math.Log(b, a);
                case "nroot": return Math.Pow(a, 1 / b);
                default: throw new Exception("Unknown function/operator name.");
            }
        }

        public static bool IsLiteral(string token, out double result)
        {
            return double.TryParse(token, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.CultureInfo.InvariantCulture, out result);
        }

        public static bool IsArgument(string token, string[] argNames, out int argIndex)
        {
            for (int i = 0; i < argNames.Length; i++)
            {
                if (token == argNames[i])
                {
                    argIndex = i;
                    return true;
                }
            }
            argIndex = -1;
            return false;
        }

        public static bool IsVariable(string token, IEnumerable<Variable> variables, out double value)
        {
            foreach (Variable variable in variables)
            {
                if (variable.Name == token)
                {
                    value = variable.Value;
                    return true;
                }
            }
            value = double.NaN;
            return false;
        }

        public static bool IsFunction(string token)
        {
            return DEFAULT_FUNCTIONS.Contains(token);
        }

        public static bool IsOperator(string token, out int priority, out bool leftAssociative)
        {
            int rank = 0;
            foreach (string sameRankOperators in OPERATORS)
            {
                if (sameRankOperators.Contains(token))
                {
                    priority = rank;
                    leftAssociative = !RIGHT_ASSOCIATIVE_OPERATORS.Contains(token);
                    return true;
                }
                rank++;
            }
            priority = -1;
            leftAssociative = false;
            return false;
        }

        public static bool IsLeftBracket(string token)
        {
            return (token == "(");
        }

        public static bool IsRightBracket(string token)
        {
            return (token == ")");
        }

        public static bool IsUnary(string token)
        {
            return UNARY.Contains(token);
        }

        public static bool IsBinary(string token)
        {
            return BINARY.Contains(token);
        }

        public PostfixFunction(string postfixEquation, IEnumerable<string> argumentNames, ReadOnlyCollection<Variable> variables)
        {
            IsValid = false;
            Equation = postfixEquation;

            if (variables != null)
            {
                Variables = variables;
            }
            else
            {
                Variables = new ReadOnlyCollection<Variable>(new List<Variable>(0));
            }

            ArgumentNames = argumentNames.ToArray();
        }

        public PostfixFunction(string postfixEquation, IEnumerable<string> argumentNames) : this(postfixEquation, argumentNames, null) { }
    }
}
