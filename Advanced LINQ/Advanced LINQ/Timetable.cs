using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntershipProject
{
    class TimeTable 
    {
        public static int[] classNames;
        public static int DayLength { get; private set; }
        public static int daysAWeek = 5;
        public List<Professor> professorList = new List<Professor>();

        public TimeTable(int daylength)
        {
            DayLength = daylength;
        }

        public void AddProfessor(string name, string subject, int priority = 100)
        {
            professorList.Add(new Professor(priority, name, subject));
        }
        

        //LINQ    --from,select,distinct,ToArray, orderby
        public void FindAllClasses()            
        {
            var list = from professor in professorList             
                       from cl in professor.classList
                       orderby cl.Name
                       select cl.Name;

            classNames = list.Distinct().ToArray();
            foreach (var item in classNames)
            {
                Console.WriteLine( item);
            }
        }

        static void Main(string[] args)
        {
            TimeTable timetable = new TimeTable(7);
            timetable.AddProfessor("Matei", "Mate");
            timetable.AddProfessor("Maria", "Chimie");
            timetable.AddProfessor("Andrei", "Biologie");
            timetable.professorList[0].AddClass(5, 2); ;

            timetable.professorList[0].AddClass(1, 2);
            timetable.professorList[0].AddClass(2, 3);
            timetable.professorList[0].AddClass(3, 4);
            timetable.professorList[0].AddClass(4, 3);

            timetable.professorList[1].AddClass(2, 2);
            timetable.professorList[1].AddClass(4, 2);
            timetable.professorList[1].AddClass(6, 2);
            timetable.professorList[1].AddClass(7, 2);

            timetable.professorList[2].AddClass(2, 5);
            timetable.professorList[2].AddClass(4, 2);
            timetable.professorList[2].AddClass(8, 3);

            timetable.FindAllClasses();
        }
    }

}
