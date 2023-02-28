using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays1DConsole
{
    class Program
    {


        static void Main(string[] args)
        {

            System.Globalization.CultureInfo customCulture = (System.Globalization.CultureInfo)
                              System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            customCulture.NumberFormat.NumberDecimalSeparator = ".";
            System.Threading.Thread.CurrentThread.CurrentCulture = customCulture;
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            int n, min = -54, max = 57; bool ok; double dob = 1;
            do
            {
                Console.Write("Введіть кількість елементів масиву:");
                ok = int.TryParse(Console.ReadLine(), out n);
            } while (!ok);
            double[] arr=new double[n];
            int count = 0;
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                arr[i] = rnd.Next(min, max);
                arr[i] /= 10;
                Console.Write($" {arr[i]}");
                if (arr[i] < 0)
                    dob = dob * arr[i];

            }
            Console.WriteLine($"\n{Math.Round(Math.Abs(dob), 3)}\n");
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
            for (int i = 0; i < n; i++)
                Console.Write($" {arr[i]}");

        }
    }
}
