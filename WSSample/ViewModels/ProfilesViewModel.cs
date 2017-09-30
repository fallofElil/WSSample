using System.Collections.ObjectModel;

using WSSample.Models;

namespace WSSample.ViewModels
{
    class ProfilesViewModel : IPage
    {
        private ObservableCollection<Profile> _profiles;
        public ObservableCollection<Profile> Profiles { get { return _profiles; } }

        public void Show()
        {
            if (_profiles == null)
                _profiles = new ObservableCollection<Profile>(Repository.Instance.GetProfiles());
        }

        public void Close()
        {

        }
    }
}
