using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpMisc
{

    [Serializable]
    public class Base
    {
        private decimal a = 10m; // 2 bytes
        private decimal b = 10m;
        private string str = "get the object size";
    }

    [Serializable]
    public class ObjectSize : Base
    {
        public int i = 40; // 4 bytes
        private int e = 50;
        protected int f = 60;
        ~ObjectSize()
        {
            Console.Write("Dtor called: ", GetType().Name);
            PrintSize();
        }

        public void PrintSize()
        {
            long size = 0;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, this);
                size = s.Length; // in bytes
            }
            Console.WriteLine("ObjectSize class size (bytes) is :" + size); // 207
        }

        public static void RunObjectSize()
        {
            // it prints size at the time of dtor
            Thread thSize = new Thread(() =>
            {
                new ObjectSize();
                ObjectSize obj = new ObjectSize();
                obj.PrintSize();
                obj = null;
            });
            thSize.Start();
            
            //end thread
            Console.WriteLine("Type 'exit' for not calling GC");
            while (true)
            {
                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();
                string read = Console.ReadLine();
                if (read == "exit")
                    break;
            }
        }

    } //ObjectSize
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        ObjectSize.RunObjectSize(); //ObjectSize class size is :207

    //        Console.WriteLine("program ends");
    //    }
    //}

}
