namespace C2M2H1_TemplateMethod.Uno
{
    public class EmptyCard : Card
    {
        public EmptyCard()
            : base(Color.NONE, Number.NONE)
        {
        }

        public override string ToString()
        {
            return "The card is empty";
        }
    }
}