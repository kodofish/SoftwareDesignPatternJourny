namespace C2M1H1_StrategyPattern
{
    public class Individual
    {
        public Guid Id { get; }
        public Gender Gender { get; }
        public int Age { get; }
        public string Intro { get; } = string.Empty;
        public string Habits { get; } = string.Empty;
        public Coordinate Coord { get; } = new Coordinate(0, 0);

        public double Distance(Individual individual)
        {
            return Math.Abs(Math.Sqrt(Math.Pow(Coord.Y - individual.Coord.Y, 2) - Math.Pow(Coord.X - individual.Coord.X, 2)));
        }
        public override string ToString()
        {
            return $"{this.Id.ToString().Split('-').First()}({this.Coord.X},{this.Coord.Y}) Habit:{Habits}";
        }
        public int HabitIntersectCount(Individual individual)
        {
            return individual.Habits.Split(',').Intersect(Habits.Split(',')).Count();
        }
    }
}