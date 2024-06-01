using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. C# Stack<T> class is used to push and pop elements. It uses the concept of Stack that arranges elements in LIFO (Last In First Out) order. It can have duplicate elements. 
*/

namespace CSharpMisc
{
    public class StackExample
    {
        public void Run()
        {
            Stack<string> names = new Stack<string>();
            names.Push("Sonoo");
            names.Push("Peter");
            names.Push("James");
            names.Push("Ratan");
            names.Push("Irfan");

            foreach (string name in names)
            {
                Console.WriteLine(name);
            }

            Console.WriteLine("Peek element: " + names.Peek());
            Console.WriteLine("Pop: " + names.Pop());
            Console.WriteLine("After Pop, Peek element: " + names.Peek());

        }
        //public static void Main(string[] args)
        //{
        //    new StackExample().Run();   
        //}
    }
}
