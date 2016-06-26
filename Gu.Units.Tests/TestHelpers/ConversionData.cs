namespace Gu.Units.Tests
{
    public class ConversionData
    {
        public ConversionData(string @from,
                              string to,
                              bool exactly = true)
        {
            this.From = @from;
            this.To = to;
            this.Exactly = exactly;
        }

        public string From { get; }

        public string To { get; }

        public bool Exactly { get; }


        public override string ToString()
        {
            var equalitySymbol = this.Exactly
                                     ? "=="
                                     : "~";
            return $"{this.From} {equalitySymbol} {this.To}";
        }
    }
}