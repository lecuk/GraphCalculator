using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphCalculator.Controller;
using GraphCalculator.Model;

namespace GraphCalculator.View.Forms
{
    partial class GraphListControl : UserControl
    {

        private readonly Dictionary<Variable, VariableControl> VariableControls;
        //private readonly ControlCollection FunctionControls;
        private readonly Dictionary<FunctionGraph, GraphEquationControl> GraphControls;

        private CartesianFieldController controller;
        public CartesianFieldController Controller
        {
            get
            {
                return controller;
            }
            set
            {
                controller = value;

                controller.NewFunctionAdded += OnAddFunction;
                controller.FunctionUpdated += OnFunctionUpdated;
                controller.FunctionRemoved += OnRemoveFunction;

                controller.NewGraphAdded += OnNewGraphAdded;
                controller.GraphUpdated += OnGraphUpdated;
                controller.GraphRemoved += OnGraphRemoved;

                controller.NewVariableAdded += OnNewVariableAdded;
                controller.VariableUpdated += OnVariableUpdated;
                controller.VariableRemoved += OnVariableRemoved;
            }
        }

        public GraphListControl()
        {
            VariableControls = new Dictionary<Variable, VariableControl>();
            //FunctionControls = new ControlCollection(this);
            GraphControls = new Dictionary<FunctionGraph, GraphEquationControl>();
            InitializeComponent();
        }

        private void OnNewVariableAdded(object sender, Variable variable)
        {
            var control = new VariableControl(controller, variable);
            GraphsFlowLayoutPanel.Controls.Add(control);
            VariableControls.Add(variable, control);
            control.Show();
        }

        private void OnVariableUpdated(object sender, Variable e)
        {
            UpdateVariableLists();
        }

        void UpdateVariableLists()
        {
            foreach (GraphEquationControl control in GraphControls.Values)
            {
                control.InvalidateFunction();
            }
        }

        private void OnVariableRemoved(object sender, Variable variable)
        {
            foreach (GraphEquationControl eControl in GraphControls.Values)
            {
                eControl.InvalidateFunction();
            }
            var control = VariableControls[variable];
            GraphsFlowLayoutPanel.Controls.Remove(control);
            control.Dispose();
        }

        private void OnNewGraphAdded(object sender, FunctionGraph e)
        {
            GraphEquationControl control = new GraphEquationControl(controller, e);
            GraphControls.Add(e, control);
            GraphsFlowLayoutPanel.Controls.Add(control);
            control.Show();
        }

        private void OnGraphUpdated(object sender, FunctionGraph e)
        {
        }

        private void OnGraphRemoved(object sender, FunctionGraph e)
        {
            var control = GraphControls[e];
            GraphsFlowLayoutPanel.Controls.Remove(control);
            GraphControls.Remove(e);
            control.Dispose();
        }

        private void OnFunctionUpdated(object sender, PostfixFunction e)
        {
        }

        private void AddFunctionButton_Click(object sender, EventArgs e)
        {
            //Controller.CreateFunction("x");
        }

        void OnAddFunction(object sender, PostfixFunction function)
        {
        }

        private void AddGraphButton_Click(object sender, EventArgs e)
        {
            Controller.CreateGraph(Controller.CreateFunction(""));
        }

        private void OnRemoveFunction(object sender, PostfixFunction function)
        {
        }

        private void AddVariableButton_Click(object sender, EventArgs e)
        {
            Controller.CreateVariable("");
        }
    }
}
