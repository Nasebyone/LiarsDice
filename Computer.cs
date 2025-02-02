using System.Diagnostics;
namespace LiarsDice
{
    public class Computer : Player
    {
        public Computer(string name, int diceCount) : base(name, diceCount)
        {
            IsHuman = false;
        }

        public override bid MakeBid(bid CurrentBid, int totalDice)
        {
            Random rand = new Random();
            bid newbid = new bid(0, 0);
            int myDiceCount = CountMyDice(CurrentBid.dice); // Get how many of the current dice computer has
            double probAtLeastQ = ProbabilityAtLeast(totalDice, CurrentBid.count);

            // Consider calling liar if probability is too low
            double liarThreshold = Math.Max(0.15, 0.4 - 0.02 * totalDice);  //adjustable threshold to balance smaller games (fewer players / dice)
            Console.WriteLine($"Probability of at least {CurrentBid.count} {CurrentBid.dice}'s: {probAtLeastQ}, threshold to call liar: {liarThreshold}");
            if (!(CurrentBid.count == 0 && CurrentBid.dice == 0) && probAtLeastQ < liarThreshold)
            {
                newbid.count = CurrentBid.count;
                newbid.dice = CurrentBid.dice;
                newbid.liar = true;
                return newbid;
            }

            // Aim for a smarter bid instead of completely random
            int newCount = CurrentBid.count;
            int newDice = CurrentBid.dice;

            // not great strategy but works for now

            // If computer has at least 1 of the current bid's dice, increase count
            if (myDiceCount > 0)
            {
                newCount += rand.Next(1, 3); // Small, strategic increase
            }
            else
            {
                newDice = rand.Next(1, 7); // Change dice face randomly
                newCount = Math.Max(CurrentBid.count, myDiceCount + rand.Next(1, 3)); // Base count on computers dice

                if (newDice <= CurrentBid.dice) // If new dice is lower than current dice, increase count to ensure bid is valid
                {
                    newDice = CurrentBid.dice;
                    newCount = CurrentBid.count + rand.Next(1, 3);
                }
            }

            return new bid(newDice, newCount);
        }

        // Function to count how many of a given dice face computer has
        private int CountMyDice(int faceValue)
        {
            return Hand.dice.Count(d => d.Value == faceValue); 
        }

        static double BinomialProbability(int n, int q)
        {
            return BinomialCoefficient(n, q) * Math.Pow(1.0 / 6, q) * Math.Pow(5.0 / 6, n - q);
        }

        static double BinomialCoefficient(int n, int k)
        {
            if (k > n) return 0;
            return Factorial(n) / (Factorial(k) * Factorial(n - k));
        }

        static double Factorial(int num)
        {
            if (num == 0) return 1;
            double result = 1;
            for (int i = 1; i <= num; i++)
                result *= i;
            return result;
        }
        static double ProbabilityAtLeast(int n, int q)
        {
            double sum = 0;
            for (int k = q; k <= n; k++)
            {
                sum += BinomialProbability(n, k);
            }
            return sum;
        }


    }
}


