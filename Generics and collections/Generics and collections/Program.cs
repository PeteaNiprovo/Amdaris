using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_and_collections
{
    class Program
    {
        public class Entity
        {
            public Guid Id { get; set; }

            public Entity()
            {
                Id = Guid.NewGuid();
            }
        }
        class Professor : Entity, IComparable<Professor>, IEquatable<Professor>
        {
            public enum Days { Monday = 1, Tuesday = 2, Wednesday = 4, Thursday = 8, Friday = 16 };
            public string Name { get; private set; }
            public string Subject { get; private set; }
            public int? InactiveDays { get; private set; }
            public int Priority { get; set; }         

            public Professor(int priority, string name, string subject = "No data", params Days[] days) : base()
            {
                Name = name;
                Priority = priority;
                Subject = subject;
                SetInactiveDays(days);
            }
            public void SetInactiveDays(params Days[] days)
            {
                if (InactiveDays.Equals(null))
                    InactiveDays = 0;
                foreach (Days item in days)
                {
                    InactiveDays |= (int)item;
                }
               
            }
            public int CompareTo(Professor other)
            {
                return Priority.CompareTo(other.Priority) ;
            }
            public bool Equals(Professor prof)
            {
                return prof != null && Name == prof.Name && Subject == prof.Subject && InactiveDays == prof.InactiveDays && Priority == prof.Priority;
            }
        }

        class Repository<T> where T : Entity
        {
            List<T> list = new List<T>();

            public void Add(T entity)
            {
                list.Add(entity);
            }
            
            public void Remove(T entity)
            {
                list.Remove(entity);
            }

            public T GetById(Guid id)
            {
                return list.Find(item => item.Id == id);            //empty otherwise?
            }
            
            public void Edit(Guid id, T newEntity)
            {
                list[list.FindIndex(item => item.Id == id)] = newEntity;            // or remove and add
            }
            public Guid FindId(T entity)
            {
                return list.Find(item => item.Equals(entity)).Id;
            }
        }

        static void Main(string[] args)
        {
            Professor p = new Professor(1, "sa", "asd", Professor.Days.Friday);
            Professor a = new Professor(1, "sa", "asd", Professor.Days.Friday);

            Repository<Professor> repository = new Repository<Professor>();
            repository.Add(p);
            repository.Add(a);
            Console.WriteLine(a.Id);
            
        }
    }
}
