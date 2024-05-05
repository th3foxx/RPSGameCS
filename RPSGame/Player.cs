using System;

namespace RPSGame
{
    public static class Player
    {
        public static int MakeChoice()
        {
            while (true)
            {
                Console.Write("Enter your choice (1: Rock, 2: Paper, 3: Scissors): ");

                if (int.TryParse(Console.ReadLine(), out int playerChoice) && playerChoice > 0 && playerChoice < 4)
                {
                    return playerChoice;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid choice.");
                }
            }
        }
    }
}
