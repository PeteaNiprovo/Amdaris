using System;
namespace Airport
{
    using System.Collections;

    public delegate void Communication(object sender, EventArgs e);

    public class Airplane
    {
        public event Communication Changed;
        public Guid id = Guid.NewGuid();
        public bool action;

        protected virtual void OnChanged(EventArgs e)
        {
            Changed?.Invoke(this, e);
        }

        public Airplane Land()
        {
            action = true;
            OnChanged(EventArgs.Empty);
            return this;
        }

        public Airplane TakeOff()
        {
            action = false;
            OnChanged(EventArgs.Empty);
            return this;
        }
    }

    class Dispatcher
    {
        private  ArrayList airplaneList = new ArrayList();

        public Dispatcher(ArrayList list)
        {
            foreach (var item in list)
            {
                (item as Airplane).Changed += new Communication(AirplaneAction);
            }
            
        }

        public void Add(Airplane airplane)
        {
            airplaneList.Add(airplane);
            (airplaneList[airplaneList.Count - 1] as Airplane).Changed += new Communication(AirplaneAction);
        }

        private void AirplaneAction(object sender, EventArgs e)
        {
            if ((sender as Airplane).action == true)
            {
                airplaneList.Add(sender);
                Console.WriteLine($"Airplane {(sender as Airplane).id } has landed");
            }
            else
            {
                Console.WriteLine($"Airplane {(sender as Airplane).id } has took off");
                airplaneList.Remove(sender);
            }
        }

        public void Detach()
        {
            foreach (var item in airplaneList)
            {
                (item as Airplane).Changed -= new Communication(AirplaneAction);
            }
            airplaneList.Clear();
        }
    }

    class Test
    {
        public static void Main()
        {
            Airplane a = new Airplane();
            Airplane b = new Airplane();
            Airplane c = new Airplane();

            ArrayList list = new ArrayList { a,b,c};
            Dispatcher dispatcher = new Dispatcher(list);

            
            a.Land();
            b.Land();
            a.TakeOff();

            Airplane d = new Airplane();
            dispatcher.Add(d);

            d.Land();

            dispatcher.Detach();
        }
    }
}