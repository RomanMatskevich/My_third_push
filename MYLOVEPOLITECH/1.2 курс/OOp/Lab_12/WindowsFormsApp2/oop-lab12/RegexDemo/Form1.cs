using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace RegexDemo
{
    public partial class FormRegex : Form
    {
        public FormRegex()
        {
            InitializeComponent();
        }

        string text;
        Regex r = new Regex("");

        private void buttonPhone_Click(object sender, EventArgs e)
        {
            text = textBoxPhone.Text;
            r = new Regex(@"(\+38)|(38)?0\d{2}-?\d{3}-?\d{2}-?\d{2}", RegexOptions.Multiline);
            Match m = r.Match(text);
            if (m.Success)
            {
                labelPhoneCheck.Text = "ОК";
                labelPhoneCheck.ForeColor = Color.DarkGoldenrod;
            }
            else {
                labelPhoneCheck.Text = "помилка";
                labelPhoneCheck.ForeColor = Color.Red;
            }
        }

        private void buttonPassport_Click(object sender, EventArgs e)
        {
            text = textBoxPassport.Text;
            r = new Regex(@"([А-ГҐДЕЄЖЗИІЇЙК-Я]{2}\d{6})|( \d{9} )", RegexOptions.Multiline);
            Match m = r.Match(text);
            if (m.Success)
            {
                labelPassportCheck.Text = "ОК";
                labelPassportCheck.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                labelPassportCheck.Text = "помилка";
                labelPassportCheck.ForeColor = Color.Red;
            }
        }

        private void buttonNumberDiap_Click(object sender, EventArgs e)
        {
            text = textBoxNumberDiap.Text;
            r = new Regex(@"(^103[1-9][1-9]$)|(^10[4-9][0-9][0-9]$)|(^11\d{3}$)|(^12\d{3}$)|(^13\d{3}$)|(^14\d{3}$)|(^15\d{3}$)|(^16\d{3}$)|(^17\d{3}$)|(^18\d{3}$)|(^19\d{3}$)|(^2\d{4}$)|(^3\d{4}$)|(^4\d{4}$)|(^5\d{4}$)|(^6\d{4}$)|(^7\d{4}$)|(^80[0-9][0-9][0-9]$)|(^81[0-9][0-9][0-9]$)|(^82[0-9][0-9][0-9]$)|(^83[0-9][0-9][0-9]$)|(^84[0-9][0-9][0-9]$)|(^85[0-9][0-9][0-9]$)|(^86[0-9][0-9][0-9]$)|(^87[0-9][0-9][0-9]$)|(^88[0-9][0-9][0-9]$)|(^890[0-9][0-9]$)|(^891[0-9][0-9]$)|(^892[0-9][0-9]$)|(^893[0-9][0-9]$)|(^894[0-9][0-9]$)|(^895[0-9][0-9]$)|(^8960[0-9]$)|(^8961[0-9]$)|(^8962[0-9]$)|(^8963[0-9]$)|(^8964[0-5]$)", RegexOptions.Multiline);
            Match m = r.Match(text);
            if (m.Success)
            {
                labelNumberDiapCheck.Text = "ОК";
                labelNumberDiapCheck.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                labelNumberDiapCheck.Text = "помилка";
                labelNumberDiapCheck.ForeColor = Color.Red;
            }
        }

        private void buttonName_Click(object sender, EventArgs e)
        {
            text = textBoxName.Text;
            r = new Regex(@"[А-ГҐДЕЄЖЗИІЇЙК-ЩЮЯ][а-щьюя]+", RegexOptions.Multiline);
            Match m = r.Match(text);
            if (m.Success)
            {
                labelNameCheck.Text = "ОК";
                labelNameCheck.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                labelNameCheck.Text = "помилка";
                labelNameCheck.ForeColor = Color.Red;
            }
        }

        private void buttonTime_Click(object sender, EventArgs e)
        {
            text = textBoxTime.Text;
            r = new Regex(@"(0[0-9]:[0-6][0-9])|(1[0-9]:[0-6][0-9])|(2[0-4]:[0-6][0-9])|24:00", RegexOptions.Multiline);
            Match m = r.Match(text);
            if (m.Success)
            {
                labelTimeCheck.Text = "ОК";
                labelTimeCheck.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                labelTimeCheck.Text = "помилка";
                labelTimeCheck.ForeColor = Color.Red;
            }
        }

        private void buttonNumber_Click(object sender, EventArgs e)
        {
            text = textBoxNumber.Text;
            r = new Regex(@"(([-+]?\d+\.\d+))|(([-+]?[1-9])(\d+)?)|(^0$)", RegexOptions.Multiline);
            Match m = r.Match(text);
            if (m.Success)
            {
                labelNumberCheck.Text = "ОК";
                labelNumberCheck.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                labelNumberCheck.Text = "помилка";
                labelNumberCheck.ForeColor = Color.Red;
            }
        }

        private void buttonDate_Click(object sender, EventArgs e)
        {
            text = textBoxDate.Text;
            r = new Regex(@"((19[0-9]{2})|(200[0-9])|(201[0-7]))-((0[0-9])|(1[0-2]))-((0[0-9])|(1[0-9])|(2[0-9])|)\s{1}((0[0-9]:[0-6][0-9])|(1[0-9]:[0-6][0-9])|(2[0-4]:[0-6][0-9])|24:00)", RegexOptions.Multiline);
            Match m = r.Match(text);
            if (m.Success)
            {
                labelDateCheck.Text = "ОК";
                labelDateCheck.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                labelDateCheck.Text = "помилка";
                labelDateCheck.ForeColor = Color.Red;
            }
        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            text = textBoxEmail.Text;
            r = new Regex(@"^[a-z\d_\.]+@[a-z\d]+(\.[a-z\d]+)+", RegexOptions.Multiline);
            Match m = r.Match(text);
            if (m.Success)
            {
                labelEmailCheck.Text = "ОК";
                labelEmailCheck.ForeColor = Color.DarkGoldenrod;
            }
            else
            {
                labelEmailCheck.Text = "помилка";
                labelEmailCheck.ForeColor = Color.Red;
            }
        }

      
        
    }
}
