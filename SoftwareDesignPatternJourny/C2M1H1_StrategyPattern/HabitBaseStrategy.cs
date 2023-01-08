namespace C2M1H1_StrategyPattern
{
    internal class HabitBaseStrategy : IMatchStrategy
    {
        public IEnumerable<Individual> Match(List<Individual> users, Individual i)
        {
            return users.OrderBy(i.HabitIntersectCount);
        }
    }
}