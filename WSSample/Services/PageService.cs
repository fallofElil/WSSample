using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;

using WSSample.Views;

namespace WSSample.Services
{
    class PageService
    {
        private static PageService _instance;
        public static PageService Instance { get { return _instance; } }

        public Dictionary<string, IPage> Pages { get; }

        private ContentControl _contentControl;
        public IPage CurrentPage
        {
            get { return (IPage)_contentControl.Content; }
            private set { _contentControl.Content = value; }
        }

        public PageService(ContentControl contentControl) : this(contentControl, _defaultPages) { }
        public PageService(ContentControl contentControl, Dictionary<string, IPage> pages) : this(contentControl, pages, pages.Keys.First()) { }
        public PageService(ContentControl contentControl, Dictionary<string, IPage> pages, string startingPage)
        {
            if (_instance == null)
                _instance = this;

            _contentControl = contentControl;

            Pages = pages;
            CurrentPage = Pages["Start"];
        }

        public void ChangePage(string pageName)
        {
            if (CurrentPage != Pages[pageName])
            {
                CurrentPage.Close();
                CurrentPage = Pages[pageName];
                CurrentPage.Show();
            }
        }

        private static Dictionary<string, IPage> _defaultPages = new Dictionary<string, IPage> {
                { "Start", new StartView() },
                { "Users", new UsersView() },
                { "Profiles", new ProfilesView() }
        };
    }
}
