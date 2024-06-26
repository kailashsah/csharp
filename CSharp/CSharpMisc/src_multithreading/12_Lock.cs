﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. lock
    2. 
        lock -> Simple to use, wrapper on monitor, locks across threads in an AppDomain.
  
        The Lock and Monitors are basically used to provide thread safety for threads that are generated by the application itself i.e. Internal Threads.
        
        

*/

namespace CSharpMisc
{
    class LockEx
    {
        static object lockObject = new object();
        public void RunThreadUsingLock()
        {
            Thread thread1 = new Thread(SomeMethod)
            {
                Name = "Thread 1"
            };
            Thread thread2 = new Thread(SomeMethod)
            {
                Name = "Thread 2"
            };
            Thread thread3 = new Thread(SomeMethod)
            {
                Name = "Thread 3"
            };
            thread1.Start();
            thread2.Start();
            thread3.Start();
            Console.ReadKey();
        }
        public static void SomeMethod()
        {
            // Locking the Shared Resource for Thread Synchronization
            lock (lockObject)
            {
                string name = Thread.CurrentThread.Name;
                Console.WriteLine(name);
                Console.Write("[Welcome To The ");
                Thread.Sleep(1000);
                Console.WriteLine("World of Dotnet!]");
            }

            /*
                [Welcome To The World of Dotnet!]
                [Welcome To The World of Dotnet!]
                [Welcome To The World of Dotnet!]
             
             */
        }

        //static void Main(string[] args)
        //{
        //    new LockEx().RunThreadUsingLock();
        //}

    }
}
