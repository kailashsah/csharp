using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1. https://www.programiz.com/csharp-programming/jagged-array 
    2. https://www.c-sharpcorner.com/UploadFile/puranindia/jagged-arrays-in-C-Sharp-net/

*/

namespace CSharpMisc
{

    public class JaggedArrays
    {
        public void Run()
        {


        }

        public void String2D()
        {
            string[][] sta = new string[3][]; // OK
            //string[][] sta = new string[3][3]; // error -  Syntax error, ']' expected

            string[] starr = new string[] { "a", "b", "c", "d" }; // input str array
            int counter = 0;
            for (int i = 0; i < starr.Length; i++)
            {
                sta[counter] = new string[2];
                sta[counter][0] = starr[i];
                i++;
                sta[counter][1] = starr[i];
                counter++;
            }
            sta.ToList().ForEach(x =>
            {
                if (x != null) // if more rows given in declaring but objects not given to array
                    Console.WriteLine($"[{x[0]}, {x[1]}]");
                /*
                    [a, b]
                    [c, d]
                */
            });

            for (int i = 0; i < sta.Length - 1; i++)
            {
                if (sta[i][0] != null)
                    Console.WriteLine($"{sta[i][0]}, {sta[i][1]}");

            }

            RunPassArrayAsParam(sta);
        }

        void RunPassArrayAsParam(string[][] sta)
        {
            // if as fn definition -->  RunPassArrayAsParam(string[3][3] sta))
            // Error CS0270  Array size cannot be specified in a variable declaration(try initializing with a 'new' expression)

            for (int i = 0; i < sta.Length - 1; i++)
            {
                if (sta[i][0] != null)
                    Console.WriteLine($"{sta[i][0]}, {sta[i][1]}");

            }
        }

        public void JaggedArray1()
        {
            string[,] jagged = new string[2, 3];
            for (int i = 0; i < jagged.Length / 2 - 1; i++)// jagged.Length --> 6
            {
                jagged[i, 0] = new string("a");
                jagged[i, 1] = new string("b");
                //jagged[0, 3] = new string("");//index was outside the bound of the array, it is definedas [2,3]
            }
            for (int i = 0; i < jagged.Length / 2 - 1; i++)
            {
                Console.WriteLine($"{jagged[i, 0]}, {jagged[i, 1]}");
            }


        }
        public void JaggedArray2()
        {
            string[] first = { "one", "two" };
            string[] second = { "three", "four" };
            string[][] jagged = { first, second };

            foreach (string[] arr in jagged)
            {
                Console.WriteLine(string.Join(",", arr));
            }
            /*
                one,two
                three,four
            */

        }

        //public static void Main(string[] args)
        //{
        //    //new RunTemp123().Run();
        //    new JaggedArrays().String2D();
        //    new JaggedArrays().JaggedArray2();
        //    new JaggedArrays().JaggedArray1();


        //    Console.WriteLine("program ends");
        //}
    }
}
