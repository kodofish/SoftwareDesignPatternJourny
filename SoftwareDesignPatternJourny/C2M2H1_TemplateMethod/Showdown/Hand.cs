namespace C2M2H1_TemplateMethod.Showdown
{
    public class Hand : List<PokerCard>
    {
        public PokerCard RandomDraw()
        {
            var rnd = new Random();
            var index = rnd.Next(Count);
            var card = this[index];
            RemoveAt(index);
            return card;
        }
    }
}