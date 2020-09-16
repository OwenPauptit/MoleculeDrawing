using Microsoft.AspNetCore.Components.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace MoleculeDrawing
{
    public class Node
    {
        public Node(MouseEventArgs e, string atom)
        {
            Position = new Vector2((float)e.ClientX, (float)e.ClientY);
            Degree = 0;
            Colour = "#ffffff";
            Dragging = true;
            Atom = atom;
            SetStyle();
        }
        public Vector2 Position { get; set; }
        public int Degree { get; set; }
        public bool Dragging { get; set; }
        public string Style { get; set; }
        public string Colour { get; set; }
        public string Atom { get; set; }
        public void SetStyle()
        {
            Style = $"left: {Position.X - 12}px; top: {Position.Y - 12}px; background-color: {Colour}";
        }

        public void Drag(MouseEventArgs e)
        {
            if(Dragging)
            {
                Position = new Vector2((float)e.ClientX, (float)e.ClientY);
                SetStyle();
            }
        }

        public void Click()
        {
            Dragging = !Dragging;
        }
    }
}
