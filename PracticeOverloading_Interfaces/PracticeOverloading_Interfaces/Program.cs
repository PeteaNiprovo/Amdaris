using System;

namespace PracticeOverloading_Interfaces
{
     class Angles
     {
          private int degrees;
          private int minutes;
          private int seconds;

          public int Seconds { get; set; }

          public Angles(int degrees, int minutes, int seconds)
          {
               Seconds = degrees * 360 + minutes * 60 + seconds;
               TransformSecondsToDegree();
          }

          public Angles(int seconds)
          {
               Seconds = seconds;
               TransformSecondsToDegree();
          }

          private void TransformSecondsToDegree()
          {
               degrees = Seconds / 360;
               minutes = Math.Abs((Seconds / 60) % 60);
               seconds = Math.Abs((Seconds % 60) % 60);
          }

          public static Angles operator + (Angles a, Angles b)
          {    
               return new Angles(a.Seconds + b.Seconds);
          }

          public static Angles operator - (Angles a, Angles b)
          {
               return new Angles(a.Seconds - b.Seconds);
          }

          public static Angles operator * (Angles a, int num)
          {
               return new Angles(a.Seconds * Math.Abs(num));
          }

          public static Angles operator / (Angles a, int num)
          {
               return new Angles(a.Seconds / Math.Abs(num));
          }

          public static bool operator == (Angles a, Angles b)
          {
               return a.Seconds == b.Seconds;
          }

          public static bool operator != (Angles a, Angles b)
          {
               return !(a == b);
          }

          public void Show()
          {
               Console.WriteLine($"{degrees}°{minutes}'{seconds}\"");
          }
     }
     class Program
     {
          static void Main(string[] args)
          {
               Angles a = new Angles(-10,-5,-10);
               Angles b = new Angles(0, 0 ,55);
               a.Show();
               b.Show();
               (a + b).Show();
               Angles c = (a * 10);
               c.Show();
               Console.WriteLine(a==b);
               Console.WriteLine(a!=b);
          }
     }
}
