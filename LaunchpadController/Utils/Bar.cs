using System.Threading;

namespace Launchpad.Utils {

    public class Bar {

        public int X { get; private set; }
        public int[] Y { get; private set; }
        public int Length { get; private set; }
        public int Bottom_offset { get; private set; }
        public KeyColor Color { get; private set; }
        public int Used { get; private set; }

        public Bar(int x, int length, int bottom_offset, KeyColor color) {
            this.X = x;
            this.Y = new int[length];
            this.Length = length;
            this.Bottom_offset = bottom_offset;
            this.Color = color;
        }

        public void Add() {
            if (Used == Length)
                return;

            for (int i = 0; i < Length; i++) {
                if (Y[i] < 0) {
                    Y[i] = 7 - Bottom_offset - i;
                    Used++;
                    Update();
                    break;
                }
            }
        }

        public void Remove() {
            if (Used == 0)
                return;

            for (int i = Length - 1; i >= 0; i--) {
                if (Y[i] >= 0) {
                    Y[i] = -1;
                    Used--;
                    Update();
                    break;
                }
            }
        }

        public void Update() {
            for (int i = 0; i < Length; i++) {
                if (Y[i] < 0) {
                    LaunchUtils.TellPad(X, 7 - Bottom_offset - i, KeyColor.Off);
                } else {
                    LaunchUtils.TellPad(X, Y[i], Color);
                }
            }
        }

        public void Flash(int amount, int color_duration, KeyColor color_on, KeyColor color_off) {
            for (int i = 0; i < amount; i++) {
                for (int j = 0; j < Length; j++) {
                    LaunchUtils.TellPad(X, 7 - Bottom_offset - j, color_off);
                }

                Thread.Sleep(color_duration);

                for (int j = 0; j < Length; j++) {
                    LaunchUtils.TellPad(X, 7 - Bottom_offset - j, color_on);
                }

                Thread.Sleep(color_duration);
            }

            Update();
        }

    }   

}
