using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;
namespace ConsoleApp8
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
            Person person = new Person("Роман", "Matskevych", 23032003);
            Person person1 = new Person();
            person1.personkonst("ivan", "Ivanov", 25072001);
            Entrant entrant = new Entrant();
            entrant.entrankonst(150,11,"#23");
            Entrant entrant1 = new Entrant();
            entrant1.entrantkonst(170,11);
            Student student = new Student();
            student.studentkonst(1,"IPZ","FIKT","ztu");
            Student student1 = new Student();
            student1.studentkonst1(1,"KI");
            Teacher teacher = new Teacher();
            teacher.teackkonst("Dekan","Math","POLITECH");
            Teacher teacher1 = new Teacher();
            teacher1.teackkonst1("REKTOR","PHISICA");
            Reader reader = new Reader(23,230907,100);
            //person.ShowInfo();
            //Console.WriteLine();
            //person1.ShowInfo();
            //Console.WriteLine();
            //entrant.ShowInfo();
            //Console.WriteLine();
            //entrant1.ShowInfo();
            //Console.WriteLine();
            //student.ShowInfo();
            //Console.WriteLine();
            //student1.ShowInfo();
            //Console.WriteLine();
            reader.ShowInfo();
            

        }
    }
}
