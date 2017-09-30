using System.Windows;

using WSSample.Models;

namespace WSSample
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            AppWindow app = new AppWindow();
            app.Show();

            new Repository("DBConnection");
        }
    }
}
