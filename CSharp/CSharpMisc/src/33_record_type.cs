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
    1.  record types help us to work with immutable types.

    2. Record Type is a compact and easy way to write reference types (immutable) that automatically behave like value types.
    
    3. C# 9.0 introduces the “With” expression with RecordType. It is mainly used to create new objects more effectively.
    4. https://www.c-sharpcorner.com/article/c-sharp-9-0-introduction-to-record-types/ 

    
    
*/

namespace CSharpMisc
{
    public record Member
    {
        public int ID { get; init; }
        public string FirstName { get; init; }
        public string LastName { get; init; }
        public string Address { get; init; }
    }

    public class RunTemp12
    {
        public void Run()
        {
            var member = new Member
            {
                ID = 1,
                FirstName = "Kirtesh",
                LastName = "Shah",
                Address = "Vadodara"
            };
            var newMember = new Member
            {
                ID = member.ID,
                FirstName = member.FirstName,
                LastName = member.LastName,
                Address = "Mumbai"
            };

            var newMember2 = member with { Address = "Mumbai" };
            //The “With” expression is used as a { } syntax that allows you to define new values for a specific property.It will make development faster, easier, and cleaner.
        }

        //public static void Main(string[] args)
        //{
        //    new RunTemp12().Run();
        //    Console.WriteLine("program ends");
        //}
    }
}
