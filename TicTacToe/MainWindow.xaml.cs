using System.Windows;
using System.Windows.Controls;

// CSHP220  Homework 5
// Author: Thaddée Wiseur

namespace TicTacToe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.TicTacToe ticTacToe;

        public MainWindow()
        {
            InitializeComponent();
            ticTacToe = new Models.TicTacToe();
            DisplayNextPlayer();
        }

        private void DisplayNextPlayer()
        {
            this.uxTurn.Text = ticTacToe.CurrentPlayer + "'s turn";
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            ResetGridContent();
            ticTacToe.Reset();
            this.uxGrid.IsEnabled = true;
        }

        private void ResetGridContent()
        {
            var buttons = this.uxGrid.Children;

            for (int i = 0; i < buttons.Count; i++)
            {
                ((Button)buttons[i]).Content = "";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button senderButton = (Button)sender;
            string[] coordinates = senderButton.Tag.ToString().Split(',');
            int x = int.Parse(coordinates[0]);
            int y = int.Parse(coordinates[1]);
            string currentPlayer = ticTacToe.CurrentPlayer;
            if (ticTacToe.EmptySpace(x,y))
            {
                senderButton.Content = currentPlayer;
                if (ticTacToe.Play(x, y))
                {
                    this.uxTurn.Text = currentPlayer + " is a winner";
                    this.uxGrid.IsEnabled = false;
                }
                else
                {
                    DisplayNextPlayer();
                }
            }
        }
    }
}
