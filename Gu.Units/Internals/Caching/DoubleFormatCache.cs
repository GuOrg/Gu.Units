namespace Gu.Units
{
    using System;

    internal static class DoubleFormatCache
    {
        private static readonly StringMap<PaddedFormat> Cache = new StringMap<PaddedFormat>();

        internal static PaddedFormat GetOrCreate(string format)
        {
            if (String.IsNullOrEmpty(format))
            {
                return PaddedFormat.NullFormat;
            }

            if (Cache.TryGet(format, out PaddedFormat match))
            {
                return match;
            }

            int pos = 0;
            var paddedFormat = GetOrCreate(format, ref pos);
            if (!WhiteSpaceReader.IsRestWhiteSpace(format, pos))
            {
                paddedFormat = paddedFormat.AsUnknownFormat();
            }

            Cache.Add(format, paddedFormat);
            return paddedFormat;
        }

        internal static PaddedFormat GetOrCreate(string format, ref int pos)
        {
            WhiteSpaceReader.TryRead(format, ref pos, out string prePadding);
            if (DoubleFormatReader.TryRead(format, ref pos, out string valueFormat))
            {
                WhiteSpaceReader.TryRead(format, ref pos, out string postPadding);
                return new PaddedFormat(prePadding, valueFormat, postPadding);
            }

            return PaddedFormat.CreateUnknown(prePadding, format);
        }
    }
}