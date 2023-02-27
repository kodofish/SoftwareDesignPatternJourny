namespace C2M2H1_TemplateMethod.Uno
{
    using Bogus;
    public class Player
    {
        public string Name { get;
            protected private set; }
        public Hand Hand { get; }

        public Player()
        {
            Hand = new Hand();
        }

        public virtual void NamingSelf()
        {
            Name = (new Faker()).Person.FirstName;
        }

        public void DrawCard(Deck deck)
        {
            if (deck == null)
                throw new ArgumentNullException(nameof(deck));

            ReceiveCard(deck.Draw());
        }

        public override string ToString()
        {
            return $"{Name}: {Hand}";
        }
        
        public virtual Card TakeTurn(Card tableCard)
        {
            var card = Hand.DrawCard(tableCard);
            Console.WriteLine($"{Name} takes turn: {card}");
            return card;
        }
        public void ReceiveCard(Card card)
        {
            Hand.AddCard(card);
        }
    }
}