namespace LiarsDice {
    public class Dice {
        public int Value { get; private set; }

        public Dice() {
            Value = new System.Random().Next(1, 7);
        }

        public void Roll() {
            Value = new System.Random().Next(1, 7);
        }
    }
}