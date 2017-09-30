using System.Collections.Generic;
using System.Windows.Controls;

using WSSample.Views;

namespace WSSample.Services
{
    class PageService
    {
        private static PageService _instance;
        public static PageService Instance { get { return _instance; } }

        private ContentControl _contentControl;
        
        public IPage CurrentPage
        {
            get { return (IPage)_contentControl.Content; }
            private set { _contentControl.Content = value; }
        }

        public Dictionary<string, IPage> Pages { get; }

        public PageService(ContentControl contentControl)
        {
            if (_instance == null)
                _instance = this;

            Pages = new Dictionary<string, IPage>
            {
                { "Users", new UsersView() },
                { "Profiles", new ProfilesView() },
                { "Start", new StartView() }
            };

            _contentControl = contentControl;

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
    }
}
