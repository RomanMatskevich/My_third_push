using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLibrary
{
    public class Result
    {
        protected string Subject;
        public string subject { set { Subject = value; } get { return Subject; } }
        protected string Teacher;
        public string teacher { set { Teacher = value; } get { return Teacher; } }
        protected int Points;
        public int points { set { Points = value; } get { return Points; } }
        public Result()
        {
            Subject = "aa";
            Teacher = "bb";
            Points = 100;

        }

        public Result(string subject, string teacher, int points)
        {
            Subject = subject;
            Teacher = teacher;
            Points = points;
        }
        public Result(Result previuskonres)
        {
            Subject = previuskonres.Subject;
            Teacher = previuskonres.Teacher;
            Points = previuskonres.Points;
        }

    }
}
