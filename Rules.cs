using System.IO;
using System;

namespace TicTacToe__Console_
{
    class Rules
    {
        public static void ReadDocument()
        {
            try
            {
                StreamReader archive = new StreamReader("Rules.txt");
                string line = archive.ReadLine();

                while (line != null)
                {
                    Console.WriteLine(line);
                    line = archive.ReadLine();
                }

                archive.Close();
                Console.ReadKey();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exeption: " + e.Message);
                Console.ReadKey();
            }
        }
    }
}
