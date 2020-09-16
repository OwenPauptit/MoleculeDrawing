using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoleculeDrawing
{
    public class Graph
    {
        public Graph()
        {
            NodeList = new NodeList();
            EdgeList = new EdgeList();
        }
        public NodeList NodeList { get; private set; }
        public EdgeList EdgeList { get; private set; }

        private List<Node> Visited = new List<Node>();

        private List<Node> Traverse(Node u, List<Node> visited)
        {
            visited.Add(u);
            List<Node> adjacent = (from e in EdgeList.Edges
                                   where e.Node1 == u
                                   select e.Node2)
                                   .Union(from e in EdgeList.Edges
                                          where e.Node2 == u
                                          select e.Node1)
                                   .ToList();

            foreach (var v in adjacent)
            {
                if (!visited.Contains(v))
                {
                    visited = Traverse(v, visited);
                }
            }
            return visited;

        }
        public bool isConnected()
        {
            if (NodeList.Nodes.Count() == 0)
            {
                return false;
            }
            Visited = new List<Node>();
            Visited = Traverse(NodeList.Nodes[0], Visited);
            return Visited.Count() == NodeList.Nodes.Count();
        }
        public void ColourNodes()
        {
            NodeList.Sort();

            string[] colours = { "#00ff00", "#ff0000", "#0000ff", "#ffff00", "#00ffff", "#ff00ff", "#000000" };
            List<string> coloursAvailable = new List<string>();

            NodeList.Nodes[0].Colour = colours[0];
            NodeList.Nodes[0].SetStyle();
            for (int i = 1; i < NodeList.Nodes.Count(); i++)
            {
                coloursAvailable = colours.ToList();

                foreach (var edge in EdgeList.Edges)
                {
                    if (edge.Node1 == NodeList.Nodes[i])
                    {
                        if (!String.IsNullOrEmpty(edge.Node2.Colour))
                        {
                            coloursAvailable.Remove(edge.Node2.Colour);
                            var x = coloursAvailable.Count();
                        }
                    }

                    else if (edge.Node2 == NodeList.Nodes[i])
                    {
                        if (!String.IsNullOrEmpty(edge.Node1.Colour))
                        {
                            coloursAvailable.Remove(edge.Node1.Colour);
                            var x = coloursAvailable.Count();
                        }
                    }
                }
                NodeList.Nodes[i].Colour = coloursAvailable[0];
                NodeList.Nodes[i].SetStyle();
            }
        }
        public void AddEdge(Edge e)
        {
            NodeList.IncDegree(e.Node1);
            NodeList.IncDegree(e.Node2);
            EdgeList.Add(e);
        }
        public void AddNode(MouseEventArgs e, string atom)
        {
            NodeList.Add(e, atom);
        }
        public void Clear()
        {
            NodeList.Clear();
            EdgeList.Clear();
        }
        public void ResetColours()
        {
            NodeList.ResetColours();
            EdgeList.ResetColours();
        }
    }
}
