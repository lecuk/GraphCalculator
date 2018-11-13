using System;
using System.Collections.Generic;
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
    public partial class MainForm : Form
    {
        readonly CartesianField Field;
        readonly CartesianFieldRenderer Renderer;
        readonly CartesianFieldController Controller;

        public MainForm()
        {
            InitializeComponent();

            Field = new CartesianField();
            Renderer = new CartesianFieldRenderer(Field, GraphWindow);
            Controller = new CartesianFieldController(Field, Renderer);

            MainGraphListControl.Controller = Controller;
            GraphWindow.FieldRenderer = Renderer;
            GraphWindow.CanBeControlled = true;
            GraphWindow.Run(40);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GraphWindow.Stop();
        }
    }
}
