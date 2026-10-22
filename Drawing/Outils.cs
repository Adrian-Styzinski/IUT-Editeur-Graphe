using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    internal static class Outils
    {
        public static Point GeometryToScreen(Point p) => new((int)(p.X * Settings.Zoom) + Settings.Origin.X, (int)(p.Y * Settings.Zoom) + Settings.Origin.Y);
        public static Size GeometryToScreen(Size s) => new((int)(s.Width * Settings.Zoom), (int)(s.Height * Settings.Zoom));

        public static Point ScreenToGeometry(Point p) => new((int)((p.X - Settings.Origin.X) / Settings.Zoom), (int)((p.Y - Settings.Origin.Y) / Settings.Zoom));

        public static Size ScreenToGeometry(Size s) => new((int)(s.Width / Settings.Zoom), (int)(s.Height / Settings.Zoom));
    }
}
