using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1. Get size of object/class

        For value types use sizeof(object value)
        For unmanaged objects use Marshal.SizeOf(object obj)

        Unfortunately the two above will not get you the sizes of referenced objects.


*/

namespace CSharpMisc
{

    [StructLayout(LayoutKind.Sequential)] // Lets you control the physical layout of the data fields of a class or structure in memory.
    public class MyClass
    {
        public int myField0; // 4 bytes
        public int myField1; // 4 bytes

    }



    public class RunClass
    {
        public void Run()
        {

            MyClass obj = new MyClass();
            int sizeObject = Marshal.SizeOf((obj)); // Returns the unmanaged size, in bytes, of a class.
            int sizeInBytesSt = Marshal.SizeOf(typeof(MyClass));

            Console.WriteLine("size object   " + sizeObject + " size class  " + sizeInBytesSt); // 8,8
        }

        public void RunUsingGC()
        {
            // second way of taking out differece before and after GC's total memory
            MyClass myFoo;

            long StartBytes = System.GC.GetTotalMemory(true);
            myFoo = new MyClass();
            long StopBytes = System.GC.GetTotalMemory(true);
            GC.KeepAlive(myFoo); // This ensure a reference to object keeps object in memory


            Console.WriteLine("Size is " + ((long)(StopBytes - StartBytes)).ToString()); // 72 bytes .. same number returned after removing two int fields
        }

    }


    public class Program
    {
        //public static void Main(string[] args)
        //{
        //    new RunClass().Run();
        //    new RunClass().RunUsingGC();
        //    Console.WriteLine("program ends");
        //}
    }

}
