using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using GraphCalculator.Model;
using GraphCalculator.View;

namespace GraphCalculator.Controller
{
    class CartesianFieldController
    {
        private readonly CartesianField Field;
        private readonly Parser Parser;
        private readonly CartesianFieldRenderer Renderer;

        readonly List<Variable> PendingVariables;

        public event EventHandler<Variable> NewVariableAdded;
        public event EventHandler<Variable> VariableUpdated;
        public event EventHandler<Variable> VariableRemoved;

        public event EventHandler<PostfixFunction> NewFunctionAdded;
        public event EventHandler<PostfixFunction> FunctionUpdated;
        public event EventHandler<PostfixFunction> FunctionRemoved;

        public event EventHandler<FunctionGraph> NewGraphAdded;
        public event EventHandler<FunctionGraph> GraphUpdated;
        public event EventHandler<FunctionGraph> GraphRemoved;

        public CartesianFieldController(CartesianField field, CartesianFieldRenderer renderer)
        {
            Field = field;
            Parser = new Parser(Field);
            Renderer = renderer;
            PendingVariables = new List<Variable>();
        }

        public PostfixFunction CreateFunction(string infixEquation)
        {
            string[] argumentNames = new string[] { "x" };
            ParseResult result = Parser.TryConvertToPostfix(infixEquation, argumentNames, out string postfix);
            PostfixFunction function = new PostfixFunction(postfix, argumentNames, Field.Variables);
            function.IsValid = (result == ParseResult.OK);
            AddFunction(function);
            return function;
        }

        public void AddFunction(PostfixFunction function)
        {
            Field.AddFunction(function);
            NewFunctionAdded?.Invoke(this, function);
        }

        public void EditFunction(PostfixFunction function, string newInfixEquation, out ParseResult result)
        {
            result = Parser.TryConvertToPostfix(newInfixEquation, function.ArgumentNames, out string postfix);
            function.Equation = postfix;
            function.IsValid = (result == ParseResult.OK);
            FunctionUpdated?.Invoke(this, function);
        }

        public void RemoveFunction(PostfixFunction function)
        {
            Field.RemoveFunction(function);
            FunctionRemoved?.Invoke(this, function);
        }

        public FunctionGraph CreateGraph(PostfixFunction baseFunction)
        {
            FunctionGraph graph = new FunctionGraph(baseFunction, Color.Red, 1);
            AddGraph(graph);
            return graph;
        }

        public void AddGraph(FunctionGraph graph)
        {
            Field.AddGraph(graph);
            NewGraphAdded?.Invoke(this, graph);
        }

        public void EditGraph(FunctionGraph graph, Color newColor, float newWidth)
        {
            graph.Color = newColor;
            graph.Width = newWidth;
            GraphUpdated?.Invoke(this, graph);
        }

        public void EnableGraph(FunctionGraph graph)
        {
            graph.Enabled = true;
            GraphUpdated?.Invoke(this, graph);
        }

        public void DisableGraph(FunctionGraph graph)
        {
            graph.Enabled = false;
            GraphUpdated?.Invoke(this, graph);
        }

        public void RemoveGraph(FunctionGraph graph)
        {
            Field.RemoveGraph(graph);
            GraphRemoved?.Invoke(this, graph);
        }

        public void EditVariable(Variable variable, string newName, double newValue)
        {
            variable.Name = newName;
            variable.Value = newValue;
            if (PendingVariables.Contains(variable))
            {
                if (IsVariableValid(variable))
                {
                    PendingVariables.Remove(variable);
                    Field.AddVariable(variable);
                }
            }
            else
            {
                if (!IsVariableValid(variable))
                {
                    Field.RemoveVariable(variable);
                    PendingVariables.Add(variable);
                }
            }
            VariableUpdated?.Invoke(this, variable);
        }

        public bool IsVariableValid(Variable variable)
        {
            if (!variable.IsValid) return false;
            foreach (Variable registeredVariable in Field.Variables)
            {
                if (registeredVariable != variable && registeredVariable.Name == variable.Name)
                {
                    return false;
                }
            }
            return true;
        }

        public Variable CreateVariable(string name)
        {
            Variable variable = new Variable(name);
            TryAddVariable(variable);
            return variable;
        }

        public void TryAddVariable(Variable variable)
        {
            if (IsVariableValid(variable))
            {
                PendingVariables.Remove(variable);
                Field.AddVariable(variable);
            }
            else
            {
                PendingVariables.Add(variable);
                //throw new Exception("Variable is not valid.");
            }
            NewVariableAdded?.Invoke(this, variable);
        }

        public void DeleteVariable(Variable variable)
        {
            if (PendingVariables.Contains(variable))
            {
                PendingVariables.Remove(variable);
            }
            else
            {
                Field.RemoveVariable(variable);
            }
            VariableRemoved?.Invoke(this, variable);
        }
    }
}
