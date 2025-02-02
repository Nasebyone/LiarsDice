namespace LiarsDice
{
    public class Human : Player
    {
        public Human(string name, int diceCount) : base(name, diceCount)
        {
            IsHuman = true;
        }

        public override bid MakeBid(bid currentBid, int totalDice)
        {
            bid newbid = new bid();
            bool valid = false;
            while (!valid)
            {

                Console.WriteLine($"--- {Name}'s turn ---");
                Console.WriteLine($"Your Dice:");
                // foreach (Dice dice in Hand.dice){
                //     Console.WriteLine($"- {dice.Value}" );
                // }
                var diceCounts = Hand.GetValues().GroupBy(v => v)
                                    .Select(g => new { Value = g.Key, Count = g.Count() });

                foreach (var dice in diceCounts)
                {
                    Console.WriteLine($"- {dice.Count} x {dice.Value}'s");
                }
                if (currentBid.count == 0 && currentBid.dice == 0)
                {
                    Console.WriteLine($"\n-- Enter ye bid ----");
                }
                else
                {
                    Console.WriteLine($"\ncurrent bid is {currentBid.count} {currentBid.dice}'s \n-- Enter ye bid ----");
                }

                if (currentBid.count == 0 && currentBid.dice == 0) //check if a prior bid exists to call liar to
                {
                    Console.WriteLine("What dice number are ye calling: ");
                }
                else  {
                        Console.Write("Which dice number are ye calling or enter (l)iar: ");
                }
                

                string input = Console.ReadLine();
                int bidDice = 0;
                if (input.ToLower() == "l" || input.ToLower() == "liar")
                {
                    // Handle liar case
                    return new bid { count = currentBid.count, dice = currentBid.dice, liar = true };
                }
                else
                {
                    bidDice = int.Parse(input);
                }
                Console.Write("How many of them are there: ");
                int bidCount = int.Parse(Console.ReadLine());

                //if ((bidDice > currentBid.dice && bidCount >= currentBid.count) || (bidCount > currentBid.count && bidDice == currentBid.dice))
                if ((bidCount > currentBid.count) || (bidDice > currentBid.dice && bidCount >= currentBid.count))
                {
                    valid = true;
                    newbid.count = bidCount;
                    newbid.dice = bidDice;
                    newbid.liar = false;
                }
                else
                {
                    Console.WriteLine($"Invalid bid. Either the dice must be higher than {currentBid.dice} or count must be higher than {currentBid.count}.");
                }
            }
            return newbid;
        }
    }
}