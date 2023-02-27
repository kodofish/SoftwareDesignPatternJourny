namespace C2M2H1_TemplateMethod.Uno
{
    public class HumanPlayer : Player
    {
        public override void NamingSelf()
        {
            Console.WriteLine("What is your name?");
            do
            {
                Name = ReadPlayerNameFromConsole();
            }
            while (string.IsNullOrWhiteSpace(Name));
            
        }
        internal virtual string ReadPlayerNameFromConsole()
        {
            return Console.ReadLine() ?? string.Empty;
        }
    }
}