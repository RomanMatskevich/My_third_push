using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary
{
    public class Elipse : Circle
    {
        protected int R2;

        public Elipse() : base()
        {
            Random random = new Random();
            R2 = random.Next(420);
        }

        public Elipse(int x, int y, int radius, int radius2, Color color) : base(x, y, radius, color)
        {
            R2 = radius2;
        }

        public Elipse(int x, int y, int radius, Color color) : base(x, y, radius, color)
        {
            R2 = 100;
        }

        public Elipse(int x, int y) : base(x, y)
        {
            R2 = 75;
        }

        public Elipse(Elipse prev)
        {
            x = prev.x;
            y = prev.y;
            colour = prev.colour;
            R1 = prev.R1;
            R2 = prev.R2;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(colour, 3);
            graphics.DrawEllipse(pen, x, y, R1, R2);
        }
    }
}

