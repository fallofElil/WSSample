using System.Windows;

using WSSample.Services;

namespace WSSample
{
    public partial class AppWindow : Window
    {
        public AppWindow()
        {
            InitializeComponent();
        }

        private void Profiles_Click(object sender, RoutedEventArgs e)
        {
            PageService.Instance.ChangePage("Profiles");
        }

        private void Users_Click(object sender, RoutedEventArgs e)
        {
            PageService.Instance.ChangePage("Users");
        }
    }
}
