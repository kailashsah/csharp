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
        private decimal a = 10m;
        private decimal b = 10m;
        private string str = "get the object size";
    }

    [Serializable]
    public class ObjectSize : Base
    {
        public int i = 40;
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
                size = s.Length;
            }
            Console.WriteLine("ObjectSize class size is :" + size);
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


    class DestructorDemo
    {
        public DestructorDemo()
        {
            Console.WriteLine("Constructor Object Created");
        }
        ~DestructorDemo()
        {
            Console.WriteLine($"Object {GetType().Name} is Destroyed");
        }
        public static void RunDestructorDemo()
        {
            DestructorDemo[] obj1 = new DestructorDemo[10];
            Thread th = new Thread(() =>
            {
                //DestructorDemo[] obj1 = new DestructorDemo[10]; // all elements will be collected
                for (int i = 0; i < obj1.Length; i++)
                {
                    obj1[i] = new DestructorDemo();
                }
                DestructorDemo obj2 = new DestructorDemo();

                //obj1 = null; // not allowing elments to go off
                obj1[0] = null;
                obj1[1] = null;

                GC.Collect();
            });
            th.Start();

            Console.ReadKey();
        }
    }
}
