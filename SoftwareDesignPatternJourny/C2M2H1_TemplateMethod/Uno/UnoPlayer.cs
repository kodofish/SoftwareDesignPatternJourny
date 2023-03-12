namespace C2M2H1_TemplateMethod.Uno
{
    using Bogus;
    public class UnoPlayer
    {
        public string Name { get;
            protected private set; }
        public UnoHand UnoHand { get; }

        public UnoPlayer()
        {
            UnoHand = new UnoHand();
        }

        public virtual void NamingSelf()
        {
            Name = (new Faker()).Person.FirstName;
        }

        public void DrawCard(UnoDeck unoDeck)
        {
            if (unoDeck == null)
                throw new ArgumentNullException(nameof(unoDeck));

            ReceiveCard(unoDeck.Draw());
        }

        public override string ToString()
        {
            return $"{Name}: {UnoHand}";
        }
        
        public virtual UnoCard TakeTurn(UnoCard tableUnoCard)
        {
            var card = UnoHand.DrawCard(tableUnoCard);
            Console.WriteLine($"{Name} takes turn: {card}");
            return card;
        }
        public void ReceiveCard(UnoCard unoCard)
        {
            UnoHand.AddCard(unoCard);
        }
    }
}