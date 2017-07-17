using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Functional_Paradigm
{
    class Collection : IEnumerator<int>, IEnumerable<int>
    {
        private int size = 1;
        private int lastIndex = -1;
        private int position = -1;
        private int[] array;

        public Collection(int s)
        {
            array = new int[size = s];
        }
        public Collection()
        {
            array = new int[1];
        }
        public int Current => array[position];
        object IEnumerator.Current => throw new NotImplementedException();
        public void Add(int data)
        {
            lastIndex++;
            if (lastIndex >= size)
                Array.Resize(ref array, ++size);
            array[lastIndex] = data;
        }
        public void Set(int index, int data)
        {
            if (index >= 0 && index < size)
                array[lastIndex = index] = data;
        }
        public int? Get(int index)
        {
            if (index >= 0 && index < size)
                return array[index];
            return null;
        }
        public void Dispose()
        {
            position = -1;
        }
        public bool MoveNext()
        {
            position++;
            return (position < size);
        }
        public void Reset()
        {
            position = -1;
        }
        public IEnumerator<int> GetEnumerator()
        {
            return this;
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }

    static class Extensions
    {
        public static bool IsEven(this int data)
        {
            return (data % 2 == 0) ? true : false; 
        }

        public static bool IsOdd(this int data)
        {
            return (data % 2 != 0) ? true : false;
        }

        public static bool IsPositive(this int data)
        {
            return (data > 0) ? true : false;
        }
        public static bool IsNegative(this int data)
        {
            return (data < 0) ? true : false;
        }

    }

    class DelegateExample
    {
        public delegate bool Filter(int value);
        public bool IsEven(int data)
        {
            if (data % 2 == 0)
                return true;
            return false;
        }
        public bool IsOdd(int data)
        {
            if (IsEven(data) == true) return false;
            return true;
        }
        public bool IsPositive(int data)
        {
            if (data > 0) return true;
            return false;
        }
        public bool IsNegative(int data)
        {
            if (data < 0) return true;
            return false;
        }
        public void Show(int data, Filter filter)
        {
            if (filter(data))
                Console.WriteLine($"{data} is {filter.Method.Name}");
        }
        public void All(Collection col)
        {
            foreach (var item in col)
            {
                Show(item, IsEven);
                Show(item, IsOdd);
                Show(item, IsPositive);
                Show(item, IsNegative);

                Filter del = delegate (int v) { if (v == 0) return true;
                    else return false; };
            }

        }
    }

    class AnonymousFunctionsExample
    {
        public delegate void Filter(int value);
        public void Show(Collection collection)
        {
            Filter filter = delegate (int data)
            {
                if (data % 2 == 0)
                {
                    Console.WriteLine($"{data} Is Even");
                }
                else
                {
                    Console.WriteLine($"{data} Is Odd");
                }

            };

            filter += delegate (int data)
            {
                if (data > 0)
                {
                    Console.WriteLine($"{data}  Is positive");
                }
                else
                {
                    Console.WriteLine($"{data} Is negative or zero");
                }
            };
            foreach (var item in collection)
            {
                filter(item);
            }
        }
    }

    class LamdaExpressionsExample
    {
        public delegate void Filter(int data);
        public void Show(Collection collection)
        {
            Filter filter = a => { if (a > 0) Console.WriteLine($"{a} is positive");  
                                    else Console.WriteLine($"{a} is negative or zero "); } ;
            filter += a => { if(a % 2 == 0)
                    Console.WriteLine($"{a} is even");
                else
                    Console.WriteLine($"{a} is odd");};

            foreach (var item in collection)
            {
                filter(item);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Collection col = new Collection
            {
                10,
                21,
                30,
                -31,
                -51
            };
            //DelegateExample a = new DelegateExample();
            //a.All(col);

            //AnonymousFunctionsExample anon = new AnonymousFunctionsExample();
            //anon.Show(col);

            //LamdaExpressionsExample lambda = new LamdaExpressionsExample();
            //lambda.Show(col);

            //Console.WriteLine(((int)(col.Get(0))).IsEven());

            var list = col. Where(a => a < 0)
                            .Select(a => a)
                            .ToArray();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }
        }
    }
}
