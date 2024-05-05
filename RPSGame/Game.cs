namespace RPSGame
{
    public class Game
    {
        private int ComputerScore { get; set; }
        private int PlayerScore { get; set; }
        private GameRender render;

        public Game()
        {
            render = new GameRender();
        }

        public void Run()
        {
            while (true)
            {
                render.DrawMenu(PlayerScore, ComputerScore);

                var computerGesture = GetRandomGesture();
                var playerGesture = GetPlayerGesture();

                render.DrawResult(playerGesture, computerGesture);
                GetResult(playerGesture, computerGesture);
                Thread.Sleep(3000);

                if (PlayerScore == 3 && ComputerScore != 3)
                {
                    Console.WriteLine("You've won!");
                    break;
                }
                else if (PlayerScore != 3 && ComputerScore == 3)
                {
                    Console.WriteLine("Computer has won!");
                    break;
                }
                else if (PlayerScore == 3 && ComputerScore == 3)
                {
                    Console.WriteLine("Draw!");
                    break;
                }

                Console.WriteLine("Do you want to play again? (yes/no)");
                if (Console.ReadLine().ToLower() != "yes")
                {
                    break;
                }

                PlayerScore = 0;
                ComputerScore = 0;
            }
        }

        private Gestures GetRandomGesture()
        {
            var random = new Random();
            var gesture = random.Next(1, 4);
            return (Gestures)gesture;
        }

        private Gestures GetPlayerGesture()
        {
            Console.WriteLine("Enter your gesture (1: Rock, 2: Paper, 3: Scissors):");
            if (int.TryParse(Console.ReadLine(), out int gesture))
            {
                if (gesture >= 1 && gesture <= 3)
                {
                    return (Gestures)gesture;
                }
            }

            Console.WriteLine("Invalid gesture input.");
            return Gestures.None;
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
                    break;
            }
        }
    }
}
