namespace C2M2H1_TemplateMethod.Uno
{
    public class UnoGame
    {
        private readonly List<Player> _players;
        private readonly Deck _deck;
        internal int _round;

        public UnoGame(IEnumerable<Player> players, Deck deck)
        {
            _players = players.ToList();
            _deck = deck;
            _deck.Shuffle();
        }

        public void Play()
        {
            Step1_PlayerNaming();

            Step2_PlayerDrawCard();

            var _tableCard = Step3_1_DrawCardToTable();

            while (true)
            {
                Console.WriteLine($"\nThe {_round++} round. The table card is {_tableCard}\n");
                foreach (var player in _players)
                {
                    Console.WriteLine($"The {player} turn.");
                    var card = player.TakeTurn(_tableCard);
                    if (card.Equals(Card.EmptyCard()))
                    {
                        player.DrawCard(_deck);
                        Console.WriteLine($"The {player} draw a card from deck.");
                        break;
                    }

                    if (card.CompareTo(_tableCard) != 0)
                    {
                        player.ReceiveCard(card);
                        continue;
                    }

                    _deck.Fold(_tableCard);
                    _tableCard = card;
                    Console.WriteLine($"The {player} throw {card} to table.");

                    if (player.Hand.Count() == 0)
                    {
                        Console.WriteLine($"The {player} win.");
                        return;
                    }
                    break;
                }
            }
        }
        private Card Step3_1_DrawCardToTable()
        {
            var _tableCard = _deck.Draw();
            Console.WriteLine($"First card: {_tableCard}");
            return _tableCard;
        }
        private void Step2_PlayerDrawCard()
        {
            for (var i = 0; i < 5; i++)
                foreach (var player in _players)
                    player.DrawCard(_deck);
        }
        private void Step1_PlayerNaming()
        {
            foreach (var player in _players)
            {
                player.NamingSelf();
                Console.WriteLine(player);
            }
        }
    }
}