namespace C2M1H1_StrategyPattern
{
    internal class MatchMarkingSystem
    {
        private readonly List<Individual> _individuals = new List<Individual>();
        private IMatchStrategy _matchStrategy;
        public MatchMarkingSystem(IMatchStrategy matchStrategy)
        {
            _matchStrategy = matchStrategy;
        }

        public void SetMatchStrategy(IMatchStrategy matchStrategy)
        {
            _matchStrategy = matchStrategy;
        }

        public void Add(Individual individual)
        {
            _individuals.Add(individual);
        }
        public IEnumerable<Individual> Match(Individual user)
        {
            return _matchStrategy.Match(_individuals, user);
        }
    }
}