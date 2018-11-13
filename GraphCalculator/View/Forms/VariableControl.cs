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

namespace GraphCalculator.View.Forms
{
    partial class VariableControl : UserControl
    {
        readonly CartesianFieldController Controller;

        readonly Variable Variable;
        
        public VariableControl(CartesianFieldController controller, Variable variable)
        {
            InitializeComponent();
            Controller = controller;
            Variable = variable;
        }
        
        public double MinValue { get; set; }
        
        public double MaxValue { get; set; }

        private double value;
        public double Value
        {
            get
            {
                return value;
            }

            set
            {
                this.value = value;
                InvalidateVariable();
            }
        }

        void UpdateValueTrackBar()
        {
            double tValue = (MathPlus.Lerp(0, 1, (1 - (MaxValue - Value) / (MaxValue - MinValue))));
            if (tValue > 1) tValue = 1;
            if (tValue < 0 || double.IsNaN(tValue)) tValue = 0;
            ValueTrackBar.Value = (int)(tValue * 1000);
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            Controller.DeleteVariable(Variable);
        }

        private void NameTextBox_TextChanged(object sender, EventArgs e)
        {
            InvalidateVariable();
        }

        public void InvalidateVariable()
        {
            Controller.EditVariable(Variable, NameTextBox.Text, value);
        }

        private void ValueTrackBar_Scroll(object sender, EventArgs e)
        {
            double percentage = (double)ValueTrackBar.Value / ValueTrackBar.Maximum;
            Value = MathPlus.Lerp(MinValue, MaxValue, percentage);
            ValueNumericUpDown.Value = (decimal)Value;
        }

        private void ValueNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Value = (double)ValueNumericUpDown.Value;
            if (Value > MaxValue) MaxNumericUpDown.Value = (decimal)Value;
            if (Value < MinValue) MinNumericUpDown.Value = (decimal)Value;
            UpdateValueTrackBar();
        }

        private void MaxNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            MaxValue = (double)MaxNumericUpDown.Value;
            if (MaxValue < MinValue)
            {
                MinValue = MaxValue;
                MinNumericUpDown.Value = (decimal)MaxValue;
            }
            UpdateValueTrackBar();
        }

        private void MinNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            MinValue = (double)MinNumericUpDown.Value;
            if (MinValue > MaxValue)
            {
                MaxValue = MinValue;
                MaxNumericUpDown.Value = (decimal)MinValue;
            }
            UpdateValueTrackBar();
        }
    }
}
