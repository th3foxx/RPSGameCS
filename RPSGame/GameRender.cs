namespace RPSGame;

public class GameRender
{
    private readonly string[] _gestureArts = new string[3] {@"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)", @"     _______
---'    ____)____
           ______)
          _______)
         _______)
---.__________)", @"    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)"};
    
    private void DrawGesture(Gestures gesture)
    {
        switch (gesture)
        {
            case Gestures.Rock:
                Console.WriteLine(_gestureArts[0]);
                break;
            case Gestures.Paper:
                Console.WriteLine(_gestureArts[1]);
                break;
            case Gestures.Scissors:
                Console.WriteLine(_gestureArts[2]);
                break;
        }
    }

    public void DrawMenu(int playerScore, int computerScore)
    {
        Console.Clear();
        Console.WriteLine($"Player score: {playerScore} | Computer score: {computerScore}");
        Console.WriteLine("****************************");
        Console.WriteLine("*The gesture selection menu*");
        Console.WriteLine("****************************");
        Console.WriteLine("*1 - Rock                  *");
        Console.WriteLine("*2 - Scissors              *");
        Console.WriteLine("*3 - Paper                 *");
        Console.WriteLine("****************************");
        Console.Write("Pick a gesture: ");
    }

    public void DrawResult(Gestures playerGesture, Gestures computerGesture)
    {
        Console.Clear();
        Console.WriteLine("Player: ");
        DrawGesture(playerGesture);
        Console.WriteLine("Computer: ");
        DrawGesture(computerGesture);
    }
    
    public Gestures GetGesture(int gesture) =>
        gesture switch { 1 => Gestures.Rock, 2 => Gestures.Scissors, 3 => Gestures.Paper };
}