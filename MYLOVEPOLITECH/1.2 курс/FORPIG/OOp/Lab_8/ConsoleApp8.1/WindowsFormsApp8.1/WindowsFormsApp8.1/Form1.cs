using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClassLibrary;
namespace WindowsFormsApp8._1
{
    public partial class Form1 : Form
    {   
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics graphics = pictureBox1.CreateGraphics();
            Shape[] shapes = new Shape[20];
            Random rnd = new Random();
            for (int i = 0; i < 20; i++)
            {
                int shape = rnd.Next(5);
                switch (shape)
                {
                    case 0:
                        {
                            shapes[i] = new ClassLibrary.Dot(rnd.Next(600), rnd.Next(350), Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                            break;
                        }
                    case 1:
                        {
                            shapes[i] = new ClassLibrary.Line(rnd.Next(600), rnd.Next(350), rnd.Next(600), rnd.Next(350), Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                            break;
                        }
                    case 2:
                        {
                            shapes[i] = new ClassLibrary.Rectangle(rnd.Next(600), rnd.Next(350), rnd.Next(600), rnd.Next(350), Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                            break;
                        }
                    case 3:
                        {
                            shapes[i] = new ClassLibrary.Circle(rnd.Next(600), rnd.Next(350), rnd.Next(600), Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                            break;
                        }
                    case 4:
                        {
                            shapes[i] = new ClassLibrary.Elipse(rnd.Next(600), rnd.Next(350), rnd.Next(600), rnd.Next(350), Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256)));
                            break;
                        }
                }
            }
            for (int i = 0; i < 20; i++)
            {
                shapes[i].Draw(graphics);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            pictureBox1.Image = null;
        }
    }
}

