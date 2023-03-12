namespace C2M2H1_TemplateMethod.Showdown
{
    public class HumanPokerPlayer : PokerPlayer
    {
        public override void NamingSelf()
        {
            do
            {
                Console.WriteLine("Please enter your name:");
                _name = ReadFromConsole();
            }
            while (string.IsNullOrWhiteSpace(_name));
        }
        protected virtual string ReadFromConsole()
        {
            return Console.ReadLine() ?? string.Empty;
        }

    }
}