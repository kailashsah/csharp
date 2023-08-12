using System;
using System.Collections.Generic;
using System.Linq;

namespace EventAggregatorSample
{
    public class EventManager
    {
        private static EventManager eventManager;
        public static EventManager Instance
        {
            get
            {
                if(eventManager == null)
                    eventManager = new EventManager();
                return eventManager;
            }
            
        }

        private EventManager()
        {

        }

        #region Implementation
        internal Dictionary<object, List<object>> Events { get; set; } = new Dictionary<object, List<object>>();

        public void Subscribe<T, U>(Action<U> action)
        {
            if (Events.TryGetValue(typeof(T), out var actions))
            {
                actions.Add(action);
            }
            else
                Events.Add(typeof(T), new List<object>() { action });
        }

        public void UnSubscribe<T, U>(Action<U> action)
        {
            if (Events.TryGetValue(typeof(T), out var actions))
            {
                actions.Remove(action);
            }
        }

        public void Publish<T, U>(U payload)
        {
            var actions = Events.FirstOrDefault(x => x.Key as Type == typeof(T)).Value;
            foreach (var action in actions)
            {
                (action as Action<U>)(payload);
            }
        } 
        #endregion
    }

}
