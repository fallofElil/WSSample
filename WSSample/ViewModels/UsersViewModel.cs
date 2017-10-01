using System.Collections.ObjectModel;
using System;

using WSSample.Models;

namespace WSSample.ViewModels
{
    class UsersViewModel : ObservableObject, IPage
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users
        {
            get { return _users; }
            private set
            {
                _users = value;
                OnPropertyChanged("Users");
            }
        }

        public UsersViewModel() : this(Repository.Instance) { }
        public UsersViewModel(Repository repository)
        {
            repository.DataInitialized += OnDataInitialized;
        }

        private void OnDataInitialized(object sender, EventArgs e)
        {
            Users = new ObservableCollection<User>(Repository.Instance.GetUsers());
        }

        public void Show()
        {
            if (Users == null)
                Users = new ObservableCollection<User>(Repository.Instance.GetUsers());
        }

        public void Close() { }
    }
}
