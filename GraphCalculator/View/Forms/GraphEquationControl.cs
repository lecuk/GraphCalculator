using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphCalculator.Model;
using GraphCalculator.Controller;
using System.Collections.ObjectModel;
using System.Text.RegularExpressions;

namespace GraphCalculator.View.Forms
{
    partial class GraphEquationControl : UserControl
    {
        readonly CartesianFieldController Controller;
        private FunctionGraph Graph { get; set; }
        PostfixFunction Function
        {
            get
            {
                return Graph.Function;
            }
        }

        public GraphEquationControl(CartesianFieldController controller, FunctionGraph graph)
        {
            InitializeComponent();
            Controller = controller;
            Graph = graph;
            Controller.EnableGraph(Graph);
            EnabledCheckBox.Checked = true;
            InvalidateFunction();
        }
        public static string ToFriendlyCase(string PascalString)
        {
            return Regex.Replace(PascalString, "([A-Z])", " ");
        }

        void OnParseFailed(object sender, ParseResult result)
        {
            ErrorLabel.Text = $"(!) {ToFriendlyCase(result.ToString())}";
            
            ErrorLabel.Visible = true;
        }

        void OnParseSuccessful(object sender, EventArgs e)
        {
            ErrorLabel.Visible = false;
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Controller.RemoveGraph(Graph);
        }

        private void OptionsButton_Click(object sender, EventArgs e)
        {
            GraphOptionsForm form = new GraphOptionsForm(Graph);
            if (form.ShowDialog(FindForm()) == DialogResult.OK)
            {
                Controller.EditGraph(Graph, form.Graph.Color, form.Graph.Width);
            }
        }

        public ParseResult InvalidateFunction()
        {
            Controller.EditFunction(Function, EquationTextBox.Text, out ParseResult result);
            PostfixTextBox.Text = Function.Equation;
            if (result != ParseResult.OK)
            {
                ErrorLabel.Visible = true;
                ErrorLabel.Text = result.ToString();
            }
            else
            {
                ErrorLabel.Visible = false;
            }
            return result;
        }

        private void EquationTextBox_TextChanged(object sender, EventArgs e)
        {
            InvalidateFunction();
        }

        private void EnabledCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (EnabledCheckBox.Checked)
            {
                Controller.EnableGraph(Graph);
            }
            else
            {
                Controller.DisableGraph(Graph);
            }
        }
    }
}
