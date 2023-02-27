// See https://aka.ms/new-console-template for more information
using C2M2H1_TemplateMethod.Showdown;
using C2M2H1_TemplateMethod.Uno;
using ComputerPlayer = C2M2H1_TemplateMethod.Showdown.ComputerPlayer;
using Deck = C2M2H1_TemplateMethod.Showdown.Deck;
using HumanPlayer = C2M2H1_TemplateMethod.Showdown.HumanPlayer;
using Player = C2M2H1_TemplateMethod.Showdown.Player;


var players = new C2M2H1_TemplateMethod.Uno.Player[]
{
    new C2M2H1_TemplateMethod.Uno.ComputerPlayer(),
    new C2M2H1_TemplateMethod.Uno.ComputerPlayer(),
    new C2M2H1_TemplateMethod.Uno.ComputerPlayer(),
    new C2M2H1_TemplateMethod.Uno.ComputerPlayer()
};
var deck = new C2M2H1_TemplateMethod.Uno.Deck();
var unoGame = new UnoGame(players, deck);

unoGame.Play();
Console.WriteLine("The game is over.");
Console.ReadLine();

void StartShowdownGame()
{

    var players1 = new Player[]
    {
        new HumanPlayer(),
        new ComputerPlayer(),
        new ComputerPlayer(),
        new ComputerPlayer()
    };


    var deck = new Deck();
    var game = new ShowdownGame(players1, deck);

    game.Start();
}