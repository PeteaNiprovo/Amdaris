using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntershipProject
{
    class Class
    {
        public int Name { get; private set; }
        public int NumberOfLessons { get; private set; }
        public Class(int name, int num)
        {
            Name = name;
            NumberOfLessons = num;
        }
    }
}
