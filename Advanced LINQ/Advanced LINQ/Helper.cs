using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntershipProject
{
    static class Helper
    {
        /*LINQ              <<----Intersect,Count*/
        public static bool CompareWith(this Day day, Day other)
        {
            if (day.sessions.Length != other.sessions.Length) return false;

            return day.sessions.Intersect(other.sessions).Count() == day.sessions.Length;
        }


        public static Day Permutate(this Day day)
        {
            List<int[]> list = new List<int[]>();
            list.Add(day.sessions);

            /*Add here the condition of early exit*/

            for (int i = 0; i < list[0].Length - 1; i++)      //pentru fiecare coloana
            {
                int lungime = list.Count;
                for (int k = 0; k < lungime; k++)             //pentru fiecare element din lista
                {
                    for (int j = i + 1; j < list[0].Length; j++)
                    {
                        list.Add(Swap<int>(list[k], i, j));
                        
                        /*Add here an event that anounce other function to find out if the solution is accepted*/
                    }
                }
            }
            return day;   // for example
        }
        public static T[] Swap<T>(T[] set, int Istart, int Ifinish)
        {
            T[] temp = new T[set.Length];
            set.CopyTo(temp,0);

            var t = temp[Istart];
            temp[Istart] = temp[Ifinish];
            temp[Ifinish] = t;

            return temp;
        }
        public static void Swap(this Day day , Day other)
        {
            if (day.sessions.Length == other.sessions.Length)
            {
                for (int i = 0; i < day.sessions.Length; i++)
                {
                    var temp = day.sessions[i];
                    day.sessions[i] = other.sessions[i];
                    other.sessions[i] = temp;
                }
            }
        }

        //public static bool CheckInvariance(this Professor professor, Day day)
        //{

        //}

    }
}
