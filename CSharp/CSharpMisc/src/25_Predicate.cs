using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1. Predicate - Predicate is the delegate like Func and Action delegates. It represents a method containing a set of criteria and checks whether the passed parameter meets those criteria. 

        A predicate delegate methods must take one input parameter and return a boolean - true or false.

 */
namespace CSharpMisc
{
    public class PredicateClass
    {
        bool IsUpperCase(string str)
        {
            return str.Equals(str.ToUpper());
        }

        public void RunMethod()
        {
            //1.
            Predicate<string> isUpper = IsUpperCase;
            bool result = isUpper("hello world!!");

            Console.WriteLine(result);

            //2.
            //An anonymous method can also be assigned to a Predicate delegate type as shown below.
            Predicate<string> isUpperV2 = delegate (string s) { return s.Equals(s.ToUpper()); };
            bool result2 = isUpperV2("hello world!!");

            //3.
            //A lambda expression can also be assigned to a Predicate delegate type as shown below.
            Predicate<string> isUpperV3 = s => s.Equals(s.ToUpper());
            bool result3 = isUpperV3("hello world!!");
        }
    }

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        new PredicateClass().RunMethod(); 
    //        Console.WriteLine("program ends");
    //    }
    //}

}
