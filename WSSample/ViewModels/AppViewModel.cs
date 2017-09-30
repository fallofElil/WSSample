using System.Collections.Generic;
using System.Windows.Input;

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
            set
            {
                if (_currentPage != value)
                {
                    _currentPage = value;
                    OnPropertyChanged("CurrentPage");
                }
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

        public AppViewModel()
        {
            if (_instance == null)
                _instance = this;

            Pages = new Dictionary<string, IPage>
            {
                { "Users", new UsersViewModel() },
                { "Profiles", new ProfilesViewModel() },
                { "Start", new StartViewModel() }
            };

            CurrentPage = Pages["Start"];
        }

        public void ChangePage(string pageName)
        {        
            CurrentPage.Close();
            CurrentPage = Pages[pageName];
            CurrentPage.Show();
        }
    }
}

