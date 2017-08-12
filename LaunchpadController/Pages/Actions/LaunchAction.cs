using Launchpad.Utils;

namespace Launchpad.Pages.Actions {

    public abstract class LaunchAction {

        public int Key { get; private set; }
        private KeyColor color;
        public KeyColor Color {
            get {
                return this.color;
            }

            set {
                this.color = value;
                LaunchUtils.TellPad(Key, Color);
            }
        }

        public LaunchAction(int key, KeyColor color) {
            this.Key = key;
            this.Color = color;
        }

        public LaunchAction(int x, int y, KeyColor color) : this((y * 16) + x, color) {}

        public abstract void Press();

        public abstract void Release();
    }
}
