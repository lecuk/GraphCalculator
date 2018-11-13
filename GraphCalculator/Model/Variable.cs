using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCalculator.Model
{
    class Variable
    {
        private string name;
        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
                IsValid = !string.IsNullOrWhiteSpace(value);
                NameChanged?.Invoke(this, new EventArgs());
            }
        }

        private double value;
        public double Value
        {

            get
            {
                return value;
            }

            set
            {
                IsValid = !(double.IsInfinity(value) || double.IsNaN(value));
                this.value = value;
                ValueChanged?.Invoke(this, new EventArgs());
            }
        }

        public bool IsValid { get; set; }

        public event EventHandler NameChanged;
        public event EventHandler ValueChanged;

        public Variable(string name, double value)
        {
            Name = name;
            Value = value;
        }

        public Variable(string name) : this(name, 0) { }
    }
}
