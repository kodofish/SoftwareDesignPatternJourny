namespace C2M2H1_TemplateMethod.Uno
{
    public class UnoGame
    {
        private readonly List<UnoPlayer> _players;
        private readonly UnoDeck _unoDeck;
        internal int _round;

        public UnoGame(IEnumerable<UnoPlayer> players, UnoDeck unoDeck)
        {
            _players = players.ToList();
            _unoDeck = unoDeck;
            _unoDeck.Shuffle();
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
                    if (card.Equals(new EmptyUnoCard()))
                    {
                        player.DrawCard(_unoDeck);
                        Console.WriteLine($"The {player} draw a card from deck.");
                        break;
                    }

                    if (card.CompareTo(_tableCard) != 0)
                    {
                        player.ReceiveCard(card);
                        continue;
                    }

                    _unoDeck.Fold(_tableCard);
                    _tableCard = card;
                    Console.WriteLine($"The {player} throw {card} to table.");

                    if (!player.Hand.Any())
                    {
                        Console.WriteLine($"The {player} win.");
                        return;
                    }
                    break;
                }
            }
        }
        private UnoCard Step3_1_DrawCardToTable()
        {
            var _tableCard = _unoDeck.Draw();
            Console.WriteLine($"First card: {_tableCard}");
            return _tableCard;
        }
        private void Step2_PlayerDrawCard()
        {
            for (var i = 0; i < 5; i++)
                foreach (var player in _players)
                    player.DrawCard(_unoDeck);
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