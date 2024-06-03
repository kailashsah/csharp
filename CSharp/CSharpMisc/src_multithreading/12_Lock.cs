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
        
        unnamed mutex -> similar to lock except locking scope is more and it's across AppDomain in a process.

        Named mutex -> locking scope is even more than unnamed mutex and it's across process in an operating system.
    3.
        Mutex is a cross process and there will be a classic example of not running more than one instance of an application.

        2nd example is say you are having a file and you don't want different process to access the same file , you can implement a Mutex but remember one thing Mutex is a operating system wide and cannot used between two remote process.

        Lock is a simplest way to protect section of your code and it is appdomain specific , you can replace lock with Moniters if you want more controlled synchronization.

        Mutex ensures thread safety for threads that are generated by the external applications i.e. External Threads. Using Mutex, only one external thread can access our application code at any given point in time.

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
