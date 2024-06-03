using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Monitor
    2. 
        
        
        

*/

namespace CSharpMisc
{
    class MonitorEx
    {
        private static readonly object lockPrintNumberst = new object();
        public static void PrintNumbers()
        {
            Console.WriteLine(Thread.CurrentThread.Name + " Trying to enter into the critical section");
            bool IsLockTaken = false;

            try
            {
                //1.
                //Monitor.Enter(lockPrintNumberst);

                //2.
                //Monitor.Enter(lockPrintNumberst, ref IsLockTaken);

                /*
                 we specified the timeout as 1000 milliseconds, or you can say 1 second. If the thread does not acquire the lock within 1 second, it will not enter the critical section.

                 The output may vary on your machine. As you can see, all three threads try to acquire a lock on the object within 1 second. Two of the three threads acquire an exclusive lock on the object, while one is unable to acquire an exclusive lock, and hence, that thread will not enter the critical section.
                 */

                //3.
                TimeSpan timeout = TimeSpan.FromMilliseconds(1000);
                Monitor.TryEnter(lockPrintNumberst, timeout, ref IsLockTaken);
                
                
                
                if (IsLockTaken)
                {
                    Console.WriteLine(Thread.CurrentThread.Name + " Entered into the critical section");
                    for (int i = 0; i < 5; i++)
                    {
                        Thread.Sleep(100);
                        Console.Write(i + ",");
                    }
                    Console.WriteLine();
                }
            }
            finally
            {
                
                if (IsLockTaken)
                {
                    Monitor.Exit(lockPrintNumberst);
                    Console.WriteLine(Thread.CurrentThread.Name + " Exit from critical section");
                }
            }
        }
        public void Run()
        {
            Thread[] Threads = new Thread[3];
            for (int i = 0; i < 3; i++)
            {
                Threads[i] = new Thread(PrintNumbers)
                {
                    Name = "Child Thread " + i
                };
            }
            foreach (Thread t in Threads)
            {
                t.Start();
            }
            Console.ReadKey();

            /*
                Child Thread 0 Trying to enter into the critical section
                Child Thread 0 Entered into the critical section
                Child Thread 1 Trying to enter into the critical section
                Child Thread 2 Trying to enter into the critical section
                0,1,2,3,4,
                Child Thread 0 Exit from critical section
                Child Thread 1 Entered into the critical section
                0,1,2,3,4,
                Child Thread 2 Entered into the critical section
                Child Thread 1 Exit from critical section
                0,1,2,3,4,
                Child Thread 2 Exit from critical section
             */
        }
        //static void Main(string[] args)
        //{
        //    new MonitorEx().Run();
        //}
    }

}
