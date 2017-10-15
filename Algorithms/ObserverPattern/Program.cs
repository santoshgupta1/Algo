using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class ObserverPattern
    {
        public class Simulator : IEnumerable
        {
            string[] moves = { "5", "6", "1", "3", "7" };

            public IEnumerator GetEnumerator()
            {
                foreach (var item in moves)
                {
                    yield return item;
                }
            }
        }
        public class Subject
        {
            public delegate void CallBackFunc(string s);
            public event CallBackFunc Notify;
            Simulator simulator = new Simulator();
            const int speed = 200;
            public string SubjectState { get; set; }
            public void Go()
            {
                new Thread(new ThreadStart(Run)).Start();
            }

            public void Run()
            {
                foreach (string s in simulator)
                {
                    Console.WriteLine("Subject: " + s);
                    SubjectState = s;
                    Notify(s);
                    Thread.Sleep(speed);
                }
            }
        }
        
        interface IObserver
        {
            void Update(string state);
        }

        public class Observer : IObserver
        {
            string name;
            Subject subject;
            string state;
            string gap;

            public Observer(Subject subject, string name, string gap)
            {
                this.subject = subject;
                this.name = name;
                this.gap = gap;
                subject.Notify += Update;
            }
            public void Update(string subjectState)
            {
                state = subjectState;
                Console.WriteLine(gap + name + ": " + state);
            }
        }

        static void Main1(string[] args)
        {
            Subject subject = new Subject();
            Observer observer1 = new Observer(subject, "Center", "\t\t");
            Observer observer2 = new Observer(subject, "Right", "\t\t\t\t");
            subject.Go();
            Console.ReadLine();
        }
    }
}
