using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1.  Single Cast Delegate: Delegate Refers to a single function or method.
        Multicast Delegate: Delegate Refers to multiple functions or methods.

    2.   a multicast delegate is just an array of multiple pipelines or multiple delegates. The delegates are going to be invoked in the same order as they are placed in the invocation list. An InvocationList is nothing but an array of delegates or pipelines where each pipeline will dump data into a different method. If this is not clear at the moment don’t worry, we will try to understand this with multiple examples.



*/

namespace CSharpMisc
{
    public delegate void RectangleDelegate(double Width, double Height);


    public class Rectangle
    {
        public void GetArea(double Width, double Height)
        {
            Console.WriteLine($"Area is {Width * Height}");
        }
        public void GetPerimeter(double Width, double Height)
        {
            Console.WriteLine($"Perimeter is {2 * (Width + Height)}");
        }
        public void RunMultiCastDelegate()
        {
            Rectangle rect = new Rectangle();
            //1.
            RectangleDelegate rectDelegate = new RectangleDelegate(rect.GetArea);
            //2.
            // RectangleDelegate rectDelegate = rect.GetArea;
            
            // binding a method with delegate object
            // In this example rectDelegate is a multicast delegate. 
            // You use += operator to chain delegates together.
            rectDelegate += rect.GetPerimeter;
            Console.WriteLine(rectDelegate.GetType());

            //........................................... calling by invocation list
            Delegate[] InvocationList = rectDelegate.GetInvocationList();
            Console.WriteLine("InvocationList:");
            foreach (var item in InvocationList)
            {
                Console.WriteLine($"  {item}");
            }
            Console.WriteLine();

            //........................................... direct call 
            Console.WriteLine("Invoking Multicast Delegate:");
            rectDelegate(23.45, 67.89);
            //rectDelegate.Invoke(13.45, 76.89);

            Console.WriteLine();
            Console.WriteLine("Invoking Multicast Delegate After Removing one Pipeline:");

            //........................................... Removing a method from delegate object
            rectDelegate -= rect.GetPerimeter;
            rectDelegate.Invoke(23.45, 67.89);
            Console.ReadKey();
        }
    }

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        new Rectangle().RunMultiCastDelegate();
    //        Console.WriteLine("program ends");
    //    }
    //}

}
