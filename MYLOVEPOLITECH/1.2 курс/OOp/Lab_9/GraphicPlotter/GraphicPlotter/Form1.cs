using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GraphicPlotter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
          
        }
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            one();
        }

        private void Form1_Reize(object sender, EventArgs e)
        {
            one();
        }
        void one()
        {
            Graphics g = this.CreateGraphics();
            g.Clear(Color.White);
            Pen osi = new Pen(Color.Black, 1);
            Pen graphic = new Pen(Color.Red, 2);
            Font drawFont = new Font("Arial", 12);
            Font signatureFont = new Font("Arial", 7);
            SolidBrush drawBrush = new SolidBrush(Color.Blue);
            StringFormat drawFormat = new StringFormat();
            drawFormat.FormatFlags = StringFormatFlags.DirectionRightToLeft;
            int sizeWidth = this.Width;
            int sizeHeight = this.Height;
            Point center = new Point(((int)(sizeWidth / 2) - 8), (int)(sizeHeight / 2) - 19);
            g.DrawLine(osi, 10, center.Y, center.X, center.Y);
            g.DrawLine(osi, center.X, center.Y, 2 * center.X - 10, center.Y);
            g.DrawLine(osi, center.X, 10, center.X, center.Y);
            g.DrawLine(osi, center.X, center.Y, center.X, 2 * center.Y - 10);
            g.DrawString("X", drawFont, drawBrush, new PointF(2 * center.X - 5, center.Y + 10), drawFormat);
            g.DrawString("Y", drawFont, drawBrush, new PointF(center.X + 30, 5), drawFormat);
            g.DrawString("0", drawFont, drawBrush, new PointF(center.X + 17, center.Y - 17), drawFormat);
            g.DrawLine(osi, center.X, 10, center.X + 5, 20);
            g.DrawLine(osi, center.X, 10, center.X - 5, 20);
            g.DrawLine(osi, 2 * center.X - 10, center.Y, 2 * center.X - 15, center.Y - 5);
            g.DrawLine(osi, 2 * center.X - 10, center.Y, 2 * center.X - 15, center.Y + 5);
            int stepForAxes = 25;
            int lengthShtrih = 3;
            int maxValueForAxesX = 10;
            int minValueForAxesX = -10;
            int maxValueForAxesY = 10;
            float oneDelenieX = maxValueForAxesX / ((float)center.X / stepForAxes);
            float oneDelenieY = maxValueForAxesY / ((float)center.Y / stepForAxes);
            for (int i = center.X, j = center.X, k = 1; i < 2 * center.X - 30; j -= stepForAxes, i += stepForAxes, k++)
            {
                g.DrawLine(osi, i, center.Y - lengthShtrih, i, center.Y + lengthShtrih);
                g.DrawLine(osi, j, center.Y - lengthShtrih, j, center.Y + lengthShtrih);
                if (i < 2 * center.X - 55)
                {
                    g.DrawString((k * oneDelenieX).ToString("0.0"), signatureFont, drawBrush, new PointF(i + stepForAxes + 9, center.Y + 6), drawFormat);
                    g.DrawString((k * oneDelenieX).ToString("0.0").ToString() + "-", signatureFont, drawBrush, new PointF(j + stepForAxes - 40, center.Y + 6), drawFormat);
                }
            }
            for (int i = center.Y, j = center.Y, k = 1; i < 2 * center.Y - 30; j -= stepForAxes, i += stepForAxes, k++)
            {
                g.DrawLine(osi, center.X - lengthShtrih, i, center.X + lengthShtrih, i);
                g.DrawLine(osi, center.X - lengthShtrih, j, center.X + lengthShtrih, j);
                if (i < 2 * center.Y - 55)
                {
                    g.DrawString((k * oneDelenieY).ToString("0.0"), signatureFont, drawBrush, new PointF(center.X - 10, j + stepForAxes - 55), drawFormat);
                    g.DrawString((k * oneDelenieY).ToString("0.0").ToString() + "-", signatureFont, drawBrush, new PointF(center.X - 10, i + stepForAxes - 5), drawFormat);
                }
            }

            int numОfPоіnts = 100;
            float[] first = new float[numОfPоіnts];
            for (int і = 0; і < numОfPоіnts; і++)
            {
                first[і] = ((float)(Math.Abs(maxValueForAxesX) + Math.Abs(minValueForAxesX)) / numОfPоіnts * (і + 1) + minValueForAxesX);
            }
            float[] sеcоnd = new float[numОfPоіnts];
            for (int i = 0; i < numОfPоіnts; i++)
            {
                sеcоnd[i] = -(first[i] * (float)Math.Sin(5*first[i]));
            }
            Point[] pоіntОnе = new Point[numОfPоіnts];
            float tеmpX = 1 / oneDelenieX * stepForAxes;
            float tеmpУ = 1 / oneDelenieY * stepForAxes;
            for (int і = 0; і < numОfPоіnts; і++)
            {
                pоіntОnе[і].X = center.X + (int)(first[і] * tеmpX);
                pоіntОnе[і].Y = center.Y + (int)(sеcоnd[і] * tеmpУ);
            }
            g.DrawCurve(graphic, pоіntОnе);


        }
    }
}
