﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. StringBuilder 

*/

namespace CSharpMisc
{
    public class StringBuilderTest
    {

        public void Run()
        {
            StringBuilder sb = new StringBuilder(5);
            sb.Append("C# is the language"); //18 len
          
            Console.WriteLine(sb.ToString());
            Console.WriteLine(sb.Capacity.ToString()); //18

            sb.Replace('a','@', 15, 3);// old char, new char, startindex, count(len of rest of the substring)
            // C# is the langu@ge

            sb.Remove(0 ,2 ); //startindex, length
            // is the langu@ge

            sb.Insert(0, "c#");
            //c# is the langu@ge

        }

        //static void Main(String[] args)
        //{
        //    new StringBuilderTest().Run();

        //}
    }
}
