using System;
using System.Collections.Generic;
using System.Windows.Controls;

using WSSample.Models;
using WSSample.Views;

namespace WSSample.Presenters
{
    class ProfilesViewPresenter : IPage
    {
        private ProfilesView _view;
        public UserControl Page { get { return _view; } }

        public List<Profile> Profiles { get; private set; }

        public ProfilesViewPresenter() : this(Repository.Instance) { }
        public ProfilesViewPresenter(Repository repository)
        {
            _view = new ProfilesView();
            Repository.Instance.DataInitialized += OnDataInitialized;
        }

        private void OnDataInitialized(object sender, EventArgs e)
        {
            Profiles = new List<Profile>(Repository.Instance.GetProfiles());
        }

        public void Show()
        {
            if (_view.itemsControl.Items.Count == 0)
                _view.itemsControl.ItemsSource = Profiles;
        }

        public void Close() { }
    }
}
