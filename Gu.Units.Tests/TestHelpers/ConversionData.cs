namespace Gu.Units.Tests
{
    public class ConversionData
    {
        public readonly GenerationStatus Status;

        public ConversionData(string @from,
                              string to,
                              bool exactly = true,
                              GenerationStatus status = GenerationStatus.Ok)
        {
            this.Status = status;
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

        /// <summary>
        /// The reason for this is that the generator chokes. Nice to be able to write tests as reminders
        /// </summary>
        public enum GenerationStatus
        {
            Ok,
            NotGenerated
        }
    }
}