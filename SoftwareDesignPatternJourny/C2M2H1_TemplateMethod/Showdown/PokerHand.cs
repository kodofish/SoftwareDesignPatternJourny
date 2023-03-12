namespace C2M2H1_TemplateMethod.Showdown
{
    public class PokerHand : List<PokerCard>
    {
        public PokerCard RandomDraw()
        {
            if (Count == 0)
                throw new InvalidOperationException("No card in hand");
            
            var rnd = new Random();
            var index = rnd.Next(Count);
            var card = this[index];
            RemoveAt(index);
            return card;
        }
    }
}