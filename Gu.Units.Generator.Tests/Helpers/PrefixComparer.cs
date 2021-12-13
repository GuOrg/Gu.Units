﻿namespace Gu.Units.Generator.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    public sealed class PrefixComparer : IComparer<Prefix>, IComparer
    {
        public static readonly PrefixComparer Default = new();

        private PrefixComparer()
        {
        }

        public int Compare(Prefix x, Prefix y)
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

            if (x.Power != y.Power)
            {
                return -1;
            }

            return 0;
        }

        int IComparer.Compare(object x, object y)
        {
            return this.Compare((Prefix)x, (Prefix)y);
        }
    }
}