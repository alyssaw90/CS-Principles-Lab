using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scribble
{
        public enum Style
        {
            Dots, 
            Cursive,
            Rectangles
        }

        public class Stroke
        {
            public List<Point> points = new List<Point>();
            public Style style;
            public Color color;
            public int size;
        }
}
