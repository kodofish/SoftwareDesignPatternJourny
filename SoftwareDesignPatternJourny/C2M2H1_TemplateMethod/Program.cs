// See https://aka.ms/new-console-template for more information
using C2M2H1_TemplateMethod.Showdown;
using C2M2H1_TemplateMethod.Uno;


var players = new C2M2H1_TemplateMethod.Uno.UnoPlayer[]
{
    new C2M2H1_TemplateMethod.Uno.ComputerUnoPlayer(),
    new C2M2H1_TemplateMethod.Uno.ComputerUnoPlayer(),
    new C2M2H1_TemplateMethod.Uno.ComputerUnoPlayer(),
    new C2M2H1_TemplateMethod.Uno.ComputerUnoPlayer()
};
var deck = new C2M2H1_TemplateMethod.Uno.UnoDeck();
var unoGame = new UnoGame(players, deck);

unoGame.Play();
Console.WriteLine("The game is over.");
Console.ReadLine();

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

    game.Start();
}