using System;
using System.Collections.Generic;

namespace CSLab3Server
{
    internal class Program
    {
        private static Object syncObject = new Object();
        private static void Write()
        {
            lock (syncObject)
            {
                Console.WriteLine("test");
            }
        }
        static void Main(string[] args)
        {
            lock (syncObject)
            {
                Write();
            }

            Console.ReadLine();
        }
    }

    class A
    {
        int count = 0;

        public void Go()
        {
            List<Action> actions = new List<Action>();
            for (count = 0; count < 10; count++)
            {
                actions.Add(() => Console.WriteLine(count));
            }
            foreach (var action in actions)
            {
                action();
            }

        }
        public virtual void Foo()
        {
            Console.Write("Class A");
        }
    }
    class B : A
    {
        public override void Foo()
        {
            Console.Write("Class B");
        }
    }
}
