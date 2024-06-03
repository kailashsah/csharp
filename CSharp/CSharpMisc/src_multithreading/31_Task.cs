using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Task
    2. https://www.c-sharpcorner.com/UploadFile/dacca2/asynchronous-programming-in-C-Sharp-5-0-part-3-understand-task/

*/

namespace CSharpMisc
{
    class TaskEx
    {
        public void RunTaskStart()
        {
            //1.
            Task t = new Task(
                   () =>
                   {
                       System.Threading.Thread.Sleep(1000);
                       Console.WriteLine("Huge Task Finish");
                   }
                   );

            //Start the Task
            t.Start();


            //Wait for finish the Task
            t.Wait();

            //2. 
            Action action = () =>
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Huge Task Finish using action");
            };
            Task tt = new Task(action);
            tt.Start();

            //3.
            Task ttt = new Task(delegate ()
            {

                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Huge Task Finish using delegate");

            });
            ttt.Start();

            //4. status
            Console.WriteLine(t.Status); // RanToCompletion.
            Console.WriteLine("Cancelled:- " + t.IsCanceled);
            Console.WriteLine("Completed:- " + t.IsCompleted);
            Console.WriteLine("Folted:- " + t.IsFaulted);

            Console.Write("Enter to exit: "); Console.ReadKey();// to wait the current thread decide by user input
        }

        public void RunTaskRun()
        {
            /*
                Task.Start() method is not requied.
            */

            Task t = Task.Run(() =>
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Huge Task Finish by Task run");
            });
            Console.Write("Enter to exit: ");  Console.ReadKey(true);// true to not display key pressed
        }

        public void RunTaskFactory()
        {
            Task t = Task.Factory.StartNew(() =>
            {
                System.Threading.Thread.Sleep(1000);
                Console.WriteLine("Huge Task Finish by Task run");
                Console.WriteLine($"main thread: {Thread.CurrentThread.ManagedThreadId}");
            });

            Console.Write("Enter to exit: "); Console.ReadKey();

        }

        //public static void Main(String[] args)
        //{
        //    new TaskEx().RunTaskStart(); 
        //    //new TaskEx().RunTaskRun(); 
        //    //new TaskEx().RunTaskFactory(); 
        //}
    }

}
