using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoleculeDrawing
{
    public class Edge
    {
        public Edge()
        {
            Colour = "#000000";
            Weight = "1";
        }
        public Node Node1 { get; set; }
        public Node Node2 { get; set; }
        public string Colour { get; set; }
        public string Weight { get; set; }

        public Edge Clone()
        {
            return new Edge
            {
                Node1 = this.Node1,
                Node2 = this.Node2,
                Colour = this.Colour,
                Weight = this.Weight
            };
        }
    }
}
