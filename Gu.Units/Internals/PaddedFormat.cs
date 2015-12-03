namespace Gu.Units
{
    internal struct PaddedFormat
    {
        internal static readonly PaddedFormat NullFormat = new PaddedFormat(null, null, null);

        internal readonly string PrePadding;
        internal readonly string Format;
        internal readonly bool IsUnknown;
        internal readonly string PostPadding;

        private PaddedFormat(string prePadding,
            string format,
            string postPadding,
            bool isUnknown)
        {
            this.PrePadding = prePadding;
            this.Format = format;
            this.IsUnknown = isUnknown;
            this.PostPadding = postPadding;
        }
        private PaddedFormat(string prePadding,
            string format)
        {
            this.PrePadding = prePadding;
            this.Format = format;
            this.PostPadding = null;
            this.IsUnknown = true;
        }

        public PaddedFormat(string prePadding,
            string format,
            string postPadding)
        {
            this.PrePadding = prePadding;
            this.Format = format;
            this.PostPadding = postPadding;
            this.IsUnknown = false;
        }

        public override string ToString()
        {
            return $"PrePadding: {this.PrePadding ?? "null"}, Format: {this.Format ?? "null"}, PostPadding: {this.PostPadding ?? "null"}, IsUnknown: {this.IsUnknown}";
        }

        internal static PaddedFormat CreateUnknown(string prePadding, string format)
        {
            return new PaddedFormat(prePadding, format);
        }

        internal PaddedFormat AsUnknownFormat()
        {
            return new PaddedFormat(this.PrePadding, this.Format);
        }

        internal PaddedFormat WithPostPadding(string padding)
        {
            return new PaddedFormat(this.PrePadding, this.Format, padding, this.IsUnknown);
        }

        public PaddedFormat WithFormat(string format)
        {
            return new PaddedFormat(this.PrePadding, format, this.PostPadding, this.IsUnknown);
        }
    }
}
