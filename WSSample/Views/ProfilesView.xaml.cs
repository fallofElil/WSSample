using System.Windows.Controls;
using System.Collections.Generic;

using WSSample.Models;

namespace WSSample.Views
{
    public partial class ProfilesView : UserControl, IPage
    {
        public ProfilesView()
        {
            InitializeComponent();
        }

        public void Show()
        {
            if (itemsControl.Items.Count == 0)
                itemsControl.ItemsSource = new List<Profile>(Repository.Instance.GetProfiles());
        }

        public void Close() { }
    }
}
