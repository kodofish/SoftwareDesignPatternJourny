namespace C2M2H1_TemplateMethod.Uno
{
    using Framework;

    public abstract class UnoPlayer : PlayerBase<UnoHand, UnoCard>
    {
        public void DrawCard(UnoDeck unoDeck)
        {
            if (unoDeck == null)
                throw new ArgumentNullException(nameof(unoDeck));

            ReceiveCard(unoDeck.Draw());
        }

        public UnoCard TakeTurn(UnoCard tableUnoCard)
        {
            var card = Hand.DrawCard(tableUnoCard);
            Console.WriteLine($"{Name} takes turn: {card}");
            return card;
        }
    }
}