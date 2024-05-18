using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
/*
    1.  String Characteristics:  

        It is a reference type.
        It’s immutable( its state cannot be altered).
        It can contain nulls.
        It overloads the operator(==).
        Differences between String and System.String : 
        The string is an alias for System.String. Both String and System.String means same and it will not affect the performance of the application. “string” is keyword in C#. So the main difference comes in the context, how to use these: 

        The String is used for the declaration but System.String is used for accessing static string methods.
        The String is used to declare fields, properties etc. that it will use the predefined type System.String. It is the easy way to use.
        The String has to use the System.String class methods, such as String.SubString, String.IndexOf etc. The string is only an alias of System.String.

    2. In other words a String object is a sequential collection of System.Char objects which represents a string.
        The maximum size of String object in memory is 2GB or about 1 billion characters. System.String class is immutable, i.e once created its state cannot be altered.

    3. Note: In .NET, the text is stored as a sequential collection of the Char objects so there is no null-terminating character at the end of a C# string. Therefore a C# string can contain any number of embedded null characters (‘\0’). 

    4. String methods - https://www.javatpoint.com/c-sharp-strings
*/

namespace CSharpMisc
{

    public class RunStrings
    {
        public void Run()
        {
            {
                string fname, lname;
                fname = "Rowan";
                lname = "Atkinson";
                string fullname = fname + lname;
            }
            {
                char[] letters = { 'H', 'e', 'l', 'l', 'o' };
                string greetings = new string(letters);
            }

            {
                string[] sarray = { "Hello", "From", "Tutorials", "Point" };
                string message = String.Join(" ", sarray);
            }

            {
                DateTime waiting = new DateTime(2012, 10, 10, 17, 58, 1);
                string chat = String.Format("Message sent at {0:t} on {0:D}", waiting);
                Console.WriteLine("Message: {0}", chat);

                int no = 10;
                string cname = "BMW";
                string clr = "Red";
                string str = string.Format("{0} {1} Cars color " + "are {2}", no.ToString(), cname, clr);
            }

            {
                string str1 = "This is test";
                string str2 = "This is text";
                if (String.Compare(str1, str2) == 0)
                {
                    Console.WriteLine(str1 + " and " + str2 + " are equal.");
                }
            }

            {
                string str = "This is test";

                if (str.Contains("test"))
                {
                    Console.WriteLine("The sequence 'test' was found.");
                }
            }

            {
                string str = "Last night I dreamt of San Pedro";
                string substr = str.Substring(23); // San Pedro
                Console.WriteLine(substr);
            }

            {
                string sentence = "c# For c#";

                // Extract the second word.

                // taking the first space position value
                int startpos = sentence.IndexOf(" ") + 1;

                // taking the second space position value
                int endpos = sentence.IndexOf(" ", startpos) - startpos;

                // now extract second word from the sentence
                string wrd = sentence.Substring(startpos/*startindex*/, endpos/*length*/); // "For"
            }

            {
                //String read_user = Console.ReadLine();
                string str; // string can be declared without initialization
            }

        }


        //public static void Main(string[] args)
        //{
        //    new RunStrings().Run();

        //    Console.WriteLine("program ends");
        //}
    }
}
