namespace C2M2H1_TemplateMethod.Showdown
{
    public class ShowdownGame
    {
        internal readonly Player[] _players;
        internal readonly Deck _deck;
        internal int _round;
        public ShowdownGame(Player[] players, Deck deck)
        {
            _players = players ?? throw new ArgumentNullException(nameof(players));
            _deck = deck ?? throw new ArgumentNullException(nameof(deck));
            _round = 0;
        }
        public void Start()
        {
            Step1_NamingPlayer();

            Step2_DeckShuffle();

            Step3_PlayerDrawCard();

            Step4_PlayRound();

            Step5_DisplayResult();
        }
        private void Step4_PlayRound()
        {
            do
            {
                _round++;
                Console.WriteLine($"The game starts a new round. Round {_round}");

                Step4_1_PlayerTakesTurn();

                Step4_2_PlayerShowCard();

                Step4_3_WhoWinTheRound();
            }
            while (_round < 13);
        }
        private void Step5_DisplayResult()
        {

            foreach (var player in _players)
                Console.WriteLine($"The player {player.Name}'s score is {player.Point}.");

            var winner = _players.OrderByDescending(it => it.Point).First();

            Console.WriteLine($"The player {winner.Name} wins the game.");
        }
        private void Step4_3_WhoWinTheRound()
        {
            var winPlayer = _players.First(player => _players.Where(it => it != player).Count(otherPlayer => player.ShowCard.CompareTo(otherPlayer.ShowCard) > 0) == _players.Length -1);
            winPlayer.GetPoint();
            Console.WriteLine($"The player {winPlayer.Name} wins this round.\n");
        }
        private void Step4_2_PlayerShowCard()
        {
            foreach (var player in _players)
                Console.WriteLine($"The player {player.Name} has {player.ShowCard} in this round.");
        }
        private void Step4_1_PlayerTakesTurn()
        {
            foreach (var player in _players)
                player.TakesTurn();
        }
        private void Step2_DeckShuffle()
        {
            _deck.Shuffle();
        }
        private void Step3_PlayerDrawCard()
        {
            for (var i = 0; i < 13; i++)
                foreach (var player in _players)
                    player.ReceiveCard(_deck.Draw());
        }
        private void Step1_NamingPlayer()
        {
            foreach (var player in _players)
                player.NamingSelf();
        }
    }

}