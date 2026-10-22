using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    internal class Line : IDeletable
    {
        public bool Deleted {  get; set; } = false;
        public Node Start { get; set; }
        public Node End { get; set; }
        public void Draw(Graphics g)
        {
            if (Start == null || End == null) {  return; }
            Pen p = new Pen(Color.Black, (float)(1 * Settings.Zoom));
            g.DrawLine(p, Outils.GeometryToScreen(Start.Center), Outils.GeometryToScreen(End.Center));
        }
    }
}
