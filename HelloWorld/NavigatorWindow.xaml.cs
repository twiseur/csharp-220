using System;
using System.Collections.Generic;
using System.Diagnostics;
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
    /// Interaction logic for NavigatorWindow.xaml
    /// </summary>
    public partial class NavigatorWindow : Window
    {
        public NavigatorWindow()
        {
            InitializeComponent();
        }

        private void uxGoButton_Click(object sender, RoutedEventArgs e)
        {
            // Pass the fileName to the helper class
            var processStartInfo = new ProcessStartInfo(uxURLTextBox.Text);

            // Start a new process
            Process.Start(processStartInfo);
        }

        private void uxURLTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
