namespace C2M2H1_TemplateMethod.Uno
{
    public class HumanUnoPlayer : UnoPlayer
    {
        public override void NamingSelf()
        {
            do
            {
                Console.WriteLine("Please enter your name:");
                _name = ReadPlayerNameFromConsole();
            }
            while (string.IsNullOrWhiteSpace(Name));

        }

        internal virtual string ReadPlayerNameFromConsole()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}