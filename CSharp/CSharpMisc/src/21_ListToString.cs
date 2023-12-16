using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpMisc.src
{
    public class ListToString
    {
        public static List<int> ListOfInt { get; set; }
        public static void RunListToString()
        {
            ListOfInt = new List<int>();
            ListOfInt.Add(1);
            ListOfInt.Add(2);
            StringBuilder sb = new StringBuilder();


            sb.Append("|pC-").Append(ListOfInt);
            Console.WriteLine($"{sb.ToString()}"); //| pC - System.Collections.Generic.List`1[System.Int32]
            Console.WriteLine($"{ListOfInt}"); // System.Collections.Generic.List`1[System.Int32]
        }
    }
    //public class Program
    //{
    //    public static void Main(string[] args)
    //    {
    //        ListToString.RunListToString();
    //        Console.WriteLine("program ends");
    //    }
    //}
}
