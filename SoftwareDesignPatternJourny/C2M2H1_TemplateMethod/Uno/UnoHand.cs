namespace C2M2H1_TemplateMethod.Uno
{
    public class UnoHand
    {
        private readonly List<UnoCard> _cards;

        public UnoHand()
        {
            _cards = new List<UnoCard>();
        }
        
        public void AddCard(UnoCard unoCard)
        {
            _cards.Add(unoCard);
            
        }

        public override string ToString()
        {
            return string.Join(", ", _cards);
        }
        public UnoCard DrawCard(UnoCard tableUnoCard)
        {
            if (_cards.Count == 0)
                throw new InvalidOperationException("No card in hand");

            var availableCard = _cards.FirstOrDefault(it => it.CompareTo(tableUnoCard) == 0);
            if (availableCard == null)
                return UnoCard.EmptyCard();

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