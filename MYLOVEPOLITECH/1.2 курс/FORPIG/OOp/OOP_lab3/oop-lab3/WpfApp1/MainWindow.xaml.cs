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

namespace WpfApp1
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

        private void Buton_Click(object sender, RoutedEventArgs e)
        {
            double a, b, h, y;
            bool ok;
            ok = double.TryParse(boxa.Text, out a);
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення a!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                boxa.Text = "";
                a = 0;
            }
            ok = double.TryParse(boxb.Text, out b);
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення b!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                boxb.Text = "";
                b = 0;
            }
            ok = double.TryParse(boxh.Text, out h);
            if (!ok)
            {
                MessageBox.Show("Помилка введення значення h!", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                boxh.Text = "";
                h = 0;
            }
            while (a <= (b+h/2))
            {
                y = ((a + Math.Cos(3 * a)) / (2 * a));
                richbox.AppendText("x\ty\n");
                richbox.AppendText($"{a:F2}\t");
                richbox.AppendText($"{y:F2}\n");
                a += h;
            }
        }
    }
}
