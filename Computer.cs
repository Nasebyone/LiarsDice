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
            bid newbid = new bid(0, 0);
            double probAtLeastQ = ProbabilityAtLeast(totalDice, CurrentBid.count); // if the chance of dice call is under threshold call liar
            //Console.WriteLine($"Probability of at least {CurrentBid.count} dice showing the same face: {probAtLeastQ}");
            if ( !(CurrentBid.count == 0 && CurrentBid.dice == 0) && probAtLeastQ < 0.2) //check if liar call is possible (save resources) and a good move
            {
                newbid.count = CurrentBid.count;
                newbid.dice = CurrentBid.dice;
                newbid.liar = true;
                return newbid;
            }
            else
            {
                bool valid = false;
                while (valid == false)
                {
                    newbid = new bid(new Random().Next(1, 7), new Random().Next(1, totalDice));  // Basic AI making a random bid
                    
                    
                    if ((newbid.dice > CurrentBid.dice && newbid.count >= CurrentBid.count) || (newbid.count > CurrentBid.count && newbid.dice == CurrentBid.dice))
                    {
                        return newbid;
                    }
                    else
                    {
                        Console.WriteLine($"Computer trying again - {newbid.count} {newbid.dice}'s");
                    }
                }
                return new bid(1, 1); //fail case

            }
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