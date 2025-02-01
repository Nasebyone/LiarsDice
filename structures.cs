namespace LiarsDice
{
    public struct bid
    {
        public int dice;
        public int count;

        public bool liar = false;

        public bid(int dice, int count)
        {
            this.dice = dice;
            this.count = count;
        }
    }

}