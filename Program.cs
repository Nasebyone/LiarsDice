using System.ComponentModel;

namespace LiarsDice
{

    public class Game()
    {
        private int diceCount;
        List<Player> players = new List<Player>();
        int humanCount;
        int computerCount;

        private int rounds = 5;

        private bid currentBid;

        public void Start()
        {
            Console.Write("How many players are ye?: ");
            humanCount = int.Parse(Console.ReadLine());
            Console.Write("How many computers do you want?: ");
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
            for (int i = 0; i <= rounds; i++)
            {
                Round();
            }
        }


        public void Round()
        {
            foreach (Player player in players)
            {
                player.RollDice();
                currentBid = player.MakeBid(currentBid);
            }
            
            Console.WriteLine("Current bid is " + currentBid.count + " " + currentBid.dice + "'s");
        }

        static void Main(string[] args)
        {
            Game game = new Game();
            game.Start();
        }
    }
}