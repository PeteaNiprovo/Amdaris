#define CONDITION

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exception_handling_and_debugging
{

    [Serializable]
    public class _ExceptionOfBoundaries : Exception
    {
        public _ExceptionOfBoundaries() { }
        public _ExceptionOfBoundaries(string message) : base(message) { }
        public _ExceptionOfBoundaries(string message, Exception inner) : base(message, inner) { }
        protected _ExceptionOfBoundaries(   System.Runtime.Serialization.SerializationInfo info,
                                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }


    [Serializable]
    public class _ExceptionOfLength : Exception
    {
        public _ExceptionOfLength() { }
        public _ExceptionOfLength(string message) : base(message) { }
        public _ExceptionOfLength(string message, Exception inner) : base(message, inner) { }
        protected _ExceptionOfLength(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
    class Collection<T>
    {
        public int MaxSize { get; private set; }
        private T[] collection;
        private int lastIndex = -1;
        public Collection(int size)
        {
            collection = new T[MaxSize = size];
        }

        public Collection()
        {
            collection = new T[MaxSize];
        }

        public void Set(T value, int index)
        {
            if (index < MaxSize && index >= 0)
            {
                collection[index] = value;
                lastIndex = index;
            }
            else throw new _ExceptionOfBoundaries();
           
        }

        public T Get(int index)
        {
            if (index < MaxSize && index >= 0)
            {
                return collection[index];
            }
            else throw new _ExceptionOfBoundaries();
        }

        public void Swap(int index1, int index2)
        {
            if (index1 < MaxSize && index2 < MaxSize && index1 >= 0 && index2 >= 0)
            {
                var temp = collection[index1];
                collection[index1] = collection[index2];
                collection[index2] = temp;
            }
            else throw new _ExceptionOfBoundaries();
        }

        public void Add(T value)
        {
            if (lastIndex >= MaxSize) throw new _ExceptionOfLength();
            collection[++lastIndex] = value;
        }

        public void Resize()
        {
            Array.Resize(ref collection, ++MaxSize);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Collection<int> col = new Collection<int>();

#if CONDITION
            Console.WriteLine("I have used conditional compilation!");
#endif 
            try
            {
                col.Set(20, 5);
                col.Add(100);
            }
            catch (_ExceptionOfBoundaries)
            {
                throw new _ExceptionOfBoundaries("I have been rethrown");
            }
            catch (_ExceptionOfLength)
            {
                col.Resize();
            }
            finally
            {
                col.Add(100);
            }
        }
    }
}
