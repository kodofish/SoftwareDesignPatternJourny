namespace C2M2H1_TemplateMethod.Uno
{
    public class UnoDeck
    {
        internal Queue<UnoCard> _cards = new Queue<UnoCard>();
        private readonly List<UnoCard> _foldedCards = new List<UnoCard>();

        public UnoDeck()
        {
            foreach (Color color in Enum.GetValues(typeof(Color)))
            {
                if (color == Color.NONE)
                    continue;
                foreach (Number number in Enum.GetValues(typeof(Number)))
                {
                    if (number == Number.NONE)
                        continue;
                    _foldedCards.Add(new UnoCard(color, number));
                }
            }
        }

        public void Shuffle()
        {
            _cards = new Queue<UnoCard>(_cards.Concat( _foldedCards.OrderBy(x => Guid.NewGuid())));
            _foldedCards.Clear();
        }

        public UnoCard Draw()
        {
            if (_cards.Count == 0)
                Shuffle();
            
            return _cards.Dequeue();
        }
        
        public void Fold(UnoCard unoCard)
        {
            _foldedCards.Add(unoCard);
        }
    }
}