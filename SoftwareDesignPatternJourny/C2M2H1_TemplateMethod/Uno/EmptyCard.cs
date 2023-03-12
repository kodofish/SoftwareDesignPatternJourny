namespace C2M2H1_TemplateMethod.Uno
{
    public class EmptyUnoCard : UnoCard
    {
        public EmptyUnoCard()
            : base(Color.NONE, Number.NONE)
        {
        }

        public override string ToString()
        {
            return "The card is empty";
        }
    }
}