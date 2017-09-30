using System.Collections.ObjectModel;

using WSSample.Models;

namespace WSSample.ViewModels
{
    class UsersViewModel : IPage
    {
        private ObservableCollection<User> _users;
        public ObservableCollection<User> Users { get { return _users; } }

        public void Show()
        {
            if (_users == null)
                _users = new ObservableCollection<User>(Repository.Instance.GetUsers());
        }

        public void Close()
        {

        }
    }
}
