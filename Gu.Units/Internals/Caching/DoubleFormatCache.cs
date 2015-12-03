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

            PaddedFormat match;
            if (Cache.TryGet(format, out match))
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
            string prePadding;
            format.TryRead(ref pos, out prePadding);
            string valueFormat;
            if (DoubleFormatReader.TryRead(format, ref pos, out valueFormat))
            {
                string postPadding;
                WhiteSpaceReader.TryRead(format, ref pos, out postPadding);
                return new PaddedFormat(prePadding, valueFormat, postPadding);
            }

            return PaddedFormat.CreateUnknown(prePadding, format);
        }
    }
}