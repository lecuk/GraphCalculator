using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphCalculator.Model
{
    class Curve
    {
        public readonly LinkedList<Vector2> Nodes;

        public Curve(IEnumerable<Vector2> nodes)
        {
            if (nodes == null) nodes = new Vector2[0];
            Nodes = new LinkedList<Vector2>();
            foreach (Vector2 node in nodes)
            {
                AddNode(node);
            }
        }

        public Curve() : this(null) {  }

        public void AddNode(Vector2 node)
        {
            LinkedListNode<Vector2> currentNode = Nodes.First;

            if (currentNode != null)
                _AddNode(node, currentNode);
            else
                Nodes.AddFirst(node);
        }

        void _AddNode(Vector2 node, LinkedListNode<Vector2> current)
        {
            if (node.x > current.Value.x)
            {
                if (current.Next != null)
                    _AddNode(node, current.Next);
                else
                    Nodes.AddAfter(current, node);
            }
            else
            {
                Nodes.AddBefore(current, node);
            }
        }

        public static Curve FromFunction (IEnumerable<double> arguments, Func<double, double> f)
        {
            var nodes = new List<Vector2>();
            foreach (double x in arguments)
            {
                double y = f(x);
                Vector2 node = new Vector2(x, y);
                nodes.Add(node);
            }
            return new Curve(nodes);
        }
    }
}
