using InventoryApp.Models;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for FurnitureWindow.xaml
    /// </summary>
    public partial class FurnitureWindow : Window
    {
        public FurnitureWindow()
        {
            InitializeComponent();

            ShowInTaskbar = false;
        }

        public FurnitureModel Furniture { get; set; }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            //TODO Validation on the input data
            Furniture.Value = Furniture.Price * Furniture.Quantity;

            DialogResult = true;
            Close();
        }

        private void uxGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                uxSubmit_Click(sender, e);
            }
        }

        private void uxCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
            Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            if (Furniture != null)
            {
                uxSubmit.Content = "Update";
            }
            else
            {
                Furniture = new FurnitureModel();
            }

            uxGrid.DataContext = Furniture;
        }

        private void uxData_GotFocus(object sender, RoutedEventArgs e)
        {
            if (((TextBox)sender).Text == "0")
                ((TextBox)sender).Text = "";
        }
    }
}
