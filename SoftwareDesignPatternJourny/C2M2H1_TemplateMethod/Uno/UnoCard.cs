namespace C2M2H1_TemplateMethod.Uno
{
    public class Card : IComparable<Card>
    {
        public Color Color { get; }
        public Number Number { get; }

        public Card(Color color, Number number)
        {
            Color = color;
            Number = number;
        }

        public override string ToString()
        {
            return $"{Color} {Number}";
        }
        public virtual int CompareTo(Card? other)
        {
            var colorComparison = Color.CompareTo(other.Color);
            return colorComparison == 0 ? colorComparison : Number.CompareTo(other.Number) == 0 ? 0 : 1;
        }
        public static Card EmptyCard()
        {
            return new EmptyCard();
        }
        public override bool Equals(object? obj)
        {
            if (obj == null)
                return false;
            if (obj.GetType() != GetType())
                return false;
            var other = (Card) obj;
            return Color == other.Color && Number == other.Number;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Color, Number);
        }
    }

}