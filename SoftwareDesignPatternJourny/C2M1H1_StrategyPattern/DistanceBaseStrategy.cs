namespace C2M1H1_StrategyPattern
{
    internal class DistanceBaseStrategy : IMatchStrategy
    {
        public IEnumerable<Individual> Match(List<Individual> users, Individual i)
        {
            return users.OrderBy(u => u.Distance(i));
        }
    }
}