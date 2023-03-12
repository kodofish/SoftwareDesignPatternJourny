namespace C2M2H1_TemplateMethod.Framework
{
    public abstract class GameBase<TPlayer, THand, TDeck, TCard>
        where TPlayer : PlayerBase<THand, TCard>
        where THand : HandBase<TCard>, new()
        where TDeck : DeckBase<TCard>
        where TCard : CardBase<TCard>
    {
        internal int _round;

        protected abstract int cardAmount { get; }

        public List<TPlayer> Players { get; }

        public TDeck Deck { get; }

        protected GameBase(IEnumerable<TPlayer> players, TDeck deck)
        {
            Players = players.ToList();
            Deck = deck;
            _round = 0;
        }

        private void Step1_PlayerNaming()
        {
            foreach (var player in Players)
            {
                player.NamingSelf();
                Console.WriteLine(player);
            }
        }

        private void Step2_DeckShuffle()
        {
            Deck.Shuffle();
        }
        
        private void DrawCard()
        {
            for (var i = 0; i < cardAmount; i++)
                foreach (var player in Players)
                    player.ReceiveCard(Deck.Draw());
        }

        public virtual void Play()
        {
            Step1_PlayerNaming();

            Step2_DeckShuffle();

            DrawCard();
        }
    }
}