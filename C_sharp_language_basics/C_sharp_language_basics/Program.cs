using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_language_basics
{
    class Class
    {
        public string Name { get; private set; }
        public int NumberOfLessons { get; set; }
        public Class(string name, int num)
        {
            Name = name;
            NumberOfLessons = num;
        }
    }

    class Professor 
    {
        public List<Class> classList = new List<Class>();
        public int Priority { get; set; }
        public string Name { get; private set; }
        public string Subject { get; private set; }

        public Professor(int priority, string name, string subject)
        {
            Priority = priority;
            Name = name;
            Subject = subject;
        }
        public void AddClass(string name, int num)
        {
            classList.Add(new Class(name,num));
        }
        public void UpdatePriority(int newValue)
        {
            Priority = newValue;
        }
        public void UpdateClass(ref Class _class, int _newNumberOfLessons)
        {
            _class.NumberOfLessons = _newNumberOfLessons;
        }

    }

    class TimeTable
    {
        public static string[] classNames;
        public static int TotalDays { get; private set; }
        public List<Professor> professorList = new List<Professor>();

        public TimeTable(int totalDays)
        {
            TotalDays = totalDays;
            SetClassNames(out classNames);
        }
        public void SetClassNames(out string[] classNames)
        {        
            try
            {
                Console.WriteLine("Write bellow the names of the classes...");
                classNames = Console.ReadLine().Split();
                Console.WriteLine(classNames[0]);
            }
            catch(ArgumentOutOfRangeException)
            {
                throw new ArgumentOutOfRangeException();
            }
        }
        public void AddProfessor(string name, string subject, int priority = 100)
        {
            professorList.Add(new Professor(priority, name, subject));
        }
        public static bool IsADay(int day)
        {
            if (day > 0 && day <= TotalDays) return true;
            return false;
        }
    }

    class Test
    {
        static void Main(string[] args)
        {
            TimeTable timetable = new TimeTable(5);
            timetable.AddProfessor("Matei", "Mate");
            timetable.AddProfessor("Maria", "Chimie");
            timetable.professorList[0].AddClass(TimeTable.classNames[0], 2);;

            object o = timetable.professorList[0];
            Console.WriteLine(((Professor)o).Name);
        }
    }
}
