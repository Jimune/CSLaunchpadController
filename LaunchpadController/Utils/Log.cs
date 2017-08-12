using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Launchpad.Utils {

    public class Log {

        private static void Raw(string prefix, Color color, params object[] msg) {
            if (msg != null && msg.Count() > 0) {
                StringBuilder sb = new StringBuilder();

                foreach (object o in msg) {
                    if (prefix != null && prefix.Count() > 0)
                        sb.Append(prefix);
                    sb.Append(o.ToString()).Append("\n");
                }

                RichTextBox textBox = LaunchpadController.Instance.Screen.TextView;

                textBox.SelectionStart = textBox.TextLength;
                textBox.SelectionLength = 0;

                textBox.SelectionColor = color;
                textBox.AppendText(sb.ToString());
                textBox.SelectionColor = textBox.ForeColor;
            }
        }

        public static void Info(params object[] msg) {
            Raw("[INFO] ", Color.Black, msg);
        }

        public static void Error(params object[] msg) {
            Raw("[ERRR] ", Color.FromArgb(255, 212, 0), msg);
        }

        public static void Warning(params object[] msg) {
            Raw("[WARN] ", Color.DarkOrange, msg);
        }

        public static void Severe(params object[] msg) {
            Raw("[SEVERE] ", Color.Red, msg);
        }

        public static void Debug(params object[] msg) {
            if (GlobalVars.DEBUG)
                Raw("[DEBUG] ", Color.Blue, msg);
        }
    }
}
