using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 
 */
namespace CSharpMisc
{
    public class ImmutableObject
    {
        public ImmutableObject(string name, int age)
        {
            Name = name;
            Age = age;
        }

        public string Name { get; }
        public int Age { get; }

    }

    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {

    //        // 3.
    //        ImmutableObject immObj = new ImmutableObject("Kailash", 38);
    //        //immObj.Age = 40; // error - cannot be assigned to -- readonly
            
    //        Console.WriteLine("program ends");
    //    }// main
    //}//class


}
