using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.EventsExposing.Common
{
    class BaseEvent<EventOrigin>
    {
        public EventOrigin Origin { get; set; }
    }
}
