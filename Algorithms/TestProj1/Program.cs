using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestProj1
{
    public class Person
    {
        public string name;
        public Person[] Acq;
        public Person(string name, Person[] acq)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name", "sdsa");
            }

            this.name = name;
            this.Acq = acq;
        }

        public bool mystry(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name", "sdsa");
            }

            Stack<Person> mystack = new Stack<Person>();
            foreach(Person ac in this.Acq)
            {
                mystack.Push(ac);
            }

            do
            {
                var p = mystack.Pop();
                if(p.name.Equals(name))
                {
                    return true;
                }

                foreach(Person ac in p.Acq)
                {
                    mystack.Push(ac);
                }
            }
            while (mystack.Count >= 0);

            return false;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> a = new Stack<int>();
            a.Pop();
        }
    }
}
