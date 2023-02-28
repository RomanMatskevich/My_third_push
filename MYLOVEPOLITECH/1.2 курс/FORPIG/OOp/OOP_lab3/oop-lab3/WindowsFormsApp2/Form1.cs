using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
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

        private void button1_Click(object sender, EventArgs e)
        {

          
            string s = textBox1.Text;
            string[] words = textBox1.Text.Split(new char[] { ',', '.' });
           
            string[] arrstring = new string[1];
            if (s != ","&&s!=".")
            {
                arrstring = s.Split(',','.');
            }
            int[] mas = new int[arrstring.Length - 1];
            for (int i = 0; i < arrstring.Length - 1; i++)
            {
                mas[i] = Convert.ToInt32(arrstring[i]);
            }
            int count=0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 == 0 && checkBox1.Checked == true)
                {
                    count++;
                }
                else if (mas[i]%2!=0&&checkBox1.Checked == false)
                    count++;
            }
            textBox2.Text = count.ToString();



        }
    }
}
