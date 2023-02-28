using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary
{
    public class Circle : Dot
    {
        protected int R1;

        public Circle() : base()
        {
            Random random = new Random();
            R1 = random.Next(400);
        }

        public Circle(int x, int y, int radius, Color color) : base(x, y, color)
        {
            R1 = radius;
        }

        public Circle(int x, int y, Color color) : base(x, y, color)
        {
            R1 = 50;
        }

        public Circle(int x, int y) : base(x, y)
        {
            R1 = 25;
        }

        public Circle(Circle obj)
        {
            x = obj.x;
            y = obj.y;
            colour = obj.colour;
            R1 = obj.R1;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(colour, 3);
            graphics.DrawEllipse(pen, x, y, R1, R1);
        }
    }
}
