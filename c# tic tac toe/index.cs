using System;

namespace TicTacToe
{
    class Program
    {
        static char[,] board = new char[3, 3]; // the tic tac toe board
        
        static char currentPlayer = 'X'; // the current player
        
        static void Main(string[] args)
        {
            InitializeBoard();
            PlayGame();
        }

        static void InitializeBoard()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j] = ' ';
                }
            }
        }

        static void PlayGame()
        {
            int moveCount = 0;
            while (true)
            {
                DisplayBoard();
                Console.WriteLine("It is " + currentPlayer + "'s turn.");
                Console.Write("Enter row number (0-2): ");
                int row = int.Parse(Console.ReadLine());
                Console.Write("Enter column number (0-2): ");
                int col = int.Parse(Console.ReadLine());

                if (board[row, col] != ' ')
                {
                    Console.WriteLine("That cell is already occupied. Please try again.");
                    continue;
                }

                board[row, col] = currentPlayer;
                moveCount++;

                if (IsWinningMove(row, col))
                {
                    DisplayBoard();
                    Console.WriteLine(currentPlayer + " wins!");
                    break;
                }
                else if (moveCount == 9)
                {
                    DisplayBoard();
                    Console.WriteLine("The game is a tie.");
                    break;
                }
                else
                {
                    currentPlayer = (currentPlayer == 'X') ? 'O' : 'X';
                }
            }
        }

        static void DisplayBoard()
        {
            Console.WriteLine("  0 1 2");
            Console.WriteLine("0 " + board[0, 0] + "|" + board[0, 1] + "|" + board[0, 2]);
            Console.WriteLine("  -----");
            Console.WriteLine("1 " + board[1, 0] + "|" + board[1, 1] + "|" + board[1, 2]);
            Console.WriteLine("  -----");
            Console.WriteLine("2 " + board[2, 0] + "|" + board[2, 1] + "|" + board[2, 2]);
        }

        static bool IsWinningMove(int row, int col)
        {
            // check row
            if (board[row, 0] == board[row, 1] && board[row, 1] == board[row, 2])
            {
                return true;
            }

            // check column
            if (board[0, col] == board[1, col] && board[1, col] == board[2, col])
            {
                return true;
            }

            // check diagonal
            if (board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2])
            {
                return true;
            }
            if (board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0])
            {
                return true;
            }

            return false;
        }
    }
}
