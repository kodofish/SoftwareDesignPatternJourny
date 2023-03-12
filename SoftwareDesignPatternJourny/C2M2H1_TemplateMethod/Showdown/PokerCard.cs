namespace C2M2H1_TemplateMethod.Showdown
{
    using Framework;
    public record PokerCard(Suit suit, Rank rank) : CardBase<PokerCard>
    {
        /// <summary>
        /// CompareTo method for PokerCard
        /// </summary>
        /// <param name="other">The other PokerCard to compare to</param>
        /// <returns>
        /// 1 if this is greater than other
        /// 0 if this is equal to other
        /// -1 if this is less than other
        /// </returns>
        public override int CompareTo(PokerCard? other)
        {
            if (other is null) return 1;
            var result = rank.CompareTo(other.rank);
            return result != 0 ? result : suit.CompareTo(other.suit);
        }

        public override bool Equals(PokerCard? other)
        {
            if (other is null) return false;
            return rank == other.rank && suit == other.suit;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(suit, rank);
        }

        public override string ToString()
        {
            return $"{rank}({(int)rank}) of {suit}({(int)suit})";
        }
    }
}