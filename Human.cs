namespace LiarsDice
{
    public class Human : Player
    {
        public Human(string name, int diceCount) : base(name, diceCount)
        {
            IsHuman = true;
        }

        public override bid MakeBid(bid currentBid)
        {
            bool valid = false;
            while (!valid)
            {
                Console.WriteLine("--Enter ye bid----");
                Console.Write("Which dice are ye calling: ");
                int bidDice = int.Parse(Console.ReadLine());
                Console.Write("How many of them are there: ");
                int bidCount = int.Parse(Console.ReadLine());

                if (bidDice > currentBidDice || bidCount > currentBidDice)
                {
                    valid = true;
                    currentBidCount = bidCount;
                    currentBidDice = bidDice;
                }
                else
                {
                    Console.WriteLine($"Invalid bid. Either the dice must be higher than {currentBidDice} or count must be higher than {currentBidCount}.");
                }
            }
            return new bid(currentBidDice, currentBidCount);
        }
    }
}