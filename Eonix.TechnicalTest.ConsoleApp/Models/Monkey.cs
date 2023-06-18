namespace Eonix.TechnicalTest.Models
{

    public class Monkey
    {
        public string Name { get; init; }
        public List<Trick> Tricks { get; init; }

        public Monkey(string name)
        {
            Name = name;
            Tricks = InitTricks();
        }

        private List<Trick> InitTricks()
        {
            return new List<Trick>
            {
                new Trick("marcher sur les mains", TrickType.ACROBATIC),
                new Trick("jouer de la guitare", TrickType.MUSIC),
                new Trick("faire du trampoline", TrickType.ACROBATIC),
                new Trick("jouer du piano", TrickType.MUSIC),
                new Trick("faire du Beatboxing", TrickType.MUSIC),
                new Trick("faire du cerceau", TrickType.ACROBATIC),
                new Trick("jongler avec une balle de foot", TrickType.ACROBATIC),
                new Trick("jouer du saxophone", TrickType.MUSIC),
            };
        }
    }
}
