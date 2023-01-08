namespace C2M1H1_StrategyPattern
{
    internal class Reverse : IMatchStrategy
    {
        private readonly IMatchStrategy _matchStrategy;
        public Reverse(IMatchStrategy matchStrategy)
        {
            _matchStrategy = matchStrategy;
        }
        public IEnumerable<Individual> Match(List<Individual> users, Individual i)
        {
            return _matchStrategy.Match(users, i).Reverse();
        }
    }
}