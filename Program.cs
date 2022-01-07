using System;

namespace TicTacToe__Console_
{
    class Program
    {
        static void Main(string[] args)
        {
            int menu_choice = 0;

            while (true)
            {
                MainMenu();
                menu_choice = Convert.ToInt32(Console.ReadLine());

                MenuActionTaken(menu_choice);
            }
        }

        static void MainMenu()
        {
            Console.Clear();

            Console.WriteLine("===============");
            Console.WriteLine("   MAIN MENU\n");
            Console.WriteLine("1) New Game");
            Console.WriteLine("2) Rules");
            Console.WriteLine("3) Exit");
            Console.WriteLine("===============");
            Console.Write("Choice: ");
        }

        static void MenuActionTaken(int menu_choice)
        {
            Console.Clear();
            switch (menu_choice)
            {
                // Starts a new game
                case 1:
                    Game new_game = new Game();
                    break;

                // Show rules from Rules.txt
                case 2:
                    Rules.ReadDocument();
                    break;

                // Exit program
                case 3:
                    Environment.Exit(0);
                    break;

                // Shows a invalid choice message if chosen option selected in menu isn't true
                default:
                    Console.ForegroundColor = ConsoleColor.Red;

                    Console.WriteLine("Invalid choice !!!");

                    Console.ResetColor();
                    Console.ReadKey();
                    Console.Clear();
                    break;
            }
        }
    }
}