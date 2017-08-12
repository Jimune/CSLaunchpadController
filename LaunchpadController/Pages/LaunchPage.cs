using System.Collections.Generic;
using System.Linq;
using Launchpad.Pages.Actions;

namespace Launchpad.Pages {

    public class LaunchPage {
        
        public int PageNumber { get; set; }
        public List<LaunchAction> Actions { get; private set; }

        public LaunchPage(params LaunchAction[] actions) {
            Actions = new List<LaunchAction>();

            if (actions != null && actions.Count() > 0) {
                Actions.AddRange(actions);
            }
        }

        public LaunchAction GetAction(int x, int y) {
            return GetAction((y * 16) + x);
        }

        public LaunchAction GetAction(int key) {
            foreach (LaunchAction action in Actions) {
                if (action.Key == key)
                    return action;
            }

            return null;
        }

        public bool RemoveAction(int x, int y) {
            return RemoveAction((y * 16) + x);
        }

        public bool RemoveAction(int key) {
            LaunchAction tempAction = null;

            foreach (LaunchAction action in Actions) {
                if (action.Key == key)
                    tempAction = action;
            }

            if (tempAction == null)
                return false;

            return Actions.Remove(tempAction);
        }
    }
}
