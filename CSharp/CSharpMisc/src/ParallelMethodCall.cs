using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CSharpMisc.src
{
    public class ParallelMethodCall
    {
        public void Method()
        {
            Console.WriteLine($"Start  {DateTime.Now.ToString()}");
            Thread.Sleep(3000);
            Console.WriteLine($"ends  {DateTime.Now.ToString()}");
        }

        public static void RunParallelMethodCall()
        {
            ParallelMethodCall obj = new ParallelMethodCall();
            new Thread(() =>
            {
                obj.Method();
            })
            .Start();

            new Thread(() =>
            {
                obj.Method();
            })
            .Start();
        }
    }
}
