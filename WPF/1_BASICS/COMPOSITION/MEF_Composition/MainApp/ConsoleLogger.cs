using System;
using System.ComponentModel.Composition;
using System.Diagnostics;

namespace WpfApp1.Messages
{
    [Export(typeof(ILogger))]
    public class ConsoleLogger : ILogger
    {
        public ConsoleLogger()
        {
        }

        public void Write(string arg)
        {
            Trace.Write(arg);
        }

    }
}