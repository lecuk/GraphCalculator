using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace GraphCalculator.Model
{
    class CartesianField
    {
        readonly List<PostfixFunction> functions;
        readonly List<FunctionGraph> graphs;
        readonly List<Variable> variables;

        public ReadOnlyCollection<PostfixFunction> Functions;
        public ReadOnlyCollection<FunctionGraph> Graphs;
        public ReadOnlyCollection<Variable> Variables;

        public void AddFunction(PostfixFunction function)
        {
            functions.Add(function);
        }

        public void RemoveFunction(PostfixFunction function)
        {
            functions.Remove(function);
        }

        public void AddGraph(FunctionGraph graph)
        {
            graphs.Add(graph);
        }

        public void RemoveGraph(FunctionGraph graph)
        {
            graphs.Remove(graph);
        }

        public void AddVariable(Variable variable)
        {
            variables.Add(variable);
        }

        public void RemoveVariable(Variable variable)
        {
            variables.Remove(variable);
        }

        public CartesianField()
        {
            functions = new List<PostfixFunction>();
            graphs = new List<FunctionGraph>();
            variables = new List<Variable>();

            Functions = new ReadOnlyCollection<PostfixFunction>(functions);
            Graphs = new ReadOnlyCollection<FunctionGraph>(graphs);
            Variables = new ReadOnlyCollection<Variable>(variables);
        }
    }
}
