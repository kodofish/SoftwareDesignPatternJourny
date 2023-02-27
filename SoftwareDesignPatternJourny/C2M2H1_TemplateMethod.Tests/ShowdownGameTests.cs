using Shouldly;
using C2M2H1_TemplateMethod.Showdown;

namespace C2M2H1_TemplateMethod.Tests
{
    public class RankTests
    {
        [TestCase(Rank.Ace, Rank.Ace, 0)]
        [TestCase(Rank.Ace, Rank.King, 1)]
        [TestCase(Rank.Ace, Rank.Queen, 1)]
        [TestCase(Rank.Ace, Rank.Jack, 1)]
        [TestCase(Rank.Seven, Rank.Jack, -1)]
        [TestCase(Rank.Seven, Rank.Queen, -1)]
        [TestCase(Rank.Seven, Rank.King, -1)]
        [TestCase(Rank.Seven, Rank.Ace, -1)]
        public void CompareTo(Rank rank1, Rank rank2, int expected)
        {
            var card1 = new PokerCard(Suit.Clubs, rank1);
            var card2 = new PokerCard(Suit.Clubs, rank2);
            card1.CompareTo(card2).ShouldBe(expected);
        }
    }

    public class SuitTests
    {
        [TestCase(Suit.Clubs, Suit.Clubs, 0)]
        [TestCase(Suit.Clubs, Suit.Diamonds, -1)]
        [TestCase(Suit.Clubs, Suit.Hearts, -1)]
        [TestCase(Suit.Clubs, Suit.Spades, -1)]
        [TestCase(Suit.Spades, Suit.Clubs, 1)]
        public void CompareTo(Suit suit1, Suit suit2, int expected)
        {
            var card1 = new PokerCard(suit1, Rank.Ace);
            var card2 = new PokerCard(suit2, Rank.Ace);
            card1.CompareTo(card2).ShouldBe(expected);
        }

        [Test]
        public void CompareTo_Null()
        {
            var card1 = new PokerCard(Suit.Clubs, Rank.Ace);
            card1.CompareTo(null).ShouldBe(1);
        }
    }

    public class DeckTests
    {
        [Test]
        public void Draw()
        {
            var deck = new Deck();
            deck.Shuffle();
            deck.Draw().ShouldNotBeNull();
        }

        [Test]
        public void Shuffle()
        {
            var deck = new Deck();
            deck.Shuffle();
            var card1 = deck.Draw();
            deck.Shuffle();
            var card2 = deck.Draw();
            card1.ShouldNotBe(card2);
        }

        [Test]
        public void DrawAll()
        {
            var deck = new Deck();
            deck.Shuffle();
            for (var i = 0; i < 52; i++)
                deck.Draw().ShouldNotBeNull();
            Assert.Throws<InvalidOperationException>(() => deck.Draw());
        }

        [Test]
        public void DrawAllAndShuffle()
        {
            var deck = new Deck();
            deck.Shuffle();
            for (var i = 0; i < 52; i++)
                deck.Draw().ShouldNotBeNull();
            Assert.Throws<InvalidOperationException>(() => deck.Draw());
            deck.Shuffle();
            deck.Draw().ShouldNotBeNull();
        }

        [Test]
        public void Draw_First_NotShuffle_Should_throw_Exception()
        {
            var deck = new Deck();
            Assert.Throws<InvalidOperationException>(() => deck.Draw())?.Message.ShouldBe("Should shuffle first");
        }
    }

    public class HandTests
    {
        [Test]
        public void RandomDraw()
        {
            var hand = new Hand { new PokerCard(Suit.Clubs, Rank.Ace), new PokerCard(Suit.Clubs, Rank.King) };
            hand.RandomDraw().ShouldNotBeNull();
        }

        [Test]
        public void RandomDraw_Empty()
        {
            var hand = new Hand();
            Assert.Throws<InvalidOperationException>(() => hand.RandomDraw())?.Message.ShouldBe("No card in hand");
        }
    }

    public class HumanPlayerTests
    {
        [Test]
        public void HumanPlayer()
        {
            var player = new TestHumanPlayer();
            player.NamingSelf();
            player.Name.ShouldBe("Test");
            player.Point.ShouldBe(0);
            player.ShowCard.ShouldBeNull();
        }

        private class TestHumanPlayer : HumanPlayer
        {
            protected override string ReadFromConsole()
            {
                return "Test";
            }
        }
    }

    public class ComputerPlayerTests
    {
        [Test]
        public void ComputerPlayer()
        {
            var player = new ComputerPlayer();
            player.NamingSelf();
            player.Name.ShouldNotBeEmpty();
        }
    }

    public class PlayerTests
    {
        [Test]
        public void GetPoint()
        {
            var player = new ComputerPlayer();
            player.GetPoint();
            player.Point.ShouldBe(1);
        }

        [Test]
        public void ReceiveCard()
        {
            var player = new ComputerPlayer();
            player.ReceiveCard(new PokerCard(Suit.Clubs, Rank.Ace));
            player._hand.Count.ShouldBe(1);
        }

        [Test]
        public void TakesTurn()
        {
            var player = new ComputerPlayer();
            player.ReceiveCard(new PokerCard(Suit.Clubs, Rank.Ace));
            player.TakesTurn();
            player.ShowCard.ShouldBe(new PokerCard(Suit.Clubs, Rank.Ace));
        }
    }

    public class GameTests
    {
        [Test]
        public void Game()
        {
            var deck = new Deck();
            var players = new Player[] { new HumanPlayer(), new ComputerPlayer() };
            var game = new ShowdownGame(players, deck);

            game._players.Length.ShouldBe(2);
            game._players[0].ShouldBeOfType<HumanPlayer>();
            game._players[1].ShouldBeOfType<ComputerPlayer>();
            game._deck.Equals(deck);
        }

        [Test]
        public void Play()
        {
            var deck = new Deck();
            var players = new Player[] { new ComputerPlayer(), new ComputerPlayer() };
            var game = new ShowdownGame(players, deck);
            game.Start();
            game._round.ShouldBe(13);
        }
    }
}