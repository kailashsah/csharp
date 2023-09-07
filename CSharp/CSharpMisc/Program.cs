using CSharpMisc;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;

namespace ConsoleApp.ThreadStatic
{
    public class Program
    {

        public static void Main(string[] args)
        {

            // 3.
            //ImmutableObject immObj = new ImmutableObject("Kailash", 38);
            //immObj.Age = 40; // cannot be assigned to -- readonly

            // 2.
            //RunDestructorDemo();
            //RunObjectSize();
            
            // 1.
            //new ThreadStaticEx().Run();
            //


            Console.WriteLine("program ends");
        }// main

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
            while (true)
            {
                GC.Collect(GC.MaxGeneration);
                GC.WaitForPendingFinalizers();
                string read = Console.ReadLine();
                if (read == "exit")
                    break;
            }
        }
    }//class

}



