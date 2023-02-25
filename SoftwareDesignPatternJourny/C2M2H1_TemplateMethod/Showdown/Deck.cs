namespace C2M2H1_TemplateMethod.Showdown
{
    public class Deck
    {
        private Queue<PokerCard> _cards;
        private readonly PokerCard[] _originalCard;

        public Deck(IEnumerable<PokerCard> cards)
        {
            if (cards == null)
                throw new ArgumentNullException(nameof(cards));
            _cards = new Queue<PokerCard>();
            _originalCard = cards.ToArray();
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
    }
}