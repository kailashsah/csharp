using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Write a function to find the longest common prefix string amongst an array of strings.

        If there is no common prefix, return an empty string "".

 

        Example 1:

        Input: strs = ["flower","flow","flight"]
        Output: "fl"
        Example 2:

        Input: strs = ["dog","racecar","car"]
        Output: ""
        Explanation: There is no common prefix among the input strings.

*/

namespace CSharpMisc
{
    public class LongestPrefix
    {
        public string LongestCommonPrefix(string[] strs)
        {
            int len = strs.Length;
            string strCommon = "";
            for (int i = 0; i < strs[0].Length; i++)
            {
                for (int k = 1; k < strs.Length; k++)
                {
                    if (i >= strs[k].Length || strs[k][i] != strs[0][i])
                        return strCommon;
                }//for
                strCommon += strs[0][i];
            }//for
            return strCommon;
        }

        public void Run()
        {
            //1.
            //string[] strs = { "dog", "racecar", "car" }; // out - ""
            //2.
            string[] strs = { "flower", "flow", "flight" }; // out - "fl"
            string result = "";
            result = LongestCommonPrefix(strs);
            Console.WriteLine(result);

        }

        //static void Main(String[] args)
        //{
        //    new LongestPrefix().Run();

        //}
    }
}
