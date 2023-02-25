namespace C2M2H1_TemplateMethod.Tests;

using Shouldly;
using Showdown;
public class RankTests
{
    [TestCase(Rank.Ace, Rank.Ace, 0)]
    [TestCase(Rank.Ace, Rank.King, 1)]
    [TestCase(Rank.Ace, Rank.Queen, 1)]
    [TestCase(Rank.Ace, Rank.Jack, 1)]
    [TestCase(Rank.Seven, Rank.Jack, -1)]
    public void CompareTo(Rank rank1, Rank rank2, int expected)
    {
        var card1 = new PokerCard(Suit.Clubs, rank1);
        var card2 = new PokerCard(Suit.Clubs, rank2);
        card1.CompareTo(card2).ShouldBe(expected);
    }
}