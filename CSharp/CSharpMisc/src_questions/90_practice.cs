using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. 

*/

namespace CSharpMisc
{
    public class Practice
    {
       

        public void Run()
        {
            int[] ints = { 1,2,10,4};
            int[] intss = new int[] { 1, 2, 10, 4 };
            int[,] intssd = { { 1, 2 }, { 10, 4 } };

            Array.ForEach(ints, x => Console.WriteLine(x));
            Array.Sort(ints);
            Array.ForEach(ints, x => Console.WriteLine(x)); 
        }

        //static void Main(String[] args)
        //{
        //    new Practice().Run();

        //}
    }
}
