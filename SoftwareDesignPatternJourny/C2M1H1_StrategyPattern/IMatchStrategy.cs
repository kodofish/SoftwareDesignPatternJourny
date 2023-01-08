namespace C2M1H1_StrategyPattern
{
    internal interface IMatchStrategy
    {
        IEnumerable<Individual> Match(List<Individual> users, Individual i);
    }
}