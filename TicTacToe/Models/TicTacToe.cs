// CSHP220  Homework 5
// Author: Thaddée Wiseur

namespace TicTacToe.Models
{
    class TicTacToe
    {
        private int[][] grid;
        public const int GRIDSIZE = 3;
        private const int NULLVALUE = -1;
        private const int PLAYERXVALUE = 0;
        private const int PLAYEROVALUE = 1;
        private int currentPlayerValue;

        public TicTacToe()
        {
            grid = new int[GRIDSIZE][];
            for (int i = 0; i < GRIDSIZE; i++)
            {
                grid[i] = new int[GRIDSIZE];
            }
            Reset();
        } 

        public string CurrentPlayer
        {
            get
            {
                if (currentPlayerValue == PLAYERXVALUE)
                    return "X";
                else
                    return "O";
            }
        }

        public int GetValue(int x, int y)
        {
            return grid[x][y];
        }

        private void SetGridValue(int x, int y, int value)
        {
            if ((x >= 0) && (x < GRIDSIZE) && (y >= 0) && (y < GRIDSIZE))
            {
                grid[x][y] = value;
            }
        }

        // Returns true if this space of the grid is still empty
        public bool EmptySpace(int x, int y)
        {
            return (grid[x][y] == NULLVALUE);
        }

        // Plays the next move on the specified place on the grid
        // and returns true if it is a winning move
        public bool Play(int x, int y)
        {
            SetGridValue(x, y, currentPlayerValue);
            bool victory = WinningMove(x,y,currentPlayerValue);
            currentPlayerValue = (currentPlayerValue + 1) % 2;
            return victory;
        }

        public void Reset()
        {
            for (int i = 0; i < GRIDSIZE; i++)
            {
                for (int j = 0; j < GRIDSIZE; j++)
                {
                    grid[i][j] = NULLVALUE;
                }
            }
            currentPlayerValue = PLAYERXVALUE;
        }

        private bool WinningMove(int x, int y, int value) {
            return (((grid[x][0] == grid[x][1]) && (grid[x][0] == grid[x][2]) && (grid[x][0] == value)) ||
                ((grid[0][y] == grid[1][y]) && (grid[0][y] == grid[2][y]) && (grid[0][y] == value)) ||
                ((grid[0][0] == grid[1][1]) && (grid[0][0] == grid[2][2]) && (grid[0][0] == value)) ||
                ((grid[0][2] == grid[1][1]) && (grid[0][2] == grid[2][0]) && (grid[0][2] == value)));
        }
    }
}
