using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1. Func<> vs delegate -
        both Func<string,string> and delegate string convertMethod(string) would be capable of holding the same method definitions whether they be methods, anonymous methods, or lambda expressions.

    2. If you want the delegate to have some special name that gives more definition of what that delegate should do (beyond simple Action, Predicate, etc) then creating your own delegate is always an option.
*/

namespace CSharpMisc
{
    public class DelegateClass
    {
        // you can define your own delegate for a nice meaningful name, but the
        // generic delegates (Func, Action, Predicate) are all defined already
        public delegate string ConvertedMethod(string value);

        public void RunMethod()
        {
            //1.
            // both work fine for taking methods, lambdas, etc.
            Func<string, string> convertedMethod = s => s + ", Hello!";
            Console.WriteLine(convertedMethod("convertedMethod"));

            //2.
            ConvertedMethod convertedMethod2 = s => s + ", Hello!";
            Console.WriteLine(convertedMethod2("convertedMethod2"));
        }
    };

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        new DelegateClass().RunMethod();
    //        Console.WriteLine("program ends");
    //    }
    //}

}
