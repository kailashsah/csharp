using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Partitioner()
    2. When a Parallel.For loop has a small body, it might perform more slowly than the equivalent sequential loop, such as the for loop in C#.
        Slower performance is caused by the overhead involved in partitioning the data and the cost of invoking a delegate on each loop iteration. To address such scenarios, the Partitioner class provides the Partitioner.Create method, which enables you to provide a sequential loop for the delegate body, so that the delegate is invoked only once per partition, instead of once per iteration. 

    3. It is useful when the loop performs a minimal amount of work. As the work becomes more computationally expensive, you will probably get the same or better performance by using a For or ForEach loop with the default partitioner.
        
        https://learn.microsoft.com/en-us/dotnet/standard/parallel-programming/how-to-speed-up-small-loop-bodies

*/

namespace CSharpMisc
{
    public class PartitionerEx
    {
        public void Run()
        {

            //1. Source must be array or IList.
            var source = Enumerable.Range(0, 100).ToArray(); // use it for 10 L
            
            //2.
            //Parallel.For(0, source.Length, (x) => { Console.Write("{0} ", x); });
            //Parallel.ForEach(source, (x) => { Console.Write("{0} ", x); });
           
            // Partition the entire source array.
            var rangePartitioner = Partitioner.Create(0, source.Length); // <==

            double[] results = new double[source.Length];

            // Loop over the partitions in parallel.
            Parallel.ForEach(rangePartitioner, (range, loopState) =>
            {
                Console.WriteLine("{0},{1} ", range.Item1,range.Item2);
                // Loop over each range element without a delegate invocation.
                for (int i = range.Item1; i < range.Item2; i++)
                {
                    results[i] = source[i] * Math.PI;
                }
            });

            Console.WriteLine("Operation complete. Print results? y/n");
            char input = Console.ReadKey().KeyChar;
            if (input == 'y' || input == 'Y')
            {
                foreach (double d in results)
                {
                    Console.Write("{0} ", d);
                }
            }

            /*
                Console.WriteLine("{0},{1} ", range.Item1,range.Item2);
                0,8
                8,16
                16,24
                56,64
                64,72
                72,80
                80,88
                88,96
                96,100
                40,48
                48,56
                24,32
                32,40
             */
        }//Run()

        static void Main(String[] args)
        {
            new PartitionerEx().Run();
        }
    }
}
