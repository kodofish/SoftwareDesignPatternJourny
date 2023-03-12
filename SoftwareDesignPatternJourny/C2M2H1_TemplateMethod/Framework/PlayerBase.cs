namespace C2M2H1_TemplateMethod.Framework
{
    using Bogus;
    public abstract class PlayerBase<THand, TCard> 
        where THand : HandBase<TCard>, new() 
        where TCard : CardBase<TCard>
    {
        public THand Hand { get; }
        protected string _name;

        public string Name { get { return _name; } }

        protected PlayerBase()
        {
            Hand = new THand();
            _name = string.Empty;
        }

        public virtual void NamingSelf()
        {
            _name = (new Faker()).Person.FirstName;
        }

        public override string ToString()
        {
            return $"{Name}: {Hand}";
        }

        public void ReceiveCard(TCard card)
        {
            Hand.Add(card);
        }
    }
}