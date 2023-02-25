// See https://aka.ms/new-console-template for more information
using C2M2H1_TemplateMethod.Showdown;

var players = new Player[]
{
    new HumanPlayer(),
    new AiPlayer(),
    new AiPlayer(),
    new AiPlayer()
};

var cards = GenerateCards();

IEnumerable<PokerCard> GenerateCards()
{
    foreach (var rank in Rank.GetValues(typeof(Rank)))
    {
        foreach (var suit in Suit.GetValues(typeof(Suit)))
        {
            yield return new PokerCard((Suit) suit, (Rank) rank);
        }
    }
}

var deck = new Deck(cards);
var game = new ShowdownGame(players, deck);

game.Start();
Console.WriteLine("The game is over.");
Console.ReadLine();