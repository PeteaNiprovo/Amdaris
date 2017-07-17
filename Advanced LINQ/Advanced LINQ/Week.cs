using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntershipProject
{
    class Week 
    {
        public Day[] days;
        public Week()
        {
            days = new Day[TimeTable.daysAWeek];
            var temp = days[0].Permutate();
            var temp2 = days[0].CompareWith(days[1]);
            days[0].Swap(days[1]);
        }
        
        /*Add some restrictions later                                                                       <---restrictions*/
    }
}
