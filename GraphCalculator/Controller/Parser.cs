using System;
using System.Collections.Generic;
using GraphCalculator.Model;
using System.Linq;
using static GraphCalculator.Model.PostfixFunction;
using System.Collections.ObjectModel;

namespace GraphCalculator.Controller
{
    enum ParseResult
    {
        OK, MismatchedBrackets, UnknownToken, EquationIsEmpty, MismatchedOperators
    }

    class Parser
    {
        public readonly ReadOnlyCollection<Variable> Variables;

        public string[] Tokenize(string infixEquation)
        {
            string[] tokens = infixEquation.Split(' ');
            return tokens;
        }

        public ParseResult TryConvertToPostfix(string infixEquation, string[] argumentNames, out string postfix)
        {
            postfix = string.Empty;
            Stack<string> tokenStack = new Stack<string>();
            Stack<string> operatorStack = new Stack<string>();

            string[] tokens = Tokenize(infixEquation);

            int literalCount = 0;
            int operatorArgumentCount = 1;
            foreach (string token in tokens)
            {
                if (string.IsNullOrEmpty(token)) continue;

                if (IsLiteral(token, out double literal) || IsVariable(token, Variables, out double value) || IsArgument(token, argumentNames, out int argIndex))
                {
                    tokenStack.Push(token);
                    literalCount++;
                }
                else if (IsFunction(token))
                {
                    operatorStack.Push(token);
                }
                else if (IsOperator(token, out int priority, out bool leftAssociative))
                {
                    while (operatorStack.Count > 0 && ((IsFunction(operatorStack.Peek()) ||
                        (IsOperator(operatorStack.Peek(), out int lastPriority, out bool lastLeftAssociative) &&
                        ((lastPriority > priority) || (lastPriority == priority && lastLeftAssociative))
                        ))))
                    {
                        tokenStack.Push(operatorStack.Pop());
                    }
                    operatorStack.Push(token);
                }
                else if (IsLeftBracket(token))
                {
                    operatorStack.Push(token);
                }
                else if (IsRightBracket(token))
                {
                    string lastOperator;
                    do
                    {
                        if (operatorStack.Count == 0)
                        {
                            return ParseResult.MismatchedBrackets;
                        }

                        lastOperator = operatorStack.Pop();
                        if (!IsLeftBracket(lastOperator))
                        {
                            tokenStack.Push(lastOperator);
                        }
                    }
                    while (!IsLeftBracket(lastOperator));
                }
                else
                {
                    return ParseResult.UnknownToken;
                }
                if (IsBinary(token)) operatorArgumentCount++;
            }
            if (literalCount == 0)
            {
                return ParseResult.EquationIsEmpty;
            }

            if (literalCount != operatorArgumentCount)
            {
                return ParseResult.MismatchedOperators;
            }

            while (operatorStack.Count > 0)
            {
                string token = operatorStack.Pop();
                if (IsLeftBracket(token) || IsRightBracket(token))
                {
                    return ParseResult.MismatchedBrackets;
                }

                tokenStack.Push(token);
            }
            postfix = string.Join(" ", tokenStack.Reverse());
            return ParseResult.OK;
        }

        public Parser(CartesianField field)
        {
            Variables = field.Variables;
        }
    }
}
