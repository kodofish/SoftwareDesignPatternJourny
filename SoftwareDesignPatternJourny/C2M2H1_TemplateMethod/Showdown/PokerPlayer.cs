using Bogus;

namespace C2M2H1_TemplateMethod.Showdown
{
    public abstract class PokerPlayer
    {
        protected string _name;
        internal readonly PokerHand PokerHand;
        private PokerCard _card;

        public string Name { get { return _name; } }

        public int Point { get; private set; }

        public PokerCard ShowCard { get { return _card; } }

        protected PokerPlayer()
        {
            PokerHand = new PokerHand();
            _name = string.Empty;
            Point = 0;
        }
        
        public void GetPoint()
        {
            Point++;
        }

        public virtual void NamingSelf()
        {
            _name = (new Faker()).Person.FirstName;
        }

        public void TakesTurn()
        {
            _card = PokerHand.DrawCard();
        }

        public void ReceiveCard(PokerCard card)
        {
            PokerHand.Add(card);
        }
    }
}