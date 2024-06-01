using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. C# HashSet class can be used to store, remove or view elements. It does not store duplicate elements. It is suggested to use HashSet class if you have to store only unique elements.
*/

namespace CSharpMisc
{

    public class HashSetExample
    {
        public void Run()
        {
            // Create a set of strings  
            var names = new HashSet<string>();
            names.Add("Sonoo");
            names.Add("Ankit");
            names.Add("Peter");
            names.Add("Irfan");
            names.Add("Ankit");//will not be added  

            // Iterate HashSet elements using foreach loop  
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
        }
        //public static void Main(string[] args)
        //{
        //    new HashSetExample().Run();
        //}
    }
}
