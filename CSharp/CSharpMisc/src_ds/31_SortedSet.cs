using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. C# SortedSet class can be used to store, remove or view elements. It maintains ascending order and does not store duplicate elements. It is suggested to use SortedSet class if you have to store unique elements and maintain ascending order.
*/

namespace CSharpMisc
{
    public class SortedSetExample
    {
        public void Run()
        {
            // Create a set of strings  
            var names = new SortedSet<string>();
            names.Add("Sonoo");
            names.Add("Ankit");
            names.Add("Peter");
            names.Add("Irfan");
            names.Add("Ankit");//will not be added  

            // Iterate SortedSet elements using foreach loop  
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
        //public static void Main(string[] args)
        //{
        //    new SortedSetExample().Run();
        //}
    }
}
