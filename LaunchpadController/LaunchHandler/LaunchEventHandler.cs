using System.Collections.Generic;

namespace Launchpad.LaunchHandler {

    public class LaunchEventHandler {

        private List<ILaunchEventListener> listeners = new List<ILaunchEventListener>();

        public void AddLaunchEventListener(ILaunchEventListener listener) {
            if (!listeners.Contains(listener))
                listeners.Add(listener);
        }

        public void CallEvent(LaunchEvent launchEvent) {
            foreach (ILaunchEventListener listener in listeners) {
                listener.KeyPressedEvent(launchEvent);
            }
        }
    }
}
