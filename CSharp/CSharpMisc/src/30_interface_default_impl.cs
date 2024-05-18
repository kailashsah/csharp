using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1.  


*/

namespace CSharpMisc
{
    public interface IDefaultImpl
    {
        //Interfaces can now provide default method implementations.
        void Display();

        void PrintIt() => Console.WriteLine("PrintIt");
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
