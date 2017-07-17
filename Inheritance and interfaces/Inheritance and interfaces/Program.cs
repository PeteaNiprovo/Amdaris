using System;
using static System.Console;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_and_interfaces
{
    class Animal
    {
        public void mommy()
        {
            Console.WriteLine("In the animal class");
        }
        public virtual void move()
        {
            Console.WriteLine("In the animal class");
        }
    }

    class Dog : Animal
    {
        public int war { get; set; }
        public override sealed void move()
        {
            Console.WriteLine("In the dog class");
        }

        public virtual void a()
        {
            Console.WriteLine("In the dog class");
        }
    }

    class A : Dog
    {
        public override void a()
        {
            Console.WriteLine("In the A class");
        }
        public  void move()
        {
            Console.WriteLine("In the A class");
        }

    }

    class B
    {
        public static int number = 0;

        public static void a()
        {
            WriteLine("I am in B");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new A();
            WriteLine(a.war);

            B b = new B();
            B.a();
        }
       }
}
