namespace Gu.Units.Generator.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    public class FactorConversionComparer : IComparer<FactorConversion>, IComparer
    {
        public static readonly FactorConversionComparer Default = new FactorConversionComparer();

        private FactorConversionComparer()
        {
        }

        public int Compare(FactorConversion x, FactorConversion y)
        {
            if (x.Factor != y.Factor)
            {
                return -1;
            }

            return 0;
        }

        int IComparer.Compare(object x, object y)
        {
            return Compare((FactorConversion) x, (FactorConversion) y);
        }
    }
}