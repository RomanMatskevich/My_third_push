using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arrays2DWinForms
{
    public partial class Form1 : Form
    {
        int  min = -123, max = 163;
        int n, m;
      
        static double[,] matr;
        public Form1()
        {
            this.Text = "Лабораторна робота №4. Завдання 2";
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
                                 System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            n = (int)numericUpDown1.Value;
            m = (int)numericUpDown2.Value;
            matr = new double[n,m];

           daraGridViewMatrix.RowCount = n;
            daraGridViewMatrix.ColumnCount = m;
            Random rnd = new Random();
            for (int i = 0; i < m; i++)
            {
                daraGridViewMatrix.Columns[i].HeaderText = i.ToString();
                
                for (int j = 0; j < n; j++)
                {
                    matr[i, j] = rnd.Next(min, max) / 10.0;
                    daraGridViewMatrix.Rows[j].HeaderCell.Value = j.ToString();
                    daraGridViewMatrix[i, j].Value = matr[i,j];
                }
            }
          
        }


        private void button2_Click(object sender, EventArgs e)
        {
            double[] mas2 = new double[m];
            double[] suma = { 0, 0 };
            for (int i = 0; i < m; i++)
            {
                mas2[i] = 0;
                for (int j = 0; j < n; j++)
                    mas2[i] += matr[j, i];
                if (mas2[i] > suma[0])
                {
                    suma[0] = mas2[i];
                    suma[1] = i + 1;
                }
            }
            textBox1.Text=Math.Round(suma[0],2).ToString();

            for (int i = 0; i < m; i++)
            {
                mas2[i] = 0;
                for (int j = 0; j < n; j++)
                {
                    if (matr[j, i] < 0)
                        mas2[i] += Math.Abs(matr[j, i]);
                }

            }
            bool fl;
            double x;
           
            do
            {
                fl = false;
                for (int i = 0; i < m - 1; i++)
                {
                    if (mas2[i] < mas2[i + 1])
                    {
                        for (int j = 0; j < n; j++)
                        {
                            x = matr[j, i];
                            matr[j, i] = matr[j, i + 1];
                            matr[j, i + 1] = x;
                            x = mas2[i];
                            mas2[i] = mas2[i + 1];
                            mas2[i + 1] = x;
                            fl = true;
                        }
                    }
                }

            } while (fl);
          

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    daraGridViewMatrix[j, i].Value = matr[i, j];
                }
              
            }
        }

    }
}
