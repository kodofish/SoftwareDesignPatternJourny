namespace C2M2H1_TemplateMethod.Uno
{
    public class Deck
    {
        internal Queue<Card> _cards = new Queue<Card>();
        private readonly List<Card> _foldedCards = new List<Card>();

        public Deck()
        {
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                if (color == Color.NONE)
                    continue;
                foreach (Number number in Enum.GetValues(typeof(Number)))
                {
                    if (number == Number.NONE)
                        continue;
                    _foldedCards.Add(new Card(color, number));
                }
            }
        }

        public void Shuffle()
        {
            _cards = new Queue<Card>(_cards.Concat( _foldedCards.OrderBy(x => Guid.NewGuid())));
            _foldedCards.Clear();
        }

        public Card Draw()
        {
            if (_cards.Count == 0)
                Shuffle();
            
            return _cards.Dequeue();
        }
        
        public void Fold(Card card)
        {
            _foldedCards.Add(card);
        }
    }
}