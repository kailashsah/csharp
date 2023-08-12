//using Microsoft.Practices.Prism.PubSubEvents;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prism_basic
{
    public class Event
    {
        private IEventAggregator eventAggregator;
        private static readonly Event eventInstance = new Event();

        internal IEventAggregator EventAggregator
        {
            get
            {
                if (eventAggregator == null)
                {
                    eventAggregator = new EventAggregator();
                }

                return eventAggregator;
            }
        }
        internal static Event EventInstance
        {
            get
            {
                return eventInstance;
            }
        }
    }
}
