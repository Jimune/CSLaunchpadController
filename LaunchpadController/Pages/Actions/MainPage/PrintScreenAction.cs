using System;
using System.Windows.Forms;
using Launchpad.Utils;

namespace Launchpad.Pages.Actions.MainPage {
    public class PrintScreenAction : LaunchAction {

        public PrintScreenAction() : base (8, 6, KeyColor.Green_High){}

        public override void Press() {
            SendKeys.SendWait("+({PRTSC})");
        }

        public override void Release() {
            
        }
    }
}
