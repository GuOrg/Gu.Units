﻿namespace Gu.Units.Generator.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    public sealed class PrefixConversionComparer : IComparer<PrefixConversion>, IComparer
    {
        public static readonly PrefixConversionComparer Default = new();

        private PrefixConversionComparer()
        {
        }

        public int Compare(PrefixConversion x, PrefixConversion y)
        {
            if (x is null || y is null)
            {
                return -1;
            }

            if (x.Name != y.Name)
            {
                return -1;
            }

            if (x.Symbol != y.Symbol)
            {
                return -1;
            }

            if (PrefixComparer.Default.Compare(x.Prefix, y.Prefix) != 0)
            {
                return -1;
            }

            return 0;
        }

        int IComparer.Compare(object x, object y)
        {
            return this.Compare((PrefixConversion)x, (PrefixConversion)y);
        }
    }
}
