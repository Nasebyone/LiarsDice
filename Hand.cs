namespace LiarsDice {
    public class Hand {
        public List<Dice> Dice { get; private set; }

        public Hand(int diceCount) {
            for (int i = 0; i < diceCount; i++) {
                Dice[i] = new Dice();
            }
        }

        public void RollHand() {
            foreach (Dice die in Dice) {
                die.Roll();
            }
        }
        public List<Dice> GetDice() {
            return Dice;
        }
        public void LostDice() {
            Dice.RemoveAt(0);
        }
        public int DiceCount() {
            return Dice.Count;
        }
    }
}