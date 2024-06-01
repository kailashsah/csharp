using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. C# LinkedList<T> class uses the concept of linked list. It allows us to insert and delete elements fastly.
*/

namespace CSharpMisc
{
    public class LinkedListExample
    {
        public void Run()
        {
            // Create a list of strings  
            var names = new LinkedList<string>();
            names.AddLast("Sonoo Jaiswal");
            names.AddLast("Ankit");
            names.AddLast("Peter");
            names.AddLast("Irfan");
            names.AddFirst("John");//added to first index  

            // Iterate list element using foreach loop  
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }

        //public static void Main(string[] args)
        //{
        //    new LinkedListExample().Run();
        //}
    }
}
