using LiarsDice;

public abstract class Player
{

    
    public string Name { get; set; }
    public Hand Hand { get; private set; }
    public bool IsHuman { get; protected set; }

    public Player(string name, int dice)
    {
        Name = name;
        Hand = new Hand(dice);
        Hand.RollHand();
    }

    public void RollDice()
    {
        Hand.RollHand();
    }

    public void LoseDie()
    {
        Hand.LoseDice();
    }

    public abstract bid MakeBid(bid CurrentBid, int totalDice);  // Abstract method to be implemented by subclasses
}