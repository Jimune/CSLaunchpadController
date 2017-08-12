using Launchpad.LaunchHandler;
using Launchpad.Pages;
using Launchpad.Pages.Actions;

namespace Launchpad.Utils {

    public class LaunchUtils {

        public static void TellPad(int x, int y, KeyColor color) {
            TellPad((y * 16) + x, color);
        }

        public static void TellPad(int key, KeyColor color) {
            MidiMessageHandler.Instance().SendMessage(key, (int) color);
        }

        public static void ResetPad() {
            MidiMessageHandler.Instance().ClearPad();
        }

        public static void SetPadFromPage(LaunchPage page) {
            ResetPad();

            foreach (LaunchAction action in page.Actions) {
                TellPad(action.Key, action.Color);
            }
        }
    }
}
