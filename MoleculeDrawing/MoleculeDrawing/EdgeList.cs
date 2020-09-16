using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoleculeDrawing
{
    public class EdgeList
    {
        public EdgeList()
        {
            Edges = new List<Edge>();
        }

        public List<Edge> Edges { get; private set; }

        public void Add(Edge e)
        {
            var existingEdge = Edges.FirstOrDefault(s => s.Node1 == e.Node1 && s.Node2 == e.Node2);
            if (existingEdge != null)
            {
                int weight;
                if (Int32.TryParse(existingEdge.Weight, out weight))
                {
                    weight++;
                    existingEdge.Weight = weight.ToString();
                }
            }
            else
            {
                Edges.Add(e);
            }
        }
        public void Clear()
        {
            Edges = new List<Edge>();
        }
        public void ResetColours()
        {
            for (int i = 0; i < Edges.Count(); i++)
            {
                Edges[i].Colour = "#000000";
            }
        }
        private void Sort()
        {
            Edge temp;
            bool sorted = false;
            while (!sorted)
            {
                sorted = true;
                for (int i = 0; i < Edges.Count() - 1; i++)
                {
                    int current, next;
                    if (!Int32.TryParse(Edges[i].Weight, out current))
                    {
                        return;
                    }

                    if (!Int32.TryParse(Edges[i + 1].Weight, out next))
                    {
                        return;
                    }
                    if (current > next)

                    {
                        sorted = false;
                        temp = Edges[i].Clone();
                        Edges[i] = Edges[i + 1].Clone();
                        Edges[i + 1] = temp.Clone();
                    }
                }
            }
        }

        public void GenerateST()
        {
            List<Node> STNodes = new List<Node>();
            List<Edge> STEdges = new List<Edge>();
            int numNodes, numEdges;
            bool[] needToAddNode;

            foreach (var edge in Edges)
            {
                numNodes = STNodes.Count();
                numEdges = STEdges.Count() + 1;
                needToAddNode = new bool[] { false, false };
                if (!STNodes.Contains(edge.Node1))
                {
                    numNodes++;
                    needToAddNode[0] = true;
                }
                if (!STNodes.Contains(edge.Node2))
                {
                    numNodes++;
                    needToAddNode[1] = true;
                }
                if (numEdges <= numNodes - 1)
                {
                    if (needToAddNode[0]) STNodes.Add(edge.Node1);
                    if (needToAddNode[1]) STNodes.Add(edge.Node2);
                    STEdges.Add(edge);
                }


            }

            for (int i = 0; i < STEdges.Count(); i++)
            {
                STEdges[i].Colour = "#00ff00";
            }
        }
        public void GenerateMST()
        {
            Sort();
            GenerateST();
        }
    }
}
