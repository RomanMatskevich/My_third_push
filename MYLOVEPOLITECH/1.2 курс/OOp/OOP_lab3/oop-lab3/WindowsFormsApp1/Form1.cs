using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
              System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a, b, h, y;
            bool ok;
            ok = double.TryParse(textBox1.Text, out a);
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення a!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Text = "";
                a = 0;
            }
            ok = double.TryParse(textBox2.Text, out b);
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення b!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                b = 0;
            }
            ok = double.TryParse(textBox3.Text, out h);
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення h!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox2.Text = "";
                h = 0;
            }
            while (a <= (b+h/2))
            {
                y = ((a + Math.Cos(3 * a)) / (2 * a));
                richTextBox1.AppendText("x\ty\n");
                richTextBox1.AppendText($"{a:F2}\t");
                richTextBox1.AppendText($"{y:F2}\n");
                a += h;
            }
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}