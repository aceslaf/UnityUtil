using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.EventsExposing.Common
{
    public class BaseEventArgs<EventOrigin>
    {
        public EventOrigin Origin { get; private set; }
        public BaseEventArgs(EventOrigin origin) {
            Origin = origin;
        }
    }
}
