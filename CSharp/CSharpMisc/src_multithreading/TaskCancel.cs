using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Task cancel.
    
    2.  RunUsingCancellationToken()
        RunCancelWithoutCancellationToken();

*/

namespace CSharpMisc
{
    public class TaskCancel
    {
        public void RunUsingCancellationToken()
        {
            var ts = new CancellationTokenSource();
            CancellationToken ct = ts.Token;
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    // do some heavy work here
                    Thread.Sleep(100);
                    if (ct.IsCancellationRequested)
                    {
                        // another thread decided to cancel
                        Console.WriteLine("task canceled");
                        break;
                    }
                }
            }, ct);

            // Simulate waiting 3s for the task to complete
            Thread.Sleep(2000);

            // Can't wait anymore => cancel this task 
            ts.Cancel();
            
            //3. end (to see the ouput of terminated task or thread)
            Console.Write("Enter : "); Console.ReadKey();

        }

        public void RunCancelWithoutCancellationToken()
        {
            /*
                I used Task.Run() to show the most common use-case for this - using the comfort of Tasks with old single-threaded code, which does not use the CancellationTokenSource class to determine if it should be canceled or not.
             */

            Thread thread = null;

            Task t = Task.Run(() =>
            {
                try
                {
                    //Capture the thread
                    thread = Thread.CurrentThread;

                    //Simulate work (usually from 3rd party code)
                    Thread.Sleep(5000);

                    //If you comment out thread.Abort(), then this will be displayed
                    Console.WriteLine("Task finished!");
                }
                catch (ThreadInterruptedException e)
                {
                    Console.WriteLine("ThreadInterruptedException");
                }
            });

            //1. This is needed in the example to avoid thread being still NULL
            Thread.Sleep(10);

            //2. Cancel the task by aborting the thread
            thread.Interrupt();
            //thread.Abort();// Thread abort is not supported on this platform.' (.net core)

            //3. end
            Console.Write("Enter : "); Console.ReadKey();
        }

        static void Main(String[] args)
        {
            //new TaskCancel().RunCancelWithoutCancellationToken();
            new TaskCancel().RunUsingCancellationToken();
        }
    }//class
}

