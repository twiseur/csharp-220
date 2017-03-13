using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

// CSHP 220 Homework 3
// Author: Thaddee Wiseur

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private List<Models.User> users;
        private CollectionView view;

        public SecondWindow()
        {
            InitializeComponent();

            users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "1DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "2StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "3LisaPwd" });

            uxList.ItemsSource = users;
            view = (CollectionView)CollectionViewSource.GetDefaultView(uxList.ItemsSource);
        }

        public void AddUser(string name, string password)
        {
            users.Add(new Models.User { Name = name, Password = password});
        }

        private void NameColumnHeader_OnClick(object sender, RoutedEventArgs e)
        {
            // Remove any previous SortDescriptions
            view.SortDescriptions.Clear();

            // Order the name list
            view.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
        }

        private void PasswordColumnHeader_OnClick(object sender, RoutedEventArgs e)
        {
            // Remove any previous SortDescriptions
            view.SortDescriptions.Clear();

            // Order the password list
            view.SortDescriptions.Add(new SortDescription("Password", ListSortDirection.Ascending));
        }
    }
}
