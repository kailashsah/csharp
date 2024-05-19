using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Dictionary<K,V> 
    2. 

*/

namespace CSharpMisc
{
    public class DictionaryTest
    {

        public void Run()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            dict.Add("a", "b");
            dict.Add("c", "d");

            foreach(var ele in dict)
            {
                Console.WriteLine($"{ele.Key}, {ele.Value}");
            }

        }

        //static void Main(String[] args)
        //{
        //    new DictionaryTest().Run();

        //}
    }
}
