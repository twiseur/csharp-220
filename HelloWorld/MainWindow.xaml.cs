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
        public MainWindow()
        {
            InitializeComponent();
            
            // Exercise 1
            //WindowState = WindowState.Maximized;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password: " + uxPassword.Text);
        }

        private void uxName_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateSubmitButton();
        }

        private void uxPassword_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateSubmitButton();
        }

        private void updateSubmitButton()
        {
            if ((uxName.Text != "") && (uxPassword.Text != ""))
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
