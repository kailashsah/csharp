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
    1. 
*/

namespace CSharpMisc
{

    public class Arrays
    {
        public void Run()
        {
            //........................................... declare
            int[,] arr2 = new int[3, 3];//2D array  
            int[,,] arr1 = new int[3, 3, 3];//3D array  

            //........................................... insert in array
            int[,] arr = new int[3, 3];//declaration of 2D array  
            arr[0, 1] = 10;//initialization  
            arr[1, 2] = 20;
            arr[2, 0] = 30;
            /*
                0 10 0
                0 0 20
                30 0 0
             
             */

            //........................................... traversal  
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(arr[i, j] + " ");
                }
                Console.WriteLine();//new line at each row  
            }

            int[,] arr4 = new int[3, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            int[,] arr5 = { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };

            //........................................... row, col variable
            int row = 3;
            int col = 3;
            int[,] arr6 = new int[row, col];
            //traversal  
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    arr6[i, j] = j; // <-- insert is possible this way
                }
                Console.WriteLine();//new line at each row  
            }
        }

        public void String2D()
        {

        }



        //public static void Main(string[] args)
        //{
        //    new Arrays().Run();

        //    Console.WriteLine("program ends");
        //}
    }
}
