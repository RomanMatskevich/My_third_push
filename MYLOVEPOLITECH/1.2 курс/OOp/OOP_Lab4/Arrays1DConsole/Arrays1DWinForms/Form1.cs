using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arrays1DWinForms
{
    public partial class Form1 : Form
    {
        int k = 10, min = -54, max = 57; int count = 0;
        double dob = 1;
        double[] arr;

       

        public Form1()
        {
            InitializeComponent();
            this.Text = "Лабораторна робота №4. Завдання 1";

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
                              System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;


        }
       
        private void button1_Click(object sender, EventArgs e)
        {

         
            int value = (int)(NumericUpDown.Value);
            arr = new double[value];
            dataGridView1.RowCount = 1;
            dataGridView1.ColumnCount = value;
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(min, max);
                arr[i] /= 10.0;
                dataGridView1[i, 0].Value = arr[i];
                dataGridView1.Columns[i].HeaderText = i.ToString();
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                    dob = dob * arr[i];
            }
            int j = 0;
            while (arr[j] >= 0)
            {
                count++;
                j++;
            }
            double[] brr = new double[count];
            for (int i = 0; i < count; i++)
            {
                brr[i] = arr[i];
            }
            Array.Sort(brr);
            for (int i = 0; i < count; i++)
            {
                arr[i] = brr[i];
            }
            textBox1.Text = Math.Round(Math.Abs(dob),2).ToString();
            for (int i = 0; i < arr.Length; i++)
            {
                dataGridView1[i, 0].Value = arr[i];
                dataGridView1.Columns[i].HeaderText = i.ToString();
            }
        }

    }
}
