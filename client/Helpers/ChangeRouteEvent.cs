using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace client.Helpers
{
    public class EventArgs
    {
        public UserControl NewControl;
    }

    public delegate void EventHandler<T>(object src, EventArgs args);
    public class ChangeRouteEvent
    {
        public event EventHandler<EventArgs> OnRouteChanged;

        public void TriggerRouteChanged(UserControl control)
        {
            EventHandler<EventArgs> handler = OnRouteChanged;
            if (handler != null)
            {
                var args = new EventArgs()
                {
                    NewControl = control
                };
                handler(this, args);
            }

        }
    }
}
