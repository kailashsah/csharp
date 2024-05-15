using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/*
    1. Minimum remove to make valid paranthesis

        Given a string s of '(' , ')' and lowercase English characters.

        Your task is to remove the minimum number of parentheses ( '(' or ')', in any positions ) so that the resulting parentheses string is valid and return any valid string.

        Formally, a parentheses string is valid if and only if:

        It is the empty string, contains only lowercase characters, or
        It can be written as AB (A concatenated with B), where A and B are valid strings, or
        It can be written as (A), where A is a valid string.
 

        Example 1:

        Input: s = "lee(t(c)o)de)"
        Output: "lee(t(c)o)de"
        Explanation: "lee(t(co)de)" , "lee(t(c)ode)" would also be accepted.
        Example 2:

        Input: s = "a)b(c)d"
        Output: "ab(c)d"
        Example 3:

        Input: s = "))(("
        Output: ""
        Explanation: An empty string is also valid.

*/

namespace CSharpMisc
{
    public class RemoveParanthesis
    {
        public string MinRemoveToMakeValid(string s)
        {
            StringBuilder sb = new StringBuilder(s);
            Stack<int> st = new Stack<int>();
            for (int i = 0; i < sb.Length; i++)
            {
                char current = sb[i];
                bool open = current == '(';
                bool close = current == ')';
                if (open)
                    st.Push(i);
                if (close)
                {
                    if (st.Count > 0)
                        st.Pop();
                    else
                        sb.Replace(')', '*', i, 1);
                }

            }
            while (st.Count > 0)
            {
                sb.Remove(st.Pop(), 1); // left over ')' brackets, POP returns you position

            }

            sb = sb.Replace("*", "", 0, sb.Length);// here don't use sb.Length -1 
            return sb.ToString();

        }

        public void Run()
        {
            string s = MinRemoveToMakeValid("lee(t(c)o)de)");
            if (s != "lee(t(c)o)de" && s != "lee(t(co)de)")
            {
                Console.WriteLine("test failed - return is " + s);
            }
            else
                Console.WriteLine("test passed - return is " + s);
        }

        //static void Main(String[] args)
        //{
        //    new RemoveParanthesis().Run();

        //}
    }
}
