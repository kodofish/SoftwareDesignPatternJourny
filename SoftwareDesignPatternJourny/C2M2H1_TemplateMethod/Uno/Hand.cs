namespace C2M2H1_TemplateMethod.Uno
{
    public class Hand
    {
        private readonly List<Card> _cards;

        public Hand()
        {
            _cards = new List<Card>();
        }
        
        public void AddCard(Card card)
        {
            _cards.Add(card);
            
        }

        public override string ToString()
        {
            return string.Join(", ", _cards);
        }
        public Card DrawCard(Card tableCard)
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("No card in hand");

            var availableCard = _cards.FirstOrDefault(it => it.CompareTo(tableCard) == 0);
            if (availableCard == null)
                return new EmptyCard();

            var index = _cards.IndexOf(availableCard);
            _cards.RemoveAt(index);

            return availableCard;
        }

        public int Count()
        {
            return _cards.Count;
        }
    }
}