using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace ClassLibrary
{
    public class Line : Dot
    {
        protected int X1;
        protected int Y1;
        public Line() : base() { }

        public Line(int x, int y, int x1, int y1, Color color) : base(x, y, color)
        {
            X1 = x1;
            Y1 = y1;
        }

        public Line(int x, int y, Color color) : base(x, y, color)
        {
            X1 = 10;
            Y1 = 20;
        }

        public Line(int x, int y, int x1) : base(x, y)
        {
            X1 = x1;
            Y1 = 20;
        }

        public Line(Line obj)
        {
            X1 = obj.X1;
            Y1 = obj.Y1;
            x = obj.x;
            y = obj.y;
            colour = obj.colour;
        }

        public int GetX1()
        {
            return X1;
        }

        public int GetY1()
        {
            return Y1;
        }

        public void SetX1(int x1)
        {
            if (x1 >= 0)
                X1 = x1;
        }

        public void SetY1(int y1)
        {
            if (y1 >= 0)
                Y1 = y1;
        }

        public override void Draw(Graphics graphics)
        {
            Pen pen = new Pen(colour, 3);
            graphics.DrawLine(pen, x, y, X1, Y1);
        }
    }
}
