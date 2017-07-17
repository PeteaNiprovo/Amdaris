using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace _2
{

    class Program
    {
        delegate bool bo(string x, int y);
        static void Main(string[] args)
        {
            bo func = (string x, int y) => x.Length > y;
            Console.WriteLine(func("io", 2)); //j = 25  
        }

    }
}
