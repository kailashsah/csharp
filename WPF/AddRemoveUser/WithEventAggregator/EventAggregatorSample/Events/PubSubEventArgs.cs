using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventAggregatorSample
{
    public class PubSubEventArgs<T> : EventArgs
    {
        public T Payload { get; set; }
    }
}
