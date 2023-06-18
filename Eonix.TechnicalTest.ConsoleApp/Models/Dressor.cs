namespace Eonix.TechnicalTest.Models
{
    public class Dressor
    {
        public Monkey Monkey { get; init; }
        public Dressor(Monkey monkey)
        {
            Monkey = monkey;
        }
        public List<Trick> AskMonkeyToDoTrick()
        {
            Console.WriteLine("Le dresseur demande à son singe de faire un tour");
            return Monkey.Tricks;
        }
    }
}
