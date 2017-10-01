using System.Collections.ObjectModel;
using System;

using WSSample.Models;

namespace WSSample.ViewModels
{
    class ProfilesViewModel : ObservableObject, IPage
    {
        private ObservableCollection<Profile> _profiles;
        public ObservableCollection<Profile> Profiles
        {
            get { return _profiles; }
            private set
            {
                _profiles = value;
                OnPropertyChanged("Profiles");
            }
        }

        public ProfilesViewModel() : this(Repository.Instance) { }
        public ProfilesViewModel(Repository repository)
        {
            repository.DataInitialized += OnDataInitialized;
        }

        private void OnDataInitialized(object sender, EventArgs e)
        {
            Profiles = new ObservableCollection<Profile>(Repository.Instance.GetProfiles());
        }

        public void Show() { }

        public void Close() { }
    }
}
