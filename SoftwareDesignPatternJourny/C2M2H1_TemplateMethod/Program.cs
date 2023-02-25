// See https://aka.ms/new-console-template for more information
using C2M2H1_TemplateMethod.Showdown;

var players = new Player[]
{
    new HumanPlayer(),
    new AiPlayer(),
    new AiPlayer(),
    new AiPlayer()
};


var deck = new Deck();
var game = new ShowdownGame(players, deck);

game.Start();
Console.WriteLine("The game is over.");
Console.ReadLine();