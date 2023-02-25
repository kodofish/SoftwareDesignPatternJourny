namespace C2M2H1_TemplateMethod.Showdown
{
    public class Deck
    {
        private Queue<PokerCard> _cards;
        private readonly PokerCard[] _originalCard;

        public Deck()
        {
            _cards = new Queue<PokerCard>();
            _originalCard = GenerateCards().ToArray();
        }

        public PokerCard Draw()
        {
            return _cards.Dequeue();
        }

        public void Shuffle()
        {
            var rng = new Random();
            var randomCards = _originalCard.OrderBy(it => rng.NextDouble());
            _cards = new Queue<PokerCard>(randomCards);
        }

        private IEnumerable<PokerCard> GenerateCards()
        {
            foreach (var rank in Rank.GetValues(typeof(Rank)))
                foreach (var suit in Suit.GetValues(typeof(Suit)))
                    yield return new PokerCard((Suit)suit, (Rank)rank);
        }
    }
}