using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComparableCar
{
    class SpeedComparer : IComparer
    {
        int IComparer.Compare(object x, object y)
        {
            Car t1 = (Car)x;
            Car t2 = (Car)y;
            if (t1.Speed > t2.Speed) return 1;
            else if (t1.Speed < t2.Speed) return -1;
            else return 0;
        }
    }
}
