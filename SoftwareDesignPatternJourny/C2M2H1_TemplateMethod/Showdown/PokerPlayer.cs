namespace C2M2H1_TemplateMethod.Showdown
{
    using Framework;

    public abstract class PokerPlayer : PlayerBase<PokerHand, PokerCard>
    {
        private PokerCard _card;

        public int Point { get; private set; }

        public PokerCard ShowCard { get { return _card; } }

        protected PokerPlayer()
        {
            Point = 0;
        }
        
        public void GetPoint()
        {
            Point++;
        }

        public void TakesTurn()
        {
            _card = Hand.DrawCard();
        }
    }
}