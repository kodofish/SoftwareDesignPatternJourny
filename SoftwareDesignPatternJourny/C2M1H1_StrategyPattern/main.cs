namespace C2M1H1_StrategyPattern
{
    public static class Client
    {
        private static readonly IndividualFaker _individualFaker = new IndividualFaker();
        static void Main()
        {
            var matchMarkingSystem = new MatchMarkingSystem(new DistanceBaseStrategy());
            for (var i = 0; i < 5; i++)
            {
                var individual = _individualFaker.Generate();
                matchMarkingSystem.Add(individual);
            }

            var user = _individualFaker.Generate(1).First();
            var matchedUser = matchMarkingSystem.Match(user).First();
            Console.WriteLine($"This user is {user}");
            Console.WriteLine($"The best match user is {matchedUser} that used distance base strategy");
            
            matchMarkingSystem.SetMatchStrategy(new HabitBaseStrategy());
            matchedUser = matchMarkingSystem.Match(user).First();
            Console.WriteLine($"The best match user is {matchedUser} that used habit base strategy");
            
            matchMarkingSystem.SetMatchStrategy(new Reverse(new DistanceBaseStrategy()));
            matchedUser = matchMarkingSystem.Match(user).First();
            Console.WriteLine($"The best match user is {matchedUser} that used Revert distance base strategy");
            
            matchMarkingSystem.SetMatchStrategy(new Reverse(new HabitBaseStrategy()));
            matchedUser = matchMarkingSystem.Match(user).First();
            Console.WriteLine($"The best match user is {matchedUser} that used Revert habit base strategy");
        }
    }

}