using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. C# Queue<T> class is used to Enqueue and Dequeue elements. It uses the concept of Queue that arranges elements in FIFO (First In First Out) order. It can have duplicate elements. 
*/

namespace CSharpMisc
{
    public class QueueExample
    {
        public void Run()
        {
            Queue<string> names = new Queue<string>();
            names.Enqueue("Sonoo");
            names.Enqueue("Peter");
            names.Enqueue("James");
            names.Enqueue("Ratan");
            names.Enqueue("Irfan");

            //1.
            foreach (string name in names)
            {
                Console.WriteLine(name);
            }
            //2.
            Console.WriteLine( names.Contains("Ratan") );//True

            //3.
            Console.WriteLine("Peek element: " + names.Peek());
            Console.WriteLine("Dequeue: " + names.Dequeue());
            Console.WriteLine("After Dequeue, Peek element: " + names.Peek());
            /*
                Sonoo 
                Peter
                James
                Ratan
                Irfan
                Peek element: Sonoo
                Dequeue: Sonoo
                After Dequeue, Peek element: Peter
             */
        }

        //public static void Main(string[] args)
        //{
        //    new QueueExample().Run();
        //}
    }
}
