namespace RPSGame;

public class Game
{
    private int ComputerScore { get; set; }
    private int PlayerScore { get; set; }

    public void Run()
    {
        var render = new GameRender();
        
        while (true)
        {
            render.DrawMenu(PlayerScore, ComputerScore);
            
            var computerGesture = render.GetGesture(new Random().Next(1, 3));
            var playerGesture = render.GetGesture(Player.MakeChoice());
            
            render.DrawResult(playerGesture, computerGesture);
            GetResult(playerGesture, computerGesture);
            Thread.Sleep(3000);
            
            if (PlayerScore == 3 && ComputerScore != 3)
            {
                Console.WriteLine("You've won!");
                return;
            }
            else if (PlayerScore != 3 && ComputerScore == 3)
            {
                Console.WriteLine("Computer has won!");
                return;
            }
            else if (PlayerScore == 3 && ComputerScore == 3)
            {
                Console.WriteLine("Draw!");
                return;
            }
        }
        
    }

    private void GetResult(Gestures playerGesture, Gestures computerGesture)
    {
        switch (playerGesture)
        {
            case Gestures.Rock when computerGesture == Gestures.Scissors:
            case Gestures.Paper when computerGesture == Gestures.Rock:
            case Gestures.Scissors when computerGesture == Gestures.Paper:
                Console.WriteLine("You've won the round!");
                PlayerScore++;
                break;
            case Gestures.Scissors when computerGesture == Gestures.Rock:
            case Gestures.Rock when computerGesture == Gestures.Paper:
            case Gestures.Paper when computerGesture == Gestures.Scissors:
                Console.WriteLine("Computer has won the round!");
                ComputerScore++;
                break;
            default:
                Console.WriteLine("Draw!");
                PlayerScore++;
                ComputerScore++;
                break;
        }
    }
}