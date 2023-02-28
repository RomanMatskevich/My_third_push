using System;

namespace ClassLibrary
{
    public class Person
    {
        protected string Name;
        public string name
        {
            set { Name = value; }
            get { return name; }
        }
        protected string Surname;
        public string surname 
        { 
            set { Surname = value; }
            get { return Surname; } 
        }
        protected int Date;
        public int date
        { 
            set { Date = value; }
            get { return Date; } 
        }
        public Person()
        {
            Name = "Roman";
            Surname = "Matskevych";
            Date = 23032003;
        }
        public void personkonst(string name,string surname,int date)
        {
            Name = name;
            Surname = surname;
            Date = date;
        
        }
        public Person(string name, string surname, int date)
        {
            Name = name;
            Surname = surname;
            Date = date;
        }
        public Person(Person prev)
        {
            Name = prev.Name;
            Surname = prev.Surname;
            Date = prev.Date;
        }
        public virtual void ShowInfo()
        {
            Console.WriteLine($"Ім'я {Name}\nПрізвище{Surname}\nДата народження{Date}");
        }
    }
}
