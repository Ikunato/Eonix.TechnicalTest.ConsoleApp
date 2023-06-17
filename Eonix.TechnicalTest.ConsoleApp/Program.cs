// See https://aka.ms/new-console-template for more information
using Eonix.TechnicalTest.Models;

var spectator = new Spectator();
var monkey1 = new Monkey();
var monkey2 = new Monkey();
var dressor1 = new Dressor(monkey1);
var dressor2 = new Dressor(monkey2);

Trick trick = dressor1.AskMonkeyToDoTrick();
if (trick.Type == TrickType.MUSIC)      spectator.Whistle();
if (trick.Type == TrickType.ACROBATIC)  spectator.Applause();
    


Console.WriteLine("Hello, World!");
