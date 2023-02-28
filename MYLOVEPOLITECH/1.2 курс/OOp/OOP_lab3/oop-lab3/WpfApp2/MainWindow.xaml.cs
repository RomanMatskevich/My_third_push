using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            
            InitializeComponent();
            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
            System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
        }

        private void buton_Click(object sender, RoutedEventArgs e)
        {
            string s = txt.Text;
            string[] words = txt.Text.Split(new char[] { ',', '.' });

            string[] arrstring = new string[1];
            if (s != "," && s != ".")
            {
                arrstring = s.Split(',', '.');
            }
            int[] mas = new int[arrstring.Length - 1];
            for (int i = 0; i < arrstring.Length - 1; i++)
            {
                mas[i] = Convert.ToInt32(arrstring[i]);
            }
            int count = 0;
            for (int i = 0; i < mas.Length; i++)
            {
                if (mas[i] % 2 == 0 && Box.IsChecked == true)
                {
                    count++;
                }
                else if (mas[i] % 2 != 0 && Box.IsChecked == false)
                    count++;
            }
            txt2.Text = count.ToString();

        }
    }
}
