namespace C2M2H1_TemplateMethod.Framework
{
    public abstract class DeckBase<T>
    {
        internal Queue<T> _cards = new Queue<T>();
        internal List<T> _foldedCards = new List<T>();
        public virtual void Shuffle()
        {
            _cards = new Queue<T>((_foldedCards.OrderBy(x => Guid.NewGuid())));
        }
        
        public virtual T Draw()
        {
            return _cards.Dequeue();
        }

        public abstract IEnumerable<T> GenerateCard();
        
        }
}