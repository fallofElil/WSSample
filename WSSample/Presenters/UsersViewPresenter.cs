using System;
using System.Collections.Generic;
using System.Windows.Controls;

using WSSample.Models;
using WSSample.Views;

namespace WSSample.Presenters
{
    class UsersViewPresenter : IPage
    {
        private UsersView _view;
        public UserControl Page { get { return _view; } }
        
        public List<User> Users { get; private set; }

        public UsersViewPresenter() : this(Repository.Instance) { }
        public UsersViewPresenter(Repository repository)
        {
            _view = new UsersView();
            Repository.Instance.DataInitialized += OnDataInitialized;
        }

        private void OnDataInitialized(object sender, EventArgs e)
        {
            Users = new List<User>(Repository.Instance.GetUsers());
        }

        public void Show()
        {
            if (_view.itemsControl.Items.Count == 0)
                _view.itemsControl.ItemsSource = Users;
        }

        public void Close() { }
    }
}
