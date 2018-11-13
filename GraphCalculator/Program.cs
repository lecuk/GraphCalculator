using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GraphCalculator.View.Forms;
using System.Windows.Forms;
using GraphCalculator.Model;

namespace GraphCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
            string equation;
            do
            {
                equation = Console.ReadLine();
                try
                {
                    Function f = new Function(equation, "x");
                    string postfix = f.PostfixEquation;
                    Console.WriteLine($"Postfix equation is: {postfix}");
                    Console.WriteLine($"{equation} = {f.Evaluate(1)}");
                }
                catch (Exception e)
                {
                    Console.WriteLine("ERROR: " + e.Message);
                }
            }
            while (equation != "");
            */
            Application.Run(new MainForm());
        }
    }
}
