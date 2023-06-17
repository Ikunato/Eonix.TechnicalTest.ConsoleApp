namespace Eonix.TechnicalTest.Models
{
    public enum TrickType
    {
        MUSIC,
        ACROBATIC
    }

    public class Trick
    {
        public string Name { get; set; }
        public TrickType Type { get; set; }

        public Trick(string name, TrickType type)
        {
            Name = name;
            Type = type;
        }
    }
}
