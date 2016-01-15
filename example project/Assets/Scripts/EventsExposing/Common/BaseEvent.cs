using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.EventsExposing.Common
{
    public class BaseEvent<EventType> : MonoBehaviour where EventType:class
    {
        private event Action<BaseEventArgs<EventType>> genericEvent;
        private HashSet<Action<BaseEventArgs<EventType>>> _handlers;
        public void Awake() {
            _handlers = new HashSet<Action<BaseEventArgs<EventType>>>();
        }

        public void Subscribe(Action<BaseEventArgs<EventType>> newHandler) {
            if (_handlers.Contains(newHandler)) {
                return;
            }

            genericEvent += newHandler;
        }

        public void UnSubscribe(Action<BaseEventArgs<EventType>> oldHandler)
        {   
            //TODO deside if an exception should be thrown when oldHandler was not subscribed in the first place
            genericEvent -= oldHandler;
        }

        protected void DispatchEvent(BaseEventArgs<EventType> eventToDispatch) {
            if (genericEvent != null) {
                genericEvent(eventToDispatch);
            }
        }

        void OnDestroy()
        {
            foreach (var handler in _handlers)
            {
                genericEvent -= handler;
            }
        }

        //TODO deside if we want to return the most derived type via CRTP 
        public static EventType operator +(BaseEvent<EventType> dispatcher, Action<BaseEventArgs<EventType>> newEventHandler)
        {
            dispatcher.Subscribe(newEventHandler);
            return dispatcher as EventType;
        }

        public static EventType  operator -(BaseEvent<EventType> dispatcher, Action<BaseEventArgs<EventType>> newEventHandler)
        {
            dispatcher.UnSubscribe(newEventHandler);
            return dispatcher as EventType;
        }
    }
}
