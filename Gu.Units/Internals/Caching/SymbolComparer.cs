namespace Gu.Units
{
    using System;
    using System.Collections.Generic;

    internal class SymbolComparer : IComparer<SymbolAndPower>
    {
        public static readonly SymbolComparer Default = new SymbolComparer();

        private SymbolComparer()
        {
        }

        public int Compare(SymbolAndPower x, SymbolAndPower y)
        {
            return StringComparer.InvariantCulture.Compare(x.Symbol, y.Symbol);
        }
    }
}