using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

// CSHP220 Homework 4
// Author: Thaddee Wiseur

namespace ZipCodeChecker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string zipCodePattern = "(^([0-9][0-9][0-9][0-9][0-9](-[0-9][0-9][0-9][0-9])?)$)|(^[A-Z][0-9][A-Z][0-9][A-Z][0-9]$)";
        private Regex regex;

        public MainWindow()
        {
            InitializeComponent();
            regex = new Regex(zipCodePattern);
            uxZipCodeTextBox.Focus();
        }

        private void updateSubmitButton ()
        {
            uxSubmitButton.IsEnabled = regex.IsMatch(uxZipCodeTextBox.Text);
            if (uxSubmitButton.IsEnabled)
            {
                uxZipCodeTextBox.Foreground = new SolidColorBrush(Colors.ForestGreen);
            }
            else
            {
                uxZipCodeTextBox.Foreground = new SolidColorBrush(Colors.Black);
            }
        }

        private void uxZipCodeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            updateSubmitButton();
        }

        private void uxSubmitButton_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Valid ZIP code!");
        }
    }
}
