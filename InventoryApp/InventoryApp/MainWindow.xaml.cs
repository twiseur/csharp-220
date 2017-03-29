using System.Linq;
using System.Windows;
using System.Windows.Controls;
using InventoryApp.Models;
using System.ComponentModel;

// CSHP220 Project
// Author: Thaddée Wiseur

namespace InventoryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private GridViewColumnHeader sortedColumn = null;
        private ListSortDirection sortingOrder = ListSortDirection.Ascending;

        private FurnitureModel selectedFurniture;

        public MainWindow()
        {
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            InitializeComponent();
            uxFurnitureList.Visibility = Visibility.Collapsed;
        }

        private void LoadFurnitures()
        {
            var contacts = App.FurnitureRepository.GetAll();

            uxFurnitureList.ItemsSource = contacts.Select(
                t => FurnitureModel.ToModel(t)).ToList();
        }

        private void uxFurnitureList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedFurniture = (FurnitureModel)uxFurnitureList.SelectedValue;

            EnableModifyAndDelete((selectedFurniture != null));
        }

        private void EnableModifyAndDelete(bool isEnabled)
        {
            uxFileDelete.IsEnabled = isEnabled;
            uxFileModify.IsEnabled = isEnabled;
            uxContextFileModify.IsEnabled = isEnabled;
            uxContextFileDelete.IsEnabled = isEnabled;
            uxToolbarModifyButton.IsEnabled = isEnabled;
            uxToolbarDeleteButton.IsEnabled = isEnabled;
        }

        private void uxFileAdd_Click(object sender, RoutedEventArgs e)
        {
            var window = new FurnitureWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;

            if (window.ShowDialog() == true)
            {
                App.FurnitureRepository.Add(window.Furniture.ToRepositoryModel());

                LoadFurnitures();
            }
        }

        private void lvFurnituresColumnHeader_Click(object sender, RoutedEventArgs e)
        {
            GridViewColumnHeader column = (sender as GridViewColumnHeader);

            if (sortedColumn != null)
            {
                uxFurnitureList.Items.SortDescriptions.Clear();

                if (sortedColumn == column)
                {
                    if (sortingOrder == ListSortDirection.Ascending)
                        sortingOrder = ListSortDirection.Descending;
                    else
                        sortingOrder = ListSortDirection.Ascending;
                }
                else
                {
                    sortingOrder = ListSortDirection.Ascending;
                }
            }

            sortedColumn = column;

            uxFurnitureList.Items.SortDescriptions.Add(new SortDescription(column.Tag.ToString(), sortingOrder));
        }

        private void uxFileModify_Click(object sender, RoutedEventArgs e)
        {
            var window = new FurnitureWindow();
            window.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            window.Furniture = selectedFurniture.Clone();

            if (window.ShowDialog() == true)
            {
                App.FurnitureRepository.Update(window.Furniture.ToRepositoryModel());

                LoadFurnitures();
            }
        }

        private void uxFileDelete_Click(object sender, RoutedEventArgs e)
        {
            App.FurnitureRepository.Remove(selectedFurniture.Id);
            selectedFurniture = null;

            LoadFurnitures();
        }

        private void uxFileList_Click(object sender, RoutedEventArgs e)
        {
            uxFurnitureList.Visibility = Visibility.Visible;
            LoadFurnitures();
        }

        private void uxFileQuit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void uxFurnitureList_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            uxFileModify_Click(sender, null);
        }
    }
}
