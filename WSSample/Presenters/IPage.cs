using System.Windows.Controls;

namespace WSSample.Presenters
{
    interface IPage
    {
        UserControl Page { get; }

        void Show();
        void Close();
    }
}
