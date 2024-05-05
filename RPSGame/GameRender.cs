using System;

namespace RPSGame
{
    public class GameRender
    {
        private readonly string[] _gestureArts = new string[3]
        {
            @"    _______
---'   ____)
      (_____)
      (_____)
      (____)
---.__(___)",
            @"     _______
---'    ____)____
           ______)
          _______)
         _______)
---.__________)",
            @"    _______
---'   ____)____
          ______)
       __________)
      (____)
---.__(___)"
        };

        private void DrawGesture(Gestures gesture)
        {
            switch (gesture)
            {
                case Gestures.ROCK:
                    Console.WriteLine(_gestureArts[0]);
                    break;
                case Gestures.SCISSORS:
                    Console.WriteLine(_gestureArts[1]);
                    break;
                case Gestures.PAPER:
                    Console.WriteLine(_gestureArts[2]);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(gesture));
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
            DrawWinner(GetWinner(playerGesture, computerGesture));
        }

        public void DrawWinner(Winners winner)
        {
            switch (winner)
            {
                case Winners.PLAYER:
                    Console.WriteLine("You win this round!");
                    break;
                case Winners.COMPUTER:
                    Console.WriteLine("Computer wins this round!");
                    break;
                case Winners.DRAW:
                    Console.WriteLine("This round is a draw!");
                    break;
            }
        }

        public Gestures GetGesture(int gesture) => gesture switch
        {
            1 => Gestures.ROCK,
            2 => Gestures.SCISSORS,
            3 => Gestures.PAPER,
            _ => throw new ArgumentOutOfRangeException(nameof(gesture))
        };

        public Gestures GetComputerGesture() =>
            (Gestures)new Random().Next(3) + 1;

        public Winners GetWinner(Gestures playerGesture, Gestures computerGesture)
        {
            if (playerGesture == computerGesture)
            {
                return Winners.DRAW;
            }

            switch (playerGesture)
            {
                case Gestures.ROCK:
                    return computerGesture == Gestures.SCISSORS
                        ? Winners.PLAYER
                        : Winners.COMPUTER;
                case Gestures.PAPER:
                    return computerGesture == Gestures.ROCK
                        ? Winners.PLAYER
                        : Winners.COMPUTER;
                case Gestures.SCISSORS:
                    return computerGesture == Gestures.PAPER
                        ? Winners.PLAYER
                        : Winners.COMPUTER;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }

    public enum Gestures
    {
        ROCK,
        PAPER,
        SCISSORS
    }

    public enum Winners
    {
        PLAYER,
        COMPUTER,
        DRAW
    }
}
