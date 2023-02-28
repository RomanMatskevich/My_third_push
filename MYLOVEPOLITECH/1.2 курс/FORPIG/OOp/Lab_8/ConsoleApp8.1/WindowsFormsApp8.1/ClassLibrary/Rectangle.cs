using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary
{
    public class Rectangle : Line
    {
        public Rectangle() : base() { }

        public Rectangle(int x, int y, int x1, int y1, Color color) : base(x, y, x1, y1, color) { }

        public Rectangle(int x, int y, Color color) : base(x, y, color) { }

        public Rectangle(int x, int y, int x1) : base(x, y, x1) { }

        public Rectangle(Rectangle obj)
        {
            x = obj.x;
            y = obj.y;
            colour = obj.colour;
            X1 = obj.X1;
            Y1 = obj.Y1;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(colour, 3);
            graphics.DrawRectangle(pen, x, y, Math.Abs(x - X1), Math.Abs(y - Y1));
        }
    }
}
