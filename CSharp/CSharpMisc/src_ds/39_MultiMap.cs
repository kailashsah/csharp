using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. MultiMap facade class.
        The facade here simplifies Dictionary and wraps it with MultiMap features. It is a Dictionary of Lists, inside a generic wrapper class.

        https://dotnetperls.com/multimap

*/

namespace CSharpMisc
{
    public class MultiMap<V>
    {
        Dictionary<string, List<V>> _dictionary = new Dictionary<string, List<V>>();

        public void Add(string key, V value)
        {
            // Add a key.
            List<V> list;
            if (this._dictionary.TryGetValue(key, out list))
            {
                list.Add(value);
            }
            else
            {
                list = new List<V>();
                list.Add(value);
                this._dictionary[key] = list;
            }
        }

        public IEnumerable<string> Keys
        {
            get
            {
                // Get all keys.
                return this._dictionary.Keys;
            }
        }

        public List<V> this[string key]
        {
            get
            {
                // Get list at a key.
                List<V> list;
                if (!this._dictionary.TryGetValue(key, out list))
                {
                    list = new List<V>();
                    this._dictionary[key] = list;
                }
                return list;
            }
        }

        public void Run()
        {
            // Create first MultiMap.
            var multiMap = new MultiMap<bool>();
            multiMap.Add("key2", false);
            multiMap.Add("key1", true);
            multiMap.Add("key1", false);
           

            foreach (string key in multiMap.Keys)
            {
                foreach (bool value in multiMap[key])
                {
                    Console.WriteLine("MULTIMAP: " + key + "=" + value);
                }
            }

            // Create second MultiMap.
            var multiMap2 = new MultiMap<string>();
            multiMap2.Add("animal", "cat");
            multiMap2.Add("animal", "dog");
            multiMap2.Add("human", "tom");
            multiMap2.Add("human", "tim");
            multiMap2.Add("mineral", "calcium");

            foreach (string key in multiMap2.Keys)
            {
                foreach (string value in multiMap2[key])
                {
                    Console.WriteLine("MULTIMAP2: " + key + "=" + value);
                }
            }

            /*
            
                MULTIMAP: key2=False    
                MULTIMAP: key1=True
                MULTIMAP: key1=False
                
                MULTIMAP2: animal=cat
                MULTIMAP2: animal=dog
                MULTIMAP2: human=tom
                MULTIMAP2: human=tim
                MULTIMAP2: mineral=calcium
             
            */
        }

    }//end of class
    public class RunMultiMap
    {
        //public static void Main(String[] args)
        //{
        //    new MultiMap<bool>().Run();
        //}
    }
}
