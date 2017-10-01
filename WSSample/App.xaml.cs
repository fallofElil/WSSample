using System.Windows;
using System.Collections.Generic;

using WSSample.Models;
using WSSample.ViewModels;

namespace WSSample
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            new Repository("DBConnection").InitDataAsync();

            AppWindow app = new AppWindow();
            app.DataContext = new AppViewModel();
            app.Show();      
        }
    }
}
