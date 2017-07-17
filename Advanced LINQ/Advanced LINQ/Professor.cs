using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntershipProject
{
    class Professor
    {
        public List<Class> classList = new List<Class>();
        public Week week = new Week();
        public int Priority { get; private set; }
        public string Name { get; private set; }
        public string Subject { get; private set; }

        public Professor(int priority, string name, string subject)
        {
            Priority = priority;
            Name = name;
            Subject = subject;
        }
        public void AddClass(int name, int num)
        {
            classList.Add(new Class(name, num));
        }
        public void UpdatePriority(int newValue)
        {
            Priority = newValue;
        }

    }
}
