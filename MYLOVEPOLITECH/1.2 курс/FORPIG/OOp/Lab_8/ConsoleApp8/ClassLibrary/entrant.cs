using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Entrant : Person
    {
        protected int MarkZNO;
        public int markzno
        {
            set { MarkZNO = value; }
            get { return MarkZNO; }
        }
        protected int MarkCertificate;
        public int markcertificate
        {
            set { MarkCertificate = value; }
            get { return MarkCertificate; }
        }
        protected string SchoolName;
        public string schoolname
        {
            set { SchoolName = value; }
            get { return SchoolName; }
        }
        public void entrankonst(int mark,int certificate,string schoolname)
        {
            MarkZNO = mark;
            MarkCertificate = certificate;
            SchoolName = schoolname;
        }
        public void entrantkonst(int mark, int certificate)
        {
            MarkZNO = mark;
            MarkCertificate = certificate;
        }
        public Entrant()
        {
            MarkZNO = 200;
            MarkCertificate = 11;
            SchoolName = "ZMGG#23";
        }
       
        public override void ShowInfo()
        {
            //base.ShowInfo();
            Console.WriteLine($" Ім'я {Name}\nПрізвище{Surname}\nДата народження{Date}Оцінка ЗНО {MarkZNO}\nОцінка в школі{MarkCertificate}\nНазва школи{SchoolName}");
        }

    }
}
