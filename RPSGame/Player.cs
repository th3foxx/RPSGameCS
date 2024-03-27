namespace RPSGame;

public static class Player
{
    public static int MakeChoice()
    {
        while (true)
        {
            var success = int.TryParse(Console.ReadLine(), out int playerChoice);

            if (success && playerChoice < 4)
            {
                return playerChoice;
            }
            else
            {
                Console.WriteLine("You have entered an invalid value!");
                Console.Write("Try again: ");
            }
            
        }
        
    }
    
}