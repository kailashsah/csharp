using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

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

   
}

