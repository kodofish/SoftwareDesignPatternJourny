using Bogus;

namespace C2M2H1_TemplateMethod.Showdown
{
    public abstract class Player
    {
        protected string _name;
        private readonly Hand _hand;
        private PokerCard _card;

        public string Name { get { return _name; } }

        public int Point { get; private set; }

        public PokerCard ShowCard { get { return _card; } }

        protected Player()
        {
            _hand = new Hand();
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
            _card = _hand.RandomDraw();
        }

        public void ReceiveCard(PokerCard card)
        {
            _hand.Add(card);
        }
    }
}