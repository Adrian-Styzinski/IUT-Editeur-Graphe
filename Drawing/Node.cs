using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    internal class Node : IDeletable
    {
        public bool Deleted { get; set; } = false;
        public bool Selected { get; set; } = false;
        public Point Location { get; set; }
        public Size Size { get; set; }
        public Point Center
        {
            get
            {
                return new Point(Location.X + Size.Width / 2,
                                   Location.Y + Size.Height / 2);
            }
        }
        public int Width { get; set; } = 2;

        public string Text { get; internal set; }
        public int TextSize { get; set; } = 12;
        public FontFamily TextFont { get; set; } = new FontFamily("Arial");

        public Color Color { get; set; }

        public void Draw(Graphics g)
        {

            Rectangle r = new Rectangle(Outils.GeometryToScreen(Location), Outils.GeometryToScreen(Size));
            Pen p = Selected ? new Pen(Color.Red, Width) : new Pen(Color, Width);

            g.DrawRectangle(p, r);
            g.DrawString(this.Text, new Font(TextFont, (float)(TextSize * Settings.Zoom), FontStyle.Regular), Selected ? Brushes.Red : Brushes.Black, Outils.GeometryToScreen(Location));
        }

        public bool Contains(Point point)
        {
            Rectangle r = new Rectangle(Outils.GeometryToScreen(Location), Outils.GeometryToScreen(Size));
            return r.Contains(point);
        }
    }
}
