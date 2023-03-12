namespace C2M2H1_TemplateMethod.Uno
{
    public class UnoCard : IComparable<UnoCard>
    {
        public Color Color { get; }
        public Number Number { get; }

        public UnoCard(Color color, Number number)
        {
            Color = color;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Color} {Number}";
        }
        public virtual int CompareTo(UnoCard? other)
        {
            var colorComparison = Color.CompareTo(other.Color);
            return colorComparison == 0 ? colorComparison : Number.CompareTo(other.Number) == 0 ? 0 : 1;
        }
        public static UnoCard EmptyCard()
        {
            return new EmptyUnoCard();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != GetType())
                return false;
            var other = (UnoCard) obj;
            return Color == other.Color && Number == other.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Color, Number);
        }
    }

}