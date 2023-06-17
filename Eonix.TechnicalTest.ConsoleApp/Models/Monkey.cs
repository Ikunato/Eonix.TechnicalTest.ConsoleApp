namespace Eonix.TechnicalTest.Models
{

    public class Monkey
    {
        public List<Trick> tricks { get; init; }

        public Monkey()
        {
            tricks = InitTricks();
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

        public Trick DoTrick()
        {
            var random = new Random();
            var number = random.Next(tricks.Count);
            var trick = tricks.ElementAt(number);

            return trick;
        }
    }
}
