using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TravelForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.Name = "TURISM";
        }

        private void rozrahuvaty_Click(object sender, EventArgs e)
        {
            bool ok,zima=winter.Checked,leto=summer.Checked;
            int days,turists;
            int vartist = 0;
            ok = int.TryParse(this.textBox1.Text, out days);
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення Ширини!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.textBox1.Text = "";
                days = 0;
            }
            ok = int.TryParse(this.tourists.Text, out turists );
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення Ширини!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.tourists.Text = "";
                turists = 0;
            }
            if (comboBoxCountry.Text == "Німеччина" &&leto )
            {
                vartist = 160;
            }
            else
            if (comboBoxCountry.Text == "Німеччина" && zima)
            {
                vartist = 200;
            }
            else
            if (comboBoxCountry.Text == "Польща" && zima)
            {
                vartist = 120;

            }
            else
            if (comboBoxCountry.Text == "Польща" && leto)
            {
                vartist = 180;
            }
            else
            if (comboBoxCountry.Text == "Болгарія" && zima)
            {
                vartist = 150;
            }
            else
            if (comboBoxCountry.Text == "Болгарія" && zima)
            {
                vartist = 100;
            }
            vartist *= days*turists;
            if (guide.Checked==true)
                vartist += days * 50;

            textBoxVivod.Text = vartist.ToString() + "$";

        }
    }
}
