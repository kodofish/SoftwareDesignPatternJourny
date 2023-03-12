namespace C2M2H1_TemplateMethod.Uno
{
    using Framework;
    public class UnoGame : GameBase<UnoPlayer, UnoHand, UnoDeck, UnoCard>
    {
        private UnoCard _tableCard = new EmptyUnoCard();

        protected override int cardAmount => 5;

        public UnoGame(IEnumerable<UnoPlayer> players, UnoDeck deck)
            : base(players, deck)
        {
        }

        public override void Play()
        {
            base.Play();

            DrawCardToTable();

            Step4_PlayRound();
        }
        private void Step4_PlayRound()
        {
            while (true)
            {
                _round++;
                Console.WriteLine($"\nThe {_round++} round. The table card is {_tableCard}\n");
                foreach (var player in Players)
                {
                    Console.WriteLine($"The {player} turn.");
                    var card = player.TakeTurn(_tableCard);
                    if (card.Equals(new EmptyUnoCard()))
                    {
                        player.ReceiveCard(Deck.Draw());
                        Console.WriteLine($"The {player} draw a card from deck.");
                        break;
                    }

                    if (card.CompareTo(_tableCard) != 0)
                    {
                        player.ReceiveCard(card);
                        continue;
                    }

                    ReplaceTableCard(card);
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

        private void ReplaceTableCard(UnoCard card)
        {
            Deck.Fold(_tableCard);
            _tableCard = card;
        }

        private void DrawCardToTable()
        {
            _tableCard = Deck.Draw();
            Console.WriteLine($"First card: {_tableCard}");
        }
    }
}