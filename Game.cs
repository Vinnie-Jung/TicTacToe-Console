using System;

namespace TicTacToe__Console_
{
    class Game
    {
        private char turn = 'X';
        private char[,] board = new char[3, 3];
        private bool game_over = false;
        private int empty_squares = 9;

        public Game()
        {
            NewBoard();

            PrintBoard();
            do
            {
                Play();
                this.empty_squares--;
                ChangeTurn();
                PrintBoard();
                CheckGameOver();
            } while (this.game_over == false);
        }

        // Turn Methods
        #region TurnFeatures
        private void ChangeTurn() // Changes player turn
        {
            if (this.turn == 'X')
                this.turn = 'O';
            else
                this.turn = 'X';
        }

        private void TurnIndicator() // Informs who will play
        {
            switch (this.turn)
            {
                case 'X':
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("\nTURN: X\n");
                    Console.ResetColor();
                    break;
                
                case 'O':
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nTURN: O\n");
                    Console.ResetColor();
                    break;
            }
        }

        #endregion

        // Board Methods
        #region BoardFeatures
        private void NewBoard() // Resets board
        {
            for (int line = 0; line < 3; line++)
            {
                for (int column = 0; column < 3; column++)
                {
                    this.board[line, column] = ' ';
                }
            }
        }

        private void PrintBoard()
        {
            Console.Clear();

            Console.WriteLine("     C1    C2    C3");
            for (int line = 0; line < 3; line++)
            {
                Console.Write($"L{line + 1} | ");
                for (int column = 0; column < 3; column++)
                {
                    Console.Write(board[line, column] + "  |  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        #endregion

        private void Play() // Player move
        {
            int line_selected = 0;
            int column_selected = 0;
            bool invalid_choice = true;

            do
            {
                TurnIndicator();

                Console.Write("Line: ");
                line_selected = Convert.ToInt32(Console.ReadLine()) - 1;

                Console.Write("Column: ");
                column_selected = Convert.ToInt32(Console.ReadLine()) - 1;

                if (line_selected < 0 || line_selected > 2 || column_selected < 0 || column_selected > 2)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid position !!!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else if (this.board[line_selected, column_selected] != ' ')
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Position already chosen !!!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
                else invalid_choice = false;
                
            } while (invalid_choice == true);

            this.board[line_selected, column_selected] = this.turn;
        }

        private void CheckGameOver() // End Game Validation
        {
            // Line or Column Validation
            for (int line = 0; line < 3; line++)
            {
                if (this.board[line, 0] == 'X' && this.board[line, 1] == 'X' && this.board[line, 2] == 'X')
                {
                    this.game_over = true;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("X WON !!!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }

            for (int column = 0; column < 3; column++)
            {
                if (this.board[0, column] == 'X' && this.board[1, column] == 'X' && this.board[2, column] == 'X')
                {
                    this.game_over = true;

                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    Console.WriteLine("X WON !!!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }

            for (int line = 0; line < 3; line++)
            {
                if (this.board[line, 0] == 'O' && this.board[line, 1] == 'O' && this.board[line, 2] == 'O')
                {
                    this.game_over = true;

                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("O WON !!!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }

            for (int column = 0; column < 3; column++)
            {
                if (this.board[0, column] == 'O' && this.board[1, column] == 'O' && this.board[2, column] == 'O')
                {
                    this.game_over = true;
                    
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("O WON !!!");
                    Console.ResetColor();
                    Console.ReadKey();
                }
            }
            
            // Diagonal Validation
            if (this.board[0, 0] == 'X' && this.board[1, 1] == 'X' && this.board[2, 2] == 'X')
            {
                this.game_over = true;
                    
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("X WON !!!");
                Console.ResetColor();
                Console.ReadKey();
            }
            else if (this.board[2, 0] == 'X' && this.board[1, 1] == 'X' && this.board[0, 2] == 'X')
            {
                this.game_over = true;
                    
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("X WON !!!");
                Console.ResetColor();
                Console.ReadKey();
            }
            else if (this.board[0, 0] == 'O' && this.board[1, 1] == 'O' && this.board[2, 2] == 'O')
            {
                this.game_over = true;
                    
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("O WON !!!");
                Console.ResetColor();
                Console.ReadKey();
            }
            else if (this.board[2, 0] == 'O' && this.board[1, 1] == 'O' && this.board[0, 2] == 'O')
            {
                this.game_over = true;
                    
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("O WON !!!");
                Console.ResetColor();
                Console.ReadKey();
            }

            // Tie Validation
            if (this.game_over == false && this.empty_squares == 0)
            {
                this.game_over = true;
                    
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("TIE !!!");
                Console.ResetColor();
                Console.ReadKey();
            }
        }
    }
}