using System.Windows.Controls;
using System.Collections.Generic;
using System;

using WSSample.Models;

namespace WSSample.Views
{
    public partial class UsersView : UserControl, IPage
    {  
        public UsersView()
        {
            InitializeComponent();

            Repository.Instance.DataInitialized += OnDataInitialized;
        }

        private void OnDataInitialized(object sender, EventArgs e)
        {
            itemsControl.ItemsSource = new List<User>(Repository.Instance.GetUsers());
        }

        public void Show()
        {
            if (itemsControl.Items.Count == 0)
                itemsControl.ItemsSource = new List<User>(Repository.Instance.GetUsers());
        }

        public void Close() { }
    }
}
