// See https://aka.ms/new-console-template for more information
using Eonix.TechnicalTest.Models;

var spectator = new Spectator();
var monkey1 = new Monkey("Singe 1");
var monkey2 = new Monkey("Singe 2");
var dressor1 = new Dressor(monkey1);
var dressor2 = new Dressor(monkey2);

List<Trick> tricks1 = dressor1.AskMonkeyToDoTrick();

DoTricks(tricks1, dressor1.Monkey);

List<Trick> tricks2 = dressor2.AskMonkeyToDoTrick();
tricks2.Reverse();

DoTricks(tricks2, dressor2.Monkey);


void DoTricks(List<Trick> tricks, Monkey monkey)
{
    foreach (var trick in tricks)
    {
        spectator.React(trick, monkey);

        Thread.Sleep(1000);
    }
}

