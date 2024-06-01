using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Dictionary<K,V> - unordered.
    2. In Dictionary, key must be unique. Duplicate keys are not allowed if you try to use duplicate key then compiler will throw an exception.
        In Dictionary, the key cannot be null, but value can be.
    3. basic operation
        Add Elements
        Access Elements
        search elements/ sort elements
        Change Elements
        Remove Elements

*/

namespace CSharpMisc
{
    public class DictionaryTest
    {

        public void Run()
        {
            Dictionary<string, string> dict = new Dictionary<string, string>();
            //1. Add()
            dict.Add("a", "b");
            dict.Add("c", "d");

            //2. print
            foreach(var ele in dict)
            {
                Console.WriteLine($"{ele.Key}, {ele.Value}");
            }

            foreach (KeyValuePair<string, string> ele in dict)
            {
                Console.WriteLine($"{ele.Key}, {ele.Value}");
            }

            //3. using index - access value
            Console.WriteLine(dict["a"]); //b
                                          //Console.WriteLine(dict["d"]); //exception - The given key 'd' was not present in the dictionary.'

            //4. remove all elements
            //dict.Clear();

            //5. remove single element
            //dict.Remove("a"); // c,d is left 


            //change the value
            dict["a"] = "bb";

            //6. ContainsKey() and ConstainsValue()
            if (dict.ContainsKey("a"))
                Console.WriteLine("a is present");

            if (dict.ContainsValue("b"))
                Console.WriteLine("b as value is present");
        }

        //static void Main(String[] args)
        //{
        //    new DictionaryTest().Run();

        //}
    }//class
}
