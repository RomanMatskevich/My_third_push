using System;
using System.Collections.Generic;
using System.Text; 
namespace ClassLibrary
{
    public class Student
    {

        protected string Name;
        public string name { set; get; }

        protected string Surname;
        public string surname { set; get; }
        protected int Group;
        public int group { set; get; }

        protected int Year = 0;
        public int year { set; get; }
        protected Result[] Results;
        public Result[] results { get { return Results; } set { Results = value; } }


        public void konstu(string name, string surname, int group, int year)
        {
            Name = name;
            Surname = surname;
            Group = group;
            Year = year;
        }
        public Student(Student prev)
        {
            Name = prev.Name;
            Surname = prev.Surname;
            Group = prev.Group;
            Year = prev.Year;
        }
        public Student(string name, string surname, int group, int year)
        {
            Name = name;
            Surname = surname;
            Group = group;
            Year = year;
        }
        public Student()
        {
            Name = "ФФ";
            Surname = "ФФ";
            Year = 10;
            Group = 1110;

        }

        //Методы=============================================================
        public double GetAveragePoints()
        {
            double sa = 0;

            for (int i = 0; i < Results.Length; i++)
                sa = sa + Results[i].points;
            sa /= Results.Length;
            return sa;
        }
        public string GetBestSubject()
        {
            string names = "";
            int bal = 0;


            for (int i = 0; i < results.Length; i++)
                if (results[i].points > bal)
                {
                    bal = results[i].points;
                    names = results[i].subject;
                }
            return names;
        }
        public string GetWorstSubject()
        {
            string names = "";
            int bal = 100;


            for (int i = 0; i < results.Length; i++)
                if (results[i].points < bal)
                {
                    bal = results[i].points;
                    names = results[i].subject;
                }
            return names;
        }
        //7 лаба__________________________________________________________
        //________________________________________________________________
        protected int currency;
        public int Currency
        {
            set { currency = value; }
            get { return currency; }
        }
        protected long costMonth;//властивості
        
        public long CostMonth
        {
            set
            {
                if (Currency == 1)
                    costMonth = value;
                else if (Currency == 2)
                    costMonth = value * 28;
                else
                    costMonth = value * 33;
                CostYear = CostMonth * 10;
            }
            
            get { return costMonth; }
        }
        protected long costYear;
        public long CostYear
        {
            set
            {
                costYear = value;
                CostFull = CostYear * 4;
            }
            get { return costYear; }
        }
        protected long costFull;
        public long CostFull
        {
            set
            {
                costFull = value;
            }
            get { return costFull; }
        }

    }
}
