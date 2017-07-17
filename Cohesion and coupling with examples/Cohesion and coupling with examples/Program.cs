using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cohesion_and_coupling_with_examples
{
    class Coincidental
    {
        private int x = 25;
        private string str = "Initial form";

        public string Reverse(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public void Work()
        {
            Console.WriteLine();
            Console.WriteLine(Reverse(str));
            Console.WriteLine(Math.Sin(x));
            Console.WriteLine(int.Parse("1"));
        }
    }

    class Logical
    {
        private int distance = 0;
        public void GoByCar()
        {
            distance += 10;
        }

        public void GoByTrain()
        {
            distance *= 2;
        }

        public void GoByAirplaine()
        {
            distance *= 10;
        }

        public void GoByBoat()
        {
            distance++;
        }

        public void Go()
        {
            GoByCar();
            GoByTrain();
            GoByTrain();
            GoByAirplaine();
        }
    }

    class Temporal
    {
        public void Jump() { }
        public void Run() { }
        public void Laugh() { }
        public void PlayChess() { }
        public void Entertain()             //the order of calling inner methods does not matter
        {
            Jump();
            Run();
            Laugh();
            PlayChess();
        }
    }

    class Procedural
    {
        public void WalkToCar(Person person)
        {
            person.xposition++;
            person.ypositon--;
        }

        public void EnterTheCar(Person person, Car car)
        {
            car.openedDoor = true;
            person.satDown = true;
            car.openedDoor = false;
        }

        public void SwitchOnTheEngine(Car car)
        {
            car.engine = true;
        }

        public void Drive(Person person, Car car)
        {
            car.xposition++;
            car.yposition++;
            car.fuel -= 0.1;
            person.xposition++;
            person.yposition++;
        }

        public void GoToWork()  // the order of calling the methods does matter
        {
            WalkToCar(person);
            EnterTheCar(person, car);
            SwitchOnTheEngine(car);
            Drive(person, car);
        }
    }

    class Communicational
    {
        public  string GetByID(int index) { return ""; }
        public  string GetByLength(int length) { return ""; }
        public  string GetByStartingLetter(char letter) { return ""; }
        public  string GetByPosition(int offset) { return ""; }
    }

    class Sequential
    {
       
    }

    class Functional
    {
        public float CalculateTheRootForFunction1() { return 0.1F; }
        public float CalculateTheRootForFunction2() { return 0.2F; }
        public float GetTheDistanceBetweenRoots(float root1, float root2) { return 0.1F; }

        public void Do()
        {
            var distance = GetTheDistanceBetweenRoots(CalculateTheRootForFunction1(), CalculateTheRootForFunction2());
            // to be written to console 
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
        }
    }
}
