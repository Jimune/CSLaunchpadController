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
}
