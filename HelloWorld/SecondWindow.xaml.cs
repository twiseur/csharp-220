﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        private List<Models.User> users;

        public SecondWindow()
        {
            InitializeComponent();

            users = new List<Models.User>();

            users.Add(new Models.User { Name = "Dave", Password = "DavePwd" });
            users.Add(new Models.User { Name = "Steve", Password = "StevePwd" });
            users.Add(new Models.User { Name = "Lisa", Password = "LisaPwd" });

            //uxList.ItemsSource = users;
        }

        public void AddUser(string name, string password)
        {
            users.Add(new Models.User { Name = name, Password = password});
        }
    }
}