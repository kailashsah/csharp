using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            
            //2. using collection initializer  
            // List<string> languages = new List<string>() { "Python", "Java" };//in placeinitializer;


            //3. access randomly
            Console.WriteLine(names[1]); //Ankit
            
            //4. Iterate list element using foreach loop  
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }

            //5. insert 
            names[1] = "Aankit";

            //6. remove
            names.Remove("Aankit");
            names.RemoveAt(1);
            names.RemoveAll((x) => x.StartsWith('A'));
            names.Clear();
        }//Run()

        //public static void Main(string[] args)
        //{
        //    new ListExample().Run();
        //}
    }
}
