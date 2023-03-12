// See https://aka.ms/new-console-template for more information
using C2M2H1_TemplateMethod.Showdown;
using C2M2H1_TemplateMethod.Uno;

StartUnoGame();
StartShowdownGame();

void StartUnoGame()
{
    var players = new UnoPlayer[]
    {
        new ComputerUnoPlayer(),
        new ComputerUnoPlayer(),
        new ComputerUnoPlayer(),
        new ComputerUnoPlayer()
    };
    var deck = new UnoDeck();
    var unoGame = new UnoGame(players, deck);

    unoGame.Play();
    Console.WriteLine("The game is over.");
    Console.ReadLine();
}

void StartShowdownGame()
{
    var players1 = new PokerPlayer[]
    {
        new HumanPokerPlayer(),
        new ComputerPokerPlayer(),
        new ComputerPokerPlayer(),
        new ComputerPokerPlayer()
    };


    var deck = new PokerDeck();
    var game = new ShowdownGame(players1, deck);

    game.Play();
}