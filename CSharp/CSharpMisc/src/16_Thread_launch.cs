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
        public void ThreadMethod(string param)
        {
            Console.WriteLine("ThreadMethod :" + param);
            Console.WriteLine($"ThreadMethod :{param}" ); // ThreadMethod :param
            Console.WriteLine(@"ThreadMethod :{param}" ); // ThreadMethod :{param}
        }

        public void Run()
        {
            Thread thread = new Thread(()=> ThreadMethod("param"));
            thread.Start();
            thread.Join();
            thread.Join(100); // 100ms timeout 
                                // multiple join() no exception
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            // 1.
            new ThreadLaunch().Run();
            //
            Console.WriteLine("program ends");
        }// main
    }

}
