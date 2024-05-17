using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1. [ThreadStatic] attribute

    2. variable become local to thread object.
 */
namespace CSharpMisc
{
    public class ThreadStaticEx
    {
        [ThreadStatic] public static int i = 0;
        public void Run()
        {
            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    i++;
                    Console.WriteLine("Thread A: {0}", i); // Uses one instance of the i variable.
                }
            }).Start();

            new Thread(() =>
            {
                for (int x = 0; x < 10; x++)
                {
                    i++;
                    Console.WriteLine("Thread B: {0}", i); // Uses another instance of the i variable.
                }
            }).Start();
        }
    }
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        // 1.
    //        new ThreadStaticEx().Run();
    //        //
    //        Console.WriteLine("program ends");
    //    }// main
    //}

}
/*
    Thread A: 1
    Thread A: 2
    Thread A: 3
    Thread A: 4
    Thread A: 5
    Thread A: 6
    Thread B: 1
    Thread B: 2
    Thread B: 3
    Thread B: 4
    Thread B: 5
    Thread B: 6
    Thread B: 7
    Thread A: 7
    Thread A: 8
    Thread A: 9
    Thread A: 10
    Thread B: 8
    Thread B: 9
    Thread B: 10
    program ends 
*/
