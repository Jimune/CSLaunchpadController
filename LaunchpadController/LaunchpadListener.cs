using System;
using System.Windows.Forms;
using Launchpad.LaunchHandler;
using Launchpad.Pages;

namespace Launchpad {

    class LaunchpadListener : ILaunchEventListener {

        public void KeyPressedEvent(LaunchEvent launchEvent) {
            LaunchAction action = LaunchPageHandler.Instance().CurPage.GetAction(launchEvent.Key);

            if (action != null) {
                if (launchEvent.IsPressed())
                    action.Press();
                else
                    action.Release();
            }
        }

    }

}
