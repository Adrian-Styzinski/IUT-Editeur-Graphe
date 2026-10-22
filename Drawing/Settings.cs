using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drawing
{
    internal class Settings
    {
        public static int BaseNodeWidth { get; set; } = 2;
        public static Color BaseNodeColour { get; set; } = Color.DeepPink;
        public static Size BaseNodeSize { get; set; } = new Size(20, 20);
        public static string BaseNodeText { get; set; } = string.Empty;
        public static Point Origin { get; set; } = new(0, 0);

        public static double Zoom { get; set; } = 1.0;
    }
}
