using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. shift like numbers at one side of the array;
    
    2. built-in swap function -  In the C# language, there is no built-in method for this purpose on most types. You have to implement a custom swap method for string characters and other types.

 */
namespace CSharpMisc
{
    class Solution
    {
        public static void RunShiftNumbersAlike()
        {
            int[] arr = new int[] { 0, 1, 1, 0, 1, 1, 1, 0, 0, 0, 1, 0, 1, 1 }; //1 1 1 1 1 1 1 1 0 0 0 0 0 0

            // int[] arr = new int [] {0,1,1,0};
            // int[] arr = new int [] {1,0,0,1};
            // int[] arr = new int [] {1,0,0,1};

            int h = 0;              // head
            int t = arr.Length - 1; // tail
            int len = arr.Length;
            int temp = 0;

            for (int i = 0; i < len / 2; i++)
            {
                if (arr[h] < arr[t])
                {
                    temp = arr[t];
                    arr[t] = arr[h];
                    arr[h] = temp;
                    //swap (arr[h], arr[t]);
                    t--;
                    h++;
                }
                else
                {
                    // right side has 0 already
                    if (arr[t] == 0) // is tail side no is 0
                        t--;
                }

                if (arr[h] == 1) // if head side no is 1
                {
                    h++;
                   
                }
                if (arr[t] == 0) // if tail side no is 0
                {
                    t--;

                }


            }
            foreach (int n in arr)
                Console.Write(n + " "); // 1 1 1 1 1 1 1 1 0 0 0 0 0 0
        }
        //static void Main(String[] args)
        //{
        //    RunShiftNumbersAlike();


        //}
    }
}
