using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary
{
    public class Dot : Shape
    {
        public Dot() : base() { }

        public Dot(int x, int y, Color color) : base(x, y, color) { }

        public Dot(int x, int y) : base(x, y) { }

        public Dot(int x) : base(x) { }

        public Dot(Dot obj)
        {
            x = obj.x;
            y = obj.y;
            colour = obj.colour;
        }

        public override void Draw(Graphics graphics)
        {
            Brush brush = new SolidBrush(colour);
            graphics.FillEllipse(brush, x, y, 6, 6);
        }
    }
}
