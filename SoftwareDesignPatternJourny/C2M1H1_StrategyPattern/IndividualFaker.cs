using Bogus;
namespace C2M1H1_StrategyPattern
{
    public class IndividualFaker : Faker<Individual>
    {
        private static readonly string[] habits = { "reading", "Exercise", "Gym", "Walk", "Study", "Yoga" };
        public IndividualFaker()
        {
            StrictMode(true);
            RuleFor(it => it.Age, it => it.Random.Number(18, 60));
            RuleFor(it => it.Id, it => Guid.NewGuid());
            RuleFor(it => it.Gender, it => it.Random.Enum<Gender>());
            RuleFor(it => it.Intro, it => it.Lorem.Word());
            RuleFor(it => it.Habits, it => string.Join(",", it.PickRandom(habits, 2)));
            RuleFor(it => it.Coord, it => new Coordinate(it.Address.Latitude(), it.Address.Longitude()));
        }
    }
}