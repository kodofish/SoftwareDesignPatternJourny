namespace C2M2H1_TemplateMethod.Tests
{
    using Shouldly;
    using Uno;
    public class ColorTests
    {
        //write testCase for enum Color  using nunit
        [TestCase(Color.RED, Color.RED, 0)]
        [TestCase(Color.RED, Color.BLUE, 1)]
        [TestCase(Color.RED, Color.GREEN, -1)]
        [TestCase(Color.RED, Color.YELLOW, -1)]
        public void ColorEnumTest(Color color1, Color color2, int expected)
        {
            color1.CompareTo(color2).ShouldBe(expected);
        }
    }

    //write testCase for enum Number  using nunit
    public class NumberTests
    {
        [TestCase(Number.ZERO, Number.ZERO, 0)]
        [TestCase(Number.ZERO, Number.ONE, -1)]
        [TestCase(Number.ZERO, Number.TWO, -1)]
        [TestCase(Number.ZERO, Number.THREE, -1)]
        [TestCase(Number.ZERO, Number.FOUR, -1)]
        [TestCase(Number.ZERO, Number.FIVE, -1)]
        [TestCase(Number.ZERO, Number.SIX, -1)]
        [TestCase(Number.ZERO, Number.SEVEN, -1)]
        [TestCase(Number.ZERO, Number.EIGHT, -1)]
        [TestCase(Number.ZERO, Number.NINE, -1)]
        public void NumberEnumTest(Number number1, Number number2, int expected)
        {
            number1.CompareTo(number2).ShouldBe(expected);
        }
    }

    //write test case for class Card using nunit
    public class CardTests
    {
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.ZERO, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.ONE, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.TWO, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.THREE, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.FOUR, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.FIVE, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.SIX, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.SEVEN, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.EIGHT, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.RED, Number.NINE, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.ZERO, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.ONE, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.TWO, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.THREE, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.FOUR, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.FIVE, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.SIX, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.SEVEN, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.EIGHT, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.BLUE, Number.NINE, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.GREEN, Number.ZERO, 0)]
        [TestCase(Color.RED, Number.ZERO, Color.GREEN, Number.ONE, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.GREEN, Number.TWO, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.GREEN, Number.THREE, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.GREEN, Number.FOUR, 1)]
        [TestCase(Color.RED, Number.ZERO, Color.GREEN, Number.FIVE, 1)]
        public void CardCompareToTest(Color color1, Number number1, Color color2, Number number2, int expected)
        {
            var card1 = new Card(color1, number1);
            var card2 = new Card(color2, number2);
            card1.CompareTo(card2).ShouldBe(expected);
        }

        //write test case for class Deck using nunit
        public class DeckTests
        {
            [Test]
            public void DeckShuffleTest()
            {
                var deck = new Deck();
                var deck2 = new Deck();
                deck.Shuffle();
                deck2.Shuffle();
                deck.Draw().GetHashCode().ShouldNotBe(deck2.GetHashCode());
                deck._cards.Count.ShouldBe(39);
                deck2._cards.Count.ShouldBe(40);
            }

            [Test]
            public void DeckDraw_40_times()
            {
                var deck = new Deck();
                deck.Shuffle();
                for (var i = 0; i < 40; i++)
                {
                    _ = deck.Draw();
                }
                deck._cards.Count.ShouldBe(0);
            }

            [Test]
            public void DeckDraw_41_times()
            {
                var deck = new Deck();
                deck.Shuffle();
                for (var i = 0; i < 41; i++)
                {
                    var drawCard = deck.Draw();
                    deck.Fold(drawCard);
                }
                deck._cards.Count.ShouldBe(39);
            }
        }

        //write test case for class Hand using nunit
        public class HandTests
        {
            [Test]
            public void HandAddCardTest()
            {
                var hand = new Hand();
                var card = new Card(Color.RED, Number.ZERO);
                hand.AddCard(card);
                hand.Count().ShouldBe(1);
            }
            //write test case for Hand.DrawCard()
            [Test]
            public void HandDrawCardTest()
            {
                var hand = new Hand();
                var card = new Card(Color.RED, Number.ZERO);
                hand.AddCard(card);
                var actual = hand.DrawCard(new Card(Color.BLUE, Number.SIX));
                    actual.ShouldBe(new EmptyCard());
            }

            [Test]
            public void HandDrawCardTest2()
            {
                var hand = new Hand();
                var card = new Card(Color.RED, Number.ZERO);
                hand.AddCard(card);
                hand.DrawCard(new Card(Color.RED, Number.SIX)).ShouldBe(new Card(Color.RED, Number.ZERO));
            }
        }

        //write test case for class Player using nunit
        public class PlayerTests
        {
            //write test case for Player.DrawCard()
            [Test]
            public void PlayerDrawCardTest()
            {
                var player = new Player();
                var deck = new Deck();
                player.DrawCard(deck);
                player.Hand.Count().ShouldBe(1);
            }
            //write test for Player.NamingSelf()
            [Test]
            public void PlayerNamingSelfTest()
            {
                var player = new Player();
                player.NamingSelf();
                player.Name.ShouldNotBeEmpty();
            }

            //write test for Player.TakeTurn
            [Test]
            public void PlayerTakeTurnTest()
            {
                var player = new Player();
                player.ReceiveCard(new Card(Color.RED, Number.ONE));
                var actual = player.TakeTurn(new Card(Color.RED, Number.FIVE));

                actual.ShouldBe(new Card(Color.RED, Number.ONE));
            }

            [Test]
            public void PlayerTakeTurnTest2()
            {
                var player = new Player();
                player.ReceiveCard(new Card(Color.RED, Number.ONE));
                var actual = player.TakeTurn(new Card(Color.GREEN, Number.FIVE));

                actual.ShouldBe(new EmptyCard());
            }
        }
        
        //write test case for HumanPlayer class using nunit
        public class HumanPlayerTests
        {
            //write test case for HumanPlayer.NamingSelf()
            [Test]
            public void HumanPlayerNamingSelfTest()
            {
                var humanPlayer = new TestHumanPlayer();
                humanPlayer.NamingSelf();
                humanPlayer.Name.ShouldBe("Test");
            }
            
            class TestHumanPlayer : HumanPlayer
            {
                internal override string ReadPlayerNameFromConsole()
                {
                    return "Test";
                }
            }
        }
        
        public class GameTests
        {
            [Test]
            public void GamePlayTest()
            {
                var players = new[] { new ComputerPlayer(), new ComputerPlayer(), new ComputerPlayer(), new ComputerPlayer() };
                var game = new UnoGame(players, new Deck());
                game.Play();
                game._round.ShouldBeGreaterThanOrEqualTo(5);
            }
        }

    }
}