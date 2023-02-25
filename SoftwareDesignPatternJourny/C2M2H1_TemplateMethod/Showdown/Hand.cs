namespace C2M2H1_TemplateMethod.Showdown
{
    public class Hand : List<PokerCard>
    {
        public PokerCard Draw()
        {
            var card = this[0];
            RemoveAt(0);
            return card;
        }
    }
}