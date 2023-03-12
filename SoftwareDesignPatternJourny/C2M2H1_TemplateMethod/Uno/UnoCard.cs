namespace C2M2H1_TemplateMethod.Uno
{
    using Framework;

    public record UnoCard(Color color, Number number) : CardBase<UnoCard>
    {
        public override string ToString()
        {
            return $"{color} {number}";
        }

        public override bool Equals(UnoCard? obj)
        {
            if (obj == null)
                return false;

            if (obj.GetType() != GetType())
                return false;

            return color == obj.color && number == obj.number;
        }

        public override int CompareTo(UnoCard? other)
        {
            if (other == null)
                return 1;

            if (color.CompareTo(other.color) == 0)
                return 0;
            
            return number.CompareTo(other.number) == 0 ? 0 : 1;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(color, number);
        }
    }
}