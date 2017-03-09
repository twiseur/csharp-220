using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

// CSHP 220 Assignment 1
// Author: Thaddee Wiseur

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();

        public MainWindow()
        {
            InitializeComponent();

            // Exercise 1
            //WindowState = WindowState.Maximized;
        }

        public override void EndInit()
        {
            base.EndInit();
            uxContainer.DataContext = user;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {

            int x = 1;
            x = x / (x - 1); // Induce a DivideByZeroException

            MessageBox.Show("Submitting password: " + uxPassword.Password);

            var window = new SecondWindow();
            window.AddUser(uxName.Text, uxPassword.Password);
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateSubmitButton();
        }

        private void uxPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            updateSubmitButton();
        }

        private void updateSubmitButton()
        {
            if ((uxName.Text != "") && (uxPassword.Password != ""))
            {
                uxSubmit.IsEnabled = true;
            }
            else
            {
                uxSubmit.IsEnabled = false;
            }
        }

    }
}
