using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Mutex
    2. each thread calls the WaitOne(Int32) method to acquire the mutex. If the time-out interval elapses, the method returns false, and the thread neither acquires the mutex nor gains access to the resource. The ReleaseMutex method is called only by the thread that acquires the mutex. In the below example, we are calling the Dispose method from the destructor.
     
    3. mutex.WaitOne() - Blocks the current thread until the current System.Threading.WaitHandle receives
        a signal, using a 32-bit signed integer to specify the time interval in milliseconds.

    4. Mutex works like a lock i.e. acquired an exclusive lock on a shared resource from concurrent access, but it works across multiple processes. As we already discussed exclusive locking is basically used to ensure that at any given point in time, only one thread can enter into the critical section.

        Mutex is a synchronization mechanism that grants exclusive access to the shared resource to only one external thread

*/

namespace CSharpMisc
{
    public class MutexDisposeEx
    {
        private static Mutex mutex = new Mutex();

        // Method to implement syncronization using Mutex  
        static void MutexDemo()
        {
            // Wait until it is safe to enter, and do not enter if the request times out.
            Console.WriteLine(Thread.CurrentThread.Name + " Wants to Enter Critical Section for processing");
            if (mutex.WaitOne(1000))
            {
                try
                {
                    Console.WriteLine("Success: " + Thread.CurrentThread.Name + " is Processing now");
                    Thread.Sleep(2000);
                    Console.WriteLine("Exit: " + Thread.CurrentThread.Name + " is Completed its task");
                }
                finally
                {
                    //Call the ReleaseMutex method to unblock so that other threads
                    //that are trying to gain ownership of the mutex can enter  
                    mutex.ReleaseMutex();
                    Console.WriteLine(Thread.CurrentThread.Name + " Has Released the mutex");
                }
            }
            else
            {
                Console.WriteLine(Thread.CurrentThread.Name + " will not acquire the mutex");
            }
        }

        ~MutexDisposeEx()
        {
            mutex.Dispose();
        }

        public void Run()
        {
            //Create multiple threads to understand Mutex
            for (int i = 1; i <= 3; i++)
            {
                Thread threadObject = new Thread(MutexDemo)
                {
                    Name = "Thread " + i
                };
                threadObject.Start();
            }

            Console.ReadKey();

            /*
             
                Thread 1 Wants to Enter Critical Section for processing
                Thread 2 Wants to Enter Critical Section for processing
                Success: Thread 1 is Processing now
                Thread 3 Wants to Enter Critical Section for processing
                Thread 2 will not acquire the mutex
                Thread 3 will not acquire the mutex
                Exit: Thread 1 is Completed its task
                Thread 1 Has Released the mutex
             */
        }

        //static void Main(string[] args)
        //{
        //    new MutexDisposeEx().Run();
        //}

    }
}
