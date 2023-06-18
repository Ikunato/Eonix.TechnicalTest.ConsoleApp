namespace Eonix.TechnicalTest.Models
{
    public class Spectator
    {
        public Spectator(){}

        public void React(Trick trick, Monkey monkey)
        {
            string react = trick.Type == TrickType.ACROBATIC ? "applaudit" : "siffle";
            Console.WriteLine($"Le spectateur {react} penant le tour {trick.Name} du {monkey.Name}");
        }
    }
}
