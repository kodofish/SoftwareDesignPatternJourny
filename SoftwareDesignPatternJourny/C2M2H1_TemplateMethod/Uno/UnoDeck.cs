namespace C2M2H1_TemplateMethod.Uno
{
    using Framework;
    public class UnoDeck : DeckBase<UnoCard>
    {
        public UnoDeck()
        {
            _foldedCards = GenerateCard().ToList();
        }

        public sealed override IEnumerable<UnoCard> GenerateCard()
        {
            return from Color color in Enum.GetValues(typeof(Color))
                   where color != Color.NONE
                   from Number number in Enum.GetValues(typeof(Number))
                   where number != Number.NONE
                   select new UnoCard(color, number);
        }

        public override void Shuffle()
        {
            base.Shuffle();
            _foldedCards.Clear();
        }

        public override UnoCard Draw()
        {
            if (_cards.Count == 0)
                Shuffle();

            return base.Draw();
        }

        public void Fold(UnoCard unoCard)
        {
            _foldedCards.Add(unoCard);
        }
    }
}