namespace C2M2H1_TemplateMethod.Showdown
{
    public record PokerCard(Suit suit, Rank rank) : IComparable<PokerCard>
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
        public int CompareTo(PokerCard? other)
        {
            if (other is null) return 1;
            var result = rank.CompareTo(other.rank);
            return result != 0 ? result : suit.CompareTo(other.suit);
        }

        public override string ToString()
        {
            return $"{rank}({(int)rank}) of {suit}({(int)suit})";
        }
    }
}