using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. C# List<T> class is used to store and fetch elements. It is like a vector<> in c++
*/

namespace CSharpMisc
{
    public class ListExample
    {
        public void Run() { 
            
            //1. Create a list of strings  
            var names = new List<string>();
            names.Add("Sonoo Jaiswal");
            names.Add("Ankit");
            names.Add("Peter");
            names.Add("Irfan");

            // Iterate list element using foreach loop  
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            //2. Create a list of strings using collection initializer  
            var namess = new List<string>() { "Sonoo", "Vimal", "Ratan", "Love" };

            // Iterate through the list.  
            foreach (var name in namess)
            {
                Console.WriteLine(name);
            }
        }

        //public static void Main(string[] args)
        //{
        //    new ListExample().Run();
        //}
    }
}
