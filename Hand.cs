namespace LiarsDice {
    public class Hand {
        public List<Dice> dice { get; private set; } = new List<Dice>();

        public Hand(int diceCount) {
            for (int i = 0; i < diceCount; i++) {
                dice.Add(new Dice());
            }
        }

        public void RollHand() {
            foreach (Dice die in dice) {
                die.Roll();
            }
        }
        public void LoseDice() {
            dice.RemoveAt(0);
        }
        public List<int> GetValues() {
            List<int> values = new List<int>();
            foreach(Dice dice in dice) {
                values.Add(dice.Value);
            }
            values.Sort();
            return values;
        }
        
    }
}