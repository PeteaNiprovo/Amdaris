using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Classes_in_csharp
{
    public interface IProprieties
    {
        double Area();
        double Perimeter();
    }

    class Line : IProprieties
    {
        public double Length { get; set; }
        public Line(double length)
        {
            this.Length = length;
        }
        public Line()
        {
            this.Length = 1;
        }

        public double Area()
        {
            return Length;
        }
        public double Perimeter()
        {
            return Length;
        }
    }

    class Circle : IProprieties
    {
        public double Radius { get; set; }

        public Circle(double radius)
        {
            this.Radius = radius;
        }
        public Circle()
        {
            this.Radius = 1;
        }

        public double Area()
        {
            return Math.Pow(Radius,2) * Math.PI;
        }

        public double Perimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }

    class Rectangle : IProprieties
    {
        private double length;
        private double width;

        public double Length
        {
            get { return length; }
            set
            {
                if(value > 0)
                {
                    if (value < width)
                    {
                        length = width;
                        width = value;
                    }
                    else length = value;
                }
            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                if(value > 0)
                {
                    if (value > length)
                    {
                        width = length;
                        length = value;
                    }
                    else width = value;
                }
            }
        }

        public Rectangle(double width, double length)
        {
            this.Length = length;
            this.Width = width;
        }

        public Rectangle (double side)
        {
            this.Length = side;
            this.Width = side;
        }
        public virtual double Area()
        {
            return Length * Width;
        }
        public virtual double Perimeter()
        {
            return 2 * (Length + Width);
        }
    }

    class Cube : Rectangle
    {
        public Cube(double side) : base(side,side)
        {   }
        public Cube() : base(1,1)
        {   }

        public override double Area()
        {
            return 6 * base.Area();
        }

        public override double Perimeter()
        {
            return 3*base.Perimeter();
        }

        public static double Perimeter(double side)
        {
            return 12 * side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Line l = new Line(10);
            Console.WriteLine($"Area : {l.Area()}   Perimeter : {l.Perimeter() }");

            Circle c = new Circle(10);
            Console.WriteLine($"Area : {c.Area()}   Perimeter : {c.Perimeter()}");

            Rectangle r = new Rectangle(10, 10);                                            //overloaded for square
            Console.WriteLine($"Area : {r.Area()}   Perimeter : {r.Perimeter()}");

            Cube cc = new Cube(10);
            Console.WriteLine($"Area : {cc.Area()}   Perimeter : {cc.Perimeter()}");

        }
    }
}
