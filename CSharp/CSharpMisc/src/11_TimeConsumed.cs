using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpMisc
{
    public class TimeConsumed
    {
        public static void RunTimeConsumed()
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();
            // put your code here.
            Thread.Sleep(1000);
            
            watch.Stop();
            TimeSpan span = watch.Elapsed;

            Console.WriteLine("After code takes 1 second of sleep : ");
            Console.WriteLine($"Ticks : {span.Ticks}");
            Console.WriteLine($"MS : {span.TotalMilliseconds}");
            Console.WriteLine($"Seconds : {span.TotalSeconds}");
        }
    }
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        // 4.
    //        TimeConsumed.RunTimeConsumed();
            
    //        Console.WriteLine("program ends");
    //    }
    //}
}
