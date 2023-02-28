using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary
{
    public abstract class Shape
    {
        protected int x { set; get; }
        protected int y { set; get; }
        protected Color colour { set; get; }

        public Shape()
        {
            Random random = new Random();
            x = random.Next(600);
            y = random.Next(350);
            colour = Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));
        }

        public Shape(int x, int y)
        {
            this.x = x;
            this.y = y;
            colour = Color.Red;
        }

        public Shape(int x)
        {
            this.x = x;
            y = 25;
            colour = Color.Red;
        }

        public Shape(int x, int y, Color color)
        {
            this.x = x;
            this.y = y;
            colour = color;
        }

        public Shape(Shape obj)
        {
            x = obj.x;
            y = obj.y;
            colour = obj.colour;
        }

        public abstract void Draw(Graphics graphics);


        public void ChangePosition(int newX, int newY)
        {
            x = +newX;
            y = +newY;
        }

        public void ChangeSize(int newX, int newY)
        {
            x = newX;
            y = newY;
        }
    }
}
