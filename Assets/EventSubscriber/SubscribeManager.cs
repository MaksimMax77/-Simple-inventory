using System.Collections.Generic;

namespace EventSubscriber
{
    public class SubscribeManager
    {
        private List<ISubscriber> _subscribers = new List<ISubscriber>();

        public void Add(ISubscriber subscriber)
        {
            _subscribers.Add(subscriber);
        }
        public void Subscribe()
        {
            for(int i = 0, len = _subscribers.Count; i < len; ++i)
            {
                _subscribers[i].Subscribe();
            }
        }
        public void UnSubscribe()
        {
            for(int i = 0, len = _subscribers.Count; i < len; ++i)
            {
                _subscribers[i].UnSubscribe();
            }
        }
    }
}
