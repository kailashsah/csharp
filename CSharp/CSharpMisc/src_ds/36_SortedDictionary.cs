using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. SortedDictionary<>

    2. C# SortedList<TKey, TValue> vs SortedDictionary<TKey, TValue>
        
        SortedList<TKey, TValue> class uses less memory than SortedDictionary<TKey, TValue>. It is recommended to use SortedList<TKey, TValue> if you have to store and retrieve key/valye pairs. 

        The SortedDictionary<TKey, TValue> class is faster than SortedList<TKey, TValue> class if you perform insertion and removal for unsorted data.
    
    3. SortedDictionary<> implemented as Red-Black tree.
        insertion deletion is O(log n)
        SortedList - insertin deletion is O(n) . Supports index access .

*/

namespace CSharpMisc
{
    public class SortedDictionaryExample
    {
        public void Run()
        {
            SortedList<string, string> names = new SortedList<string, string>();
            names.Add("1", "Sonoo");
            names.Add("4", "Peter");
            names.Add("5", "James");
            names.Add("3", "Ratan");
            names.Add("2", "Irfan");
            foreach (KeyValuePair<string, string> kv in names)
            {
                Console.WriteLine(kv.Key + " " + kv.Value);
            }
            /*
                1 Sonoo
                2 Irfan
                3 Ratan
                4 Peter
                5 James
            */
        }
        //public static void Main(string[] args)
        //{
        //   new SortedDictionaryExample().Run(); 
        //}
    }
}
