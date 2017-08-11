using System;
using Launchpad.Utils;

namespace Launchpad.LaunchHandler {

    public class LaunchEvent {
        public int Key { get; private set; }
        public KeyState State { get; private set; }

        public LaunchEvent(int key, KeyState state) {
            this.Key = key;
            this.State = state;
        }

        public bool IsPressed() {
            return State == KeyState.Pressed;
        }
    }

    public class LaunchEventHandler {

        public event KeyPressedHandler LaunchEvents;
        public delegate void KeyPressedHandler(LaunchEvent events);

        public void CallEvent(LaunchEvent launchEvent) {
            LaunchEvents(launchEvent);
        }
    }
}
