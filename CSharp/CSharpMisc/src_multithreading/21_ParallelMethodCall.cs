using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
/*
    1. it calls the method instantly without waiting for the last call to complete.
*/
namespace CSharpMisc.src
{
    public class ParallelMethodCall
    {
        public void Method()
        {
            //DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss:fff tt");
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
        /*
            program ends
            Start  9/13/2023 1:48:08 PM
            Start  9/13/2023 1:48:08 PM
            ends  9/13/2023 1:48:12 PM
            ends  9/13/2023 1:48:12 PM

            it calls the method instantly without waiting for the last call to complete.
         */
    }
}
