namespace Gu.Units
{
    internal static class DoubleFormatCache
    {
        private static readonly StringMap<PaddedFormat> Cache = new StringMap<PaddedFormat>();

        internal static PaddedFormat GetOrCreate(string? format)
        {
            if (string.IsNullOrEmpty(format))
            {
                return PaddedFormat.NullFormat;
            }

            if (Cache.TryGet(format, out var match))
            {
                return match;
            }

            var pos = 0;
            var paddedFormat = GetOrCreate(format, ref pos);
            if (!WhiteSpaceReader.IsRestWhiteSpace(format, pos))
            {
                paddedFormat = paddedFormat.AsUnknownFormat();
            }

            _ = Cache.Add(format, paddedFormat);
            return paddedFormat;
        }

        internal static PaddedFormat GetOrCreate(string format, ref int pos)
        {
            _ = WhiteSpaceReader.TryRead(format, ref pos, out var prePadding);
            if (DoubleFormatReader.TryRead(format, ref pos, out var valueFormat))
            {
                _ = WhiteSpaceReader.TryRead(format, ref pos, out var postPadding);
                return new PaddedFormat(prePadding, valueFormat, postPadding);
            }

            return PaddedFormat.CreateUnknown(prePadding, format);
        }
    }
}