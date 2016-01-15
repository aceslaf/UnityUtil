using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.EventsExposing.Common
{
    public static class EventDispatcherExtensions
    {
        public static EventType ExposeEvent<EventType>(this GameObject parent) where EventType : BaseEvent<EventType>
        {
            if (parent == null)
            {
                throw new ArgumentNullException();
            }

            var dispatcher = parent.GetComponent<EventType>();
            if (dispatcher == null)
            {
                dispatcher = parent.AddComponent<EventType>();
            }
            return dispatcher as EventType;
        }

        public static EventType Subscribe<EventType>(this GameObject parent,Action<BaseEventArgs<EventType>> handler) where EventType : BaseEvent<EventType>
        {
            if (parent == null) {
                throw new ArgumentNullException("Trying to subscribe to null game object ");
            }

            if (handler == null)
            {
                throw new ArgumentNullException(string.Format("Event handler should not be null {0}",handler));
            }

            var dispatcher = parent.GetComponent<EventType>();
            if (dispatcher == null)
            {
                throw new ArgumentNullException(string.Format("Trying to subscribe to a non implemented event: {0}", typeof(EventType)));
            }

            dispatcher += handler;

            return dispatcher;
        }

        public static EventType UnSubscribe<EventType>(this GameObject parent, Action<BaseEventArgs<EventType>> handler) where EventType : BaseEvent<EventType>
        {
            if (parent == null)
            {
                throw new ArgumentNullException("Trying to unsubscribe to null game object ");
            }

            if (handler == null)
            {
                throw new ArgumentNullException(string.Format("Event handler should not be null go:{0} event:{1} handler:{2}",parent,typeof(EventType), handler));
            }

            var dispatcher = parent.GetComponent<EventType>();
            if (dispatcher == null)
            {
                throw new ArgumentNullException(string.Format("Trying to subscribe to a non implemented event. go:{0} event: {1}",parent, typeof(EventType)));
            }

            dispatcher += handler;

            return null;
        }
    }
}
