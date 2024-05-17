using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1. here checking memory leak using destructor console output.
 */
namespace CSharpMisc
{
    class DestructorDemo
    {
        static int counter = 0;
        int object_identifier;
        public DestructorDemo()
        {
            object_identifier = counter++;
            Console.WriteLine("Constructor Object Created " + object_identifier);
        }
        ~DestructorDemo()
        {
            Console.WriteLine($"Object {GetType().Name} is Destroyed " + object_identifier);
        }
        public static void RunDestructorDemo()
        {
            //1.
            DestructorDemo[] obj1 = new DestructorDemo[10];
            
            Thread th = new Thread(() =>
            {
                //2.
                //DestructorDemo[] obj1 = new DestructorDemo[10]; // all elements will be collected
                for (int i = 0; i < obj1.Length; i++)
                {
                    obj1[i] = new DestructorDemo();
                }
                DestructorDemo obj2 = new DestructorDemo();

                //1.
                //obj1 = null; // not allowing elments to go off
                
                //2.
                obj1[0] = null;
                obj1[1] = null;

                GC.Collect();
            });
            th.Start();

            Console.ReadKey();
        }
    }
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        DestructorDemo.RunDestructorDemo();
           
    //        Console.WriteLine("program ends");
    //    }
    //}
}
/*
        Constructor Object Created 0
        Constructor Object Created 1
        Constructor Object Created 2
        Constructor Object Created 3
        Constructor Object Created 4
        Constructor Object Created 5
        Constructor Object Created 6
        Constructor Object Created 7
        Constructor Object Created 8
        Constructor Object Created 9
        Constructor Object Created 10
        Object DestructorDemo is Destroyed 1
        Object DestructorDemo is Destroyed 0
        program ends
*/
