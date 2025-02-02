using System.ComponentModel;

namespace LiarsDice
{

    public class Game()
    {
        private int diceCount;
        List<Player> players = new List<Player>();
        int humanCount;
        int computerCount;

        private int roundCounter = 1;
        int playerTracker = 0;

        int totalDice = 0;

        private bid currentBid;

        public void Start()
        {
            Console.Write("How many human players are ye?: ");
            humanCount = int.Parse(Console.ReadLine());
            Console.Write("How many computers do yer want?: ");
            computerCount = int.Parse(Console.ReadLine());

            Console.Write("How many dice are ye playing with?: ");
            diceCount = int.Parse(Console.ReadLine());

            for (int i = 1; i <= humanCount; i++)
            {
                players.Add(new Human("Player " + i, diceCount));
            }
            for (int i = 1; i <= computerCount; i++)
            {
                players.Add(new Computer("AI Bot " + i, diceCount));
            }
            while (players.Count > 1)
            {
                Round(roundCounter);
                roundCounter++;
            }
            Console.WriteLine("\n" +players[0].Name + " wins the game!");
        }


        public void Round(int roundCounter)
        {
            Console.Clear();
            Console.WriteLine("=========================");
            Console.WriteLine("Round " + roundCounter);
            Console.WriteLine("=========================");
            currentBid = new bid();
            totalDice = 0;
            int tempValue = 0;
            foreach (Player player in players)
            {
                player.RollDice();
                totalDice += player.Hand.dice.Count;
            }
            // foreach (Player player in players)

            while (true)
            {


                currentBid = players[playerTracker].MakeBid(currentBid, totalDice);

                if (currentBid.liar)
                {

                    Console.WriteLine($"LIAAAARRRRR has been called by {players[playerTracker].Name}\n");
                    Console.WriteLine("revealing dice: \n");
                    Dictionary<int, int> totalDiceCounts = new Dictionary<int, int>();
                    foreach (Player p in players)
                    {
                        var diceCounts = p.Hand.GetValues().GroupBy(v => v)
                                        .Select(g => new { Value = g.Key, Count = g.Count() });
                        Console.WriteLine($" \n {p.Name}:");
                        foreach (var dice in diceCounts)
                        {
                            Console.WriteLine($"- {dice.Count} x {dice.Value}'s");
                            if (totalDiceCounts.ContainsKey(dice.Value))
                            {
                                totalDiceCounts[dice.Value] += dice.Count;
                            }
                            else
                            {
                                totalDiceCounts[dice.Value] = dice.Count;
                            }
                        }
                    }
                    Console.WriteLine("=========================");
                    Console.WriteLine("totals:");
                    Console.WriteLine($"current bid is {currentBid.count} {currentBid.dice}'s");
                    Console.WriteLine("=========================");
                    foreach (var dice in totalDiceCounts.OrderBy(d => d.Key))
                    {

                        if (dice.Key == currentBid.dice)
                        {
                            Console.WriteLine($"-> {dice.Value} x {dice.Key}'s <-");
                            tempValue = dice.Value;
                        }
                        else
                        {
                            Console.WriteLine($"-  {dice.Value} x {dice.Key}'s");
                        }

                    }
                    if (tempValue < currentBid.count)
                    {
                        Console.WriteLine($"{players[playerTracker].Name} was correct: {currentBid.count} {currentBid.dice}'s are not in play");
                        if (playerTracker == 0)
                        {
                            Console.WriteLine(players[players.Count - 1].Name + " loses a die");
                            players[players.Count - 1].LoseDie();

                            if (players[players.Count - 1].Hand.dice.Count == 0)
                            {
                                Console.WriteLine(players[players.Count - 1].Name + " has no dice left and is out of the game");
                                players.RemoveAt(players.Count - 1);

                            }
                        }
                        else
                        {
                            Console.WriteLine(players[playerTracker - 1].Name + " loses a die");
                            players[playerTracker - 1].LoseDie();

                             if (players[playerTracker - 1].Hand.dice.Count == 0)
                            {
                                Console.WriteLine(players[playerTracker - 1].Name + " has no dice left and is out of the game");
                                players.RemoveAt(playerTracker - 1);

                            }
                        }

                    }
                    else
                    {
                        Console.WriteLine($"{players[playerTracker].Name} was incorrect: {currentBid.count} {currentBid.dice}'s are in play");
                        Console.WriteLine($"{players[playerTracker].Name} loses a die");
                        players[playerTracker].LoseDie();
                        if (players[playerTracker].Hand.dice.Count == 0)
                            {
                                Console.WriteLine(players[playerTracker].Name + " has no dice left and is out of the game");
                                players.RemoveAt(playerTracker);

                            }
                    }

                    break;
                }
                Console.WriteLine($"\n//{players[playerTracker].Name} Current bid is {currentBid.count} {currentBid.dice}'s//\n");
                playerTracker++;
                if (playerTracker >= players.Count)
                {
                    playerTracker = 0;
                }

            }
            Console.Write("Press any key to continue: ");
            Console.ReadKey();



        }

        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}