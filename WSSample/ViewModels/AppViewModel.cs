using System.Collections.Generic;
using System.Windows.Input;
using System.Linq;

namespace WSSample.ViewModels
{
    class AppViewModel : ObservableObject
    {
        private static AppViewModel _instance;
        public static AppViewModel Instance { get { return _instance; } }

        public Dictionary<string, IPage> Pages { get; }

        private IPage _currentPage;
        public IPage CurrentPage
        {
            get { return _currentPage; }
            private set
            {
                _currentPage = value;
                OnPropertyChanged("CurrentPage");
            }
        }

        private ICommand _changePageCommand;
        public ICommand ChangePageCommand
        {
            get
            {
                if (_changePageCommand == null)
                    _changePageCommand = new RelayCommand(pageName => ChangePage((string)pageName));

                return _changePageCommand;
            }
        }

        public AppViewModel() : this(_defaultPages) { }
        public AppViewModel(Dictionary<string, IPage> pages) : this(pages, pages.Keys.First()) { }
        public AppViewModel(Dictionary<string, IPage> pages, string startingPage)
        {
            if (_instance == null)
                _instance = this;

            Pages = pages;
            CurrentPage = Pages[startingPage];
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
                { "Start", new StartViewModel() },
                { "Users", new UsersViewModel() },
                { "Profiles", new ProfilesViewModel() }
        };
    }
}

