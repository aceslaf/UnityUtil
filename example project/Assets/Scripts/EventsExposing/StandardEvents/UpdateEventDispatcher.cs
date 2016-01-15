using Assets.Scripts.EventsExposing.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Assets.Scripts.EventsExposing.StandardEvents
{
    class UpdateEventDispatcher: BaseEvent<UpdateEventDispatcher>
    {
        public void Update() {
            DispatchEvent(new BaseEventArgs<UpdateEventDispatcher>(this));
        }
    }
}
