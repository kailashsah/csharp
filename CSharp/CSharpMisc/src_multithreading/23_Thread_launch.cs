using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1. call thread for method with parameter
 */
namespace CSharpMisc
{
    public class ThreadLaunch
    {
        //1.
        public void ThreadMethod(string param)
        {
            Console.WriteLine("ThreadMethod :" + param);
            Console.WriteLine($"ThreadMethod :{param}" ); // $ - string interpolation
            Console.WriteLine("ThreadMethod :{0}", param); // ThreadMethod :param
            Console.WriteLine(@"ThreadMethod :{param}" ); // ThreadMethod :{param}
                                                          // @ - verbatim string, prints string as is 
        }

        public void RunV1()
        {
            //using anonymous function using lambda
            Thread thread = new Thread(()=> ThreadMethod("param"));
            thread.Start();
            thread.Join();
            thread.Join(100); // 100ms timeout 
                                // multiple join() no exception
        }
        
        //2.
        public void ThreadMethodV2(object param)
        {
            //An object that contains data for the thread procedure.
            Console.WriteLine("ThreadMethod :" + param);
            Console.WriteLine($"ThreadMethod :{param}"); // ThreadMethod :param
            Console.WriteLine(@"ThreadMethod :{param}"); // ThreadMethod :{param}
        }
        public void RunV2()
        {
            Console.WriteLine("");
            Thread thread = new Thread(ThreadMethodV2); // we need param as 'object' class .. ThreadMethod(object param)
           
            thread.Start("param"); // supply params here
            thread.Join();
            thread.Join(100); // 100ms timeout 
        }

        //3.
        public void RunV3_using_parameterized_threadstart()
        {
            Console.WriteLine("");
            //1.
            Thread thread = new Thread(new ParameterizedThreadStart( ThreadMethodV2));
            //2.
            //Thread thread = new Thread(new ThreadStart(ThreadMethodV2));// ThreadStart class for method with null paramas only.

            thread.Start("param");
            thread.Join();
            thread.Join(100); // 100ms timeout 
        }
        public void Run()
        {
            RunV1();
            RunV2();
            RunV3_using_parameterized_threadstart();
        }
    }
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        // 1.
    //        new ThreadLaunch().Run();
    //        //
    //        Console.WriteLine("program ends");
    //    }// main
    //}

}
