using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoleculeDrawing

{
    public class NodeList
    {
        public NodeList()
        {
            Nodes = new List<Node>();
        }

        public List<Node> Nodes { get; private set; }

        public void Add(MouseEventArgs e, string atom)
        {
            Nodes.Add(new Node(e, atom));
        }
        public void Clear()
        {
            Nodes = new List<Node>();
        }
        public void ResetColours()
        {
            for (int i = 0; i < Nodes.Count(); i++)
            {
                Nodes[i].Colour = "#ff0000";
                Nodes[i].SetStyle();
            }
        }
        public void Sort()
        {
            Node temp;
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < Nodes.Count() - 1; i++)
                {
                    if (Nodes[i].Degree < Nodes[i + 1].Degree)
                    {
                        sorted = false;
                        temp = Nodes[i];
                        Nodes[i] = Nodes[i + 1];
                        Nodes[i + 1] = temp;
                    }
                }
            }
        }

        public void IncDegree(Node n)
        {
            if (Nodes.Contains(n))
            {
                n.Degree++;
            }
        }

    }
}
