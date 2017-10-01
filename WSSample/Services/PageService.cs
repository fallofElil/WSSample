using System.Collections.Generic;
using System.Windows.Controls;
using System.Linq;

using WSSample.Presenters;

namespace WSSample.Services
{
    class PageService
    {
        private static PageService _instance;
        public static PageService Instance { get { return _instance; } }

        public Dictionary<string, IPage> Pages { get; }

        private ContentControl _contentControl;

        private IPage _currentPage;
        public IPage CurrentPage
        {
            get { return _currentPage; }
            private set
            {
                _currentPage = value;
                _contentControl.Content = _currentPage.Page;
            }
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
                { "Start", new StartViewPresenter() },
                { "Users", new UsersViewPresenter() },
                { "Profiles", new ProfilesViewPresenter() }
        };
    }
}
