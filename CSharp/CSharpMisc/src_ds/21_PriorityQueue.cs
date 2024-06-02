using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. priority_queue<element, priority>
    
    2. not available in .NET 5. 
    3. A priority queue is a data structure that maintains a collection of elements, each with an associated priority, in a way that allows retrieving an element with the highest or lowest priority. It’s like a regular queue, but elements are dequeued based on their priority rather than the order they were added.

    3. when we add a new element to a full priority queue, the back storage is expanded. So how much more memory is allocated? This is controlled by the growth factor. A growth factor is a number that we multiply by the current capacity to increase it. The growth factor in PriorityQueue is two, which means the capacity is doubled on each expansion. This number is a constant and cannot be changed.
*/

namespace CSharpMisc
{
    public class TaskAsWork //: IComparable<Task>
    {
        public string Name { get; set; }
        public int Priority { get; set; }

        //public int CompareTo(Task other)
        //{
        //    return Priority.CompareTo(other.Priority);
        //}
    }

    public class ProgramQueueEx
    {
        public void Run()
        {
            var priorityQueue = new PriorityQueue<TaskAsWork, int>(10);
            priorityQueue.Enqueue(new TaskAsWork { Name = "Task A", Priority = 3 }, 3);
            priorityQueue.Enqueue(new TaskAsWork { Name = "Task B", Priority = 2 }, 2);
            priorityQueue.Enqueue(new TaskAsWork { Name = "Task C", Priority = 1 }, 1);

            //2.
            var tt = priorityQueue.Peek();
            Console.WriteLine("Executing task: {0}", tt.Name);// task C

            //2.
            while (priorityQueue.Count > 0)
            {
                var task = priorityQueue.Dequeue();
                Console.WriteLine("Executing task: {0}", task.Name);
            }

            //3.
            //Assert.AreEqual(5, priorityQueue.EnsureCapacity(0)); //10
            //Assert.AreEqual(0, priorityQueue.Count);//0

            //4.
            priorityQueue.Clear();

            /*
                Executing task: Task C
                Executing task: Task B
                Executing task: Task A
            */

        }
        //public static void Main()
        //{
        //    new ProgramQueueEx().Run();
        //}
    }
}
