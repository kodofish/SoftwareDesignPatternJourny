namespace C2M2H1_TemplateMethod.Showdown
{
    using Framework;
    public class PokerDeck: DeckBase<PokerCard>
    {
        public PokerDeck()
        {
            _foldedCards = GenerateCard().ToList();
        }

        public override PokerCard Draw()
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("Should shuffle first");

            return base.Draw();
        }
        
        public sealed override IEnumerable<PokerCard> GenerateCard()
        {
            foreach (var rank in Rank.GetValues(typeof(Rank)))
                foreach (var suit in Suit.GetValues(typeof(Suit)))
                    yield return new PokerCard((Suit)suit, (Rank)rank);
        }
    }
}