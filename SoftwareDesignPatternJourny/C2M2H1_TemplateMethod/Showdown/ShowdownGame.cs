namespace C2M2H1_TemplateMethod.Showdown
{
    using Framework;
    public class ShowdownGame : GameBase<PokerPlayer, PokerHand, PokerDeck, PokerCard>
    {
        protected override int cardAmount => 13;
        
        public ShowdownGame(PokerPlayer[] players, PokerDeck pokerDeck) : base(players, pokerDeck)
        {
        }
        public override void Play()
        {
            base.Play();

            Step4_PlayRound();

            Step5_DisplayResult();
        }
        private void Step4_PlayRound()
        {
            while (_round < cardAmount)
            {
                _round++;
                Console.WriteLine($"The game starts a new round. Round {_round}");

                foreach (var player in Players)
                    player.TakesTurn();

                foreach (var player1 in Players)
                    Console.WriteLine($"The player {player1.Name} has {player1.ShowCard} in this round.");

                var winPlayer = Players.First(player => Players.Where(it => it != player).Count(otherPlayer => player.ShowCard.CompareTo(otherPlayer.ShowCard) > 0) == Players.Count -1);
                winPlayer.GetPoint();
                Console.WriteLine($"The player {winPlayer.Name} wins this round.\n");
            }
        }
        private void Step5_DisplayResult()
        {
            foreach (var player in Players)
                Console.WriteLine($"The player {player.Name}'s score is {player.Point}.");

            var winner = Players.OrderByDescending(it => it.Point).First();

            Console.WriteLine($"The player {winner.Name} wins the game.");
        }
    }
}