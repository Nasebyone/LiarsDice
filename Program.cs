using System.ComponentModel;

namespace LiarsDice {
    public class Game() {
        private int players;
        private int diceCount;
        private List<Hand> hands;

        public void Start(){
            Console.WriteLine("How many players are ye");
            players = int.Parse(Console.ReadLine());
            Console.WriteLine("How many dice are ye playing with");
            diceCount = int.Parse(Console.ReadLine());

            for (int i=0; i<players; i++){
                hands.Add(new Hand(diceCount));
            }
        }
        public void Turn(){
            foreach (Hand hand in hands){
                hand.RollHand();
            }
        }

    }
    static void main(string[] args) {
        Game game = new Game();
    }
}