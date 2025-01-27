using System.Diagnostics;
namespace LiarsDice
{
    public class Computer : Player
    {
        public Computer(string name, int diceCount) : base(name, diceCount)
        {
            IsHuman = false;
        }

        public override bid MakeBid(bid CurrentBid)
        {
            bid bid = new bid(new Random().Next(1, 6), new Random().Next(1, 6));  // Basic AI making a random bid
            Console.WriteLine($"{Name} (AI) bids {bid}");
            return bid;
        }

        private string GetDebuggerDisplay()
        {
            return ToString();
        }
    }
}