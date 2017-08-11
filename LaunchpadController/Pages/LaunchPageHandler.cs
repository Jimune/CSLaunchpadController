using System;
using System.Collections.Generic;
using System.Linq;
using Launchpad.Pages.Actions.MainPage;
using Launchpad.Utils;

namespace Launchpad.Pages {

    public class LaunchPageHandler {

        public LaunchPage CurPage { get; private set; }
        public LaunchPage Settings { get; private set; }
        public int TotalPages { get; private set; }
        public List<LaunchPage> Pages { get; private set; }

        private static LaunchPageHandler instance;

        private LaunchPageHandler() {
            Pages = new List<LaunchPage>();
        }

        public static LaunchPageHandler Instance() {
            if (instance == null)
                instance = new LaunchPageHandler();

            return instance;
        }

        public void AddPage(LaunchPage page) {
            LaunchPage p = GetPage(page);

            if (p == null) {
                Pages.Add(page);
                TotalPages = Pages.Count();
                page.PageNumber = TotalPages;

                if (TotalPages == 1) {
                    CurPage = page;
                }
            }
        }

        public LaunchPage GetPage(LaunchPage page) {
            foreach (LaunchPage lpage in Pages) {
                if (lpage.Equals(page))
                    return lpage;
            }

            return null;
        }

        public LaunchPage GetPage(int page) {
            foreach (LaunchPage lpage in Pages) {
                if (lpage.PageNumber == page)
                    return lpage;
            }

            return null;
        }

        public int NextPage() {
            if (CurPage.PageNumber + 1 <= TotalPages) {
                LaunchPage nextPage = GetPage(CurPage.PageNumber + 1);
                CurPage = nextPage;
                LaunchUtils.SetPadFromPage(nextPage);

                return nextPage.PageNumber;
            }

            return CurPage.PageNumber;
        }

        public int PreviousPage() {
            if (CurPage.PageNumber - 1 > 0) {
                LaunchPage prevPage = GetPage(CurPage.PageNumber - 1);
                CurPage = prevPage;
                LaunchUtils.SetPadFromPage(prevPage);

                return prevPage.PageNumber;
            }

            return CurPage.PageNumber;
        }

        public void SetupSettings() {
            Settings = new LaunchPage() {
                PageNumber = Int32.MaxValue
            };
        }

        public void DestroyPages() {
            CurPage = null;
            TotalPages = 0;
            Pages.Clear();
        }

        public void CreatePages() {
            AddPage(new LaunchPage(
                new PrintScreenAction()
                ));

            LaunchUtils.SetPadFromPage(CurPage);
        }
    }
}
