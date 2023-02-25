namespace C2M2H1_TemplateMethod.Showdown
{
    public class HumanPlayer : Player
    {
        public override void NamingSelf()
        {
            do
            {
                Console.WriteLine("Please enter your name:");
                _name = Console.ReadLine();
            }
            while (_name == string.Empty);
        }

    }
}