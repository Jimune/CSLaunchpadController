using System;
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

        public static double PercentOf(double min, double max, double current) {
            return (current / (max - min)) * 100.0D;
        }

        public static int[] YFromPercent(int range, int start_from_bottom, double percent) {
            int[] temp = new int[range];

            for (int i = 0; i < range; i++) {
                temp[i] = -1;
            }

            double steps = 100 / range;
            int returnamount = (int)Math.Floor(percent / steps);

            for (int i = 0; i < returnamount; i++) {
                temp[i] = 7 - start_from_bottom - i;
            }

            return temp;
        }
    }
}
