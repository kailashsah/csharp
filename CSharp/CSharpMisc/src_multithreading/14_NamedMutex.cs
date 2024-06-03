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
    2. Mutex stands for Mutual Exclusion. The Mutex type ensures blocks of code are executed only once at a time. It is basically used in a situation where resources has to be shared by multiple threads simultaneously.  
       

*/

namespace CSharpMisc
{
    public class NamedMutexEx
    {
        static Mutex _mutex;
        public void Run()
        {
            //If IsSingleInstance returns true continue with the Program else Exit the Program
            if (!IsSingleInstance())
            {
                Console.WriteLine("More than one instance"); // Exit program.
            }
            else
            {
                Console.WriteLine("One instance"); // Continue with program.
            }
            // Stay Open.
            Console.ReadLine();
        }
        
        static bool IsSingleInstance()
        {
            try
            {
                // Try to open Existing Mutex.
                //If MyMutex is not opened, then it will throw an exception
                Mutex.OpenExisting("MyMutex");
            }
            catch
            {
                // If exception occurred, there is no such mutex.
                _mutex = new Mutex(true, "MyMutex");
                // Only one instance.
                return true;
            }
            // More than one instance.
            return false;
        }

        //static void Main()
        //{
        //    new NamedMutexEx().Run();
        //}

    }
}
