namespace C2M2H1_TemplateMethod.Framework
{
    public class HandBase<T> : List<T> where T : CardBase<T>
    {
        public override string ToString()
        {
            return string.Join(", ", this);
        }

        public virtual T DrawCard(T? card = default)
        {
            if (Count == 0)
                throw new InvalidOperationException("No card in hand");

            var index = 0;

            if (card == null)
                card = this[index];
            else
                index = IndexOf(card);

            RemoveAt(index);

            return card;
        }
    }
}