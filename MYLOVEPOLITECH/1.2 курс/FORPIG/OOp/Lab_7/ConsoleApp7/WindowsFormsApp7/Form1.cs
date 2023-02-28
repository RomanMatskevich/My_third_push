using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp7
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
            bool ok;
            double shirina,visota;
           
            ok = double.TryParse(this.shirina.Text, out shirina);
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення Ширини!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.shirina.Text = "";
                shirina = 0;
            }
            ok = double.TryParse(this.visota.Text, out visota);
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення Висоти!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.visota.Text = "";
                visota = 0;
            }

            bool odnokamern = odnokamerni.Checked,dvokamern=dvokamerni.Checked;
            double sqrt = shirina * visota,vartist=1;
            if (comboBoxMaterial.Text == "Дерево"&&odnokamern)
            {
                vartist = 0.25;
            }else
            if (comboBoxMaterial.Text == "Дерево" && dvokamern)
            {
                vartist = 0.30;
            }else
            if (comboBoxMaterial.Text == "Метал" && odnokamern)
            {
                vartist = 0.05;

            }else
            if (comboBoxMaterial.Text == "Метал" && dvokamern)
            {
                vartist = 0.10;
            }else
            if (comboBoxMaterial.Text == "Металопластик" && odnokamern)
            {
                vartist = 0.15;
            }else
            if (comboBoxMaterial.Text == "Металопластик" && dvokamern)
            {
                vartist = 0.20;
            }
            vartist *= sqrt;
            if (pidvikonia.Checked==true)
                vartist += 35;
            
            textBoxVivod.Text = vartist.ToString()+ "ГРН.";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
    }
}
