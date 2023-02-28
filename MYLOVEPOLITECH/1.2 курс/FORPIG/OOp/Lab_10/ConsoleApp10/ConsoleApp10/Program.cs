using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary1;

namespace ConsoleApp10
{
    class Program
    {
   


        static void Main(string[] args)
        {
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Лабораторна робота №10");
            Fraction fraction1 = new Fraction(1, 3);
            Fraction fraction2 = new Fraction();
            Fraction fraction3 = new Fraction(2,3);
            Fraction fraction4 = new Fraction();
            Fraction fraction5 = new Fraction();
            Fraction fraction6 = new Fraction();
            Fraction fraction7 = new Fraction();
            Fraction fraction8 = new Fraction(121,847);
            Fraction fraction9 = new Fraction();
            Console.WriteLine("Вхідні дроби:");
            Console.WriteLine(fraction1.ToString());
            Console.WriteLine(fraction3.ToString());
            Console.WriteLine(fraction8.ToString());
            Console.WriteLine($"{fraction1} > {fraction2} {fraction1>fraction2} ");
            Console.WriteLine($"{fraction1} < {fraction2} {fraction1<fraction2}");
            Console.WriteLine($"{fraction1} >= {fraction2} {fraction1 >= fraction2}");
            Console.WriteLine($"{fraction1} <= {fraction2} {fraction1 <= fraction2}");
            Console.WriteLine($"{fraction1} = {fraction3} {fraction1 == fraction3} ");
            Console.WriteLine($"{fraction1} != {fraction3} {fraction1 != fraction3}: ");
            fraction2 = fraction1 + fraction3;
            fraction4 = fraction2 - fraction1;
            fraction5 = fraction4 * fraction3;
            fraction6 = fraction8 / fraction4;
            double fraction10 = (double)fraction4;
            Console.WriteLine($"{fraction1} + {fraction3} = {fraction2}");
            Console.WriteLine($"{fraction2} - {fraction1} = {fraction4}");
            Console.WriteLine($"{fraction4} * {fraction3} = {fraction5}");
            Console.WriteLine($"{fraction8}");
            Console.WriteLine($"{fraction8} / {fraction4} = {fraction6}");
            Console.WriteLine($"{fraction8}");
            Console.WriteLine($"{fraction7}");
            Console.WriteLine($"Перевод дроба {fraction4} до типу double: {fraction10}");
            Console.WriteLine($"Скоротити дрiб: {fraction8}");
            Fraction.ToLow(fraction8);
            Console.WriteLine($"Скорочений дріб: {fraction8}");



        }
    }
}
