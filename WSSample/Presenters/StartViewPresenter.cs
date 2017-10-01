using System.Windows.Controls;

using WSSample.Views;

namespace WSSample.Presenters
{
    class StartViewPresenter : IPage
    {
        private StartView _view;
        public UserControl Page { get { return _view; } }

        public StartViewPresenter()
        {
            _view = new StartView();
        }

        public void Show() { }

        public void Close() { }
    }
}
