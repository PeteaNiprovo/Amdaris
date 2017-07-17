using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Schedule
{
    class Professor
    {
         static private int classTotalNumber;
         private int[] classList;
         private bool[] dayDependency;
         private int[,] hourDependency;

        public Professor(int num)
        {
            classTotalNumber = num;
            classList = new int[num];
            hourDependency = new int[2, num];
            dayDependency = new bool[num];
            for (int i = 0; i < num; i++)
            {
                classList[i] = 0;
                hourDependency[0, i] = 0;
                hourDependency[1, i] = 0;
                dayDependency[i] = false;
            }
        }

        public void AddDayDependecy(int day)
        {
            if (day > 0 && day <= classTotalNumber)
                dayDependency[day - 1] = true;
        }

        public void AddHourDependency(int day, int start, int finish)
        {
            if (day > 0 && day <= classTotalNumber && dayDependency[day - 1] == true)
            {
                hourDependency[0, day - 1] = start;
                hourDependency[1, day - 1] = finish;
            }
        }

        public void AddClassList(int day, int value)
        {
            if (day > 0 && day <= classTotalNumber)
            {
                classList[day - 1] = value;
            }
        }

        public void DecrementClass(int day)
        {
            if (day > 0 && day <= classTotalNumber && classList[day - 1] > 0)
                classList[day - 1]--;
        }

        public int GetAvailableClass()
        {
            for (int i = 0; i < classTotalNumber; i++)
                if (classList[i] != 0) return i + 1;
            return 0;
        }

        public int GetAvailableClass(int currentDay)
        {
            if (currentDay > 0 && currentDay <= classTotalNumber)
                for (int i = currentDay; i < classTotalNumber; i++)
                    if (classList[i] != 0) return i + 1;
            return 0;
        }

        public bool CheckDayDependecy(int day)
        {
            if (day > 0 && day <= classTotalNumber)
                return dayDependency[day - 1];
            else return false;
        }

        public int CheckStartHourDependency(int day)
        {
            if (day > 0 && day <= classTotalNumber)
                return hourDependency[0, day - 1];
            else return 0;                          //posibile erori
        }

        public int CheckFinishHourDependency(int day)
        {
            if (day > 0 && day <= classTotalNumber)
                return hourDependency[1, day - 1];
            else return 0;
        }

        public void ShowclassList()
        {
            for (int i = 0; i < classTotalNumber; i++)
                Console.Write(classList[i] + " ");
            Console.WriteLine();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Professor a = new Professor(5);
            Professor b = new Professor(5);
            Professor c = new Professor(5);
            StreamReader reader;
            int iterator = 0;
            reader = new StreamReader(@"D:\VS_projects\Schedule\Schedule\list.txt");
            while (!reader.EndOfStream)
            {
                iterator++;
                char temp = (char)reader.Read();
                Console.Write(temp);
                if (Convert.ToInt32(temp) >= 48 && Convert.ToInt32(temp) < 58)
                    c.AddClassList(iterator/2%6 + 2 , (int)Char.GetNumericValue(temp));
            }
            reader.Close();
            reader.Dispose();

            Console.WriteLine("\n");
           
            a.ShowclassList();
            b.ShowclassList();
            c.ShowclassList();
        }
    }
}
