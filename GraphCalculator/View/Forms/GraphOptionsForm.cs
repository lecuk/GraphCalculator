using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphCalculator.Model;
using GraphCalculator.Controller;

namespace GraphCalculator.View.Forms
{
    partial class GraphOptionsForm : Form
    {
        readonly CartesianField TestField;
        readonly CartesianFieldController Controller;
        readonly CartesianFieldRenderer Renderer;

        public readonly FunctionGraph Graph;
        readonly Variable K;

        public GraphOptionsForm(FunctionGraph graph)
        {
            InitializeComponent();
            TestField = new CartesianField();
            Renderer = new CartesianFieldRenderer(TestField, GraphWindow);
            Controller = new CartesianFieldController(TestField, Renderer);
            K = Controller.CreateVariable("k");
            Graph = Controller.CreateGraph(Controller.CreateFunction("sin ( x + k )"));
            WidthTrackBar.Value = (int)(Graph.Width * 10);
            WidthLabel.Text = "Width: " + Graph.Width.ToString();
            Controller.EnableGraph(Graph);
            GraphWindow.FieldRenderer = Renderer;
            GraphWindow.SetCameraBounds(new RectangleD(new Vector2(-5, -2), new Vector2(10, 4)));
            GraphWindow.OnUpdate += OnGraphUpdate;
            GraphWindow.Run(24);
        }

        private void OnGraphUpdate(object sender, EventArgs e)
        {
            Controller.EditVariable(K, K.Name, K.Value + 0.1);
        }

        private void WidthTrackBar_Scroll(object sender, EventArgs e)
        {
            Graph.Width = WidthTrackBar.Value / 10.0f;
            WidthLabel.Text = "Width: " + Graph.Width.ToString();
        }

        private void ColorDialogButton_Click(object sender, EventArgs e)
        {
            if (CurveColorDialog.ShowDialog(FindForm()) == DialogResult.OK)
            {
                Graph.Color = CurveColorDialog.Color;
            }
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.No;
            Close();
        }

        private void GraphOptionsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GraphWindow.Stop();
        }
    }
}
