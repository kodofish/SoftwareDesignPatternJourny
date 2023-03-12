namespace C2M2H1_TemplateMethod.Uno
{
    public record EmptyUnoCard() : UnoCard(Color.NONE, Number.NONE)
    {
        public override string ToString()
        {
            return "The card is empty";
        }
    }
}