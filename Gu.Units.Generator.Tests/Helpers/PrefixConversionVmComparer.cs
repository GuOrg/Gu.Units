namespace Gu.Units.Generator.Tests
{
    using System.Collections;
    using System.Collections.Generic;

    public sealed class PrefixConversionVmComparer : IComparer<PrefixConversionVm>, IComparer
    {
        public static readonly PrefixConversionVmComparer Default = new();

        private PrefixConversionVmComparer()
        {
        }

        public int Compare(PrefixConversionVm x, PrefixConversionVm y)
        {
            return PrefixConversionComparer.Default.Compare((PrefixConversion)x?.Conversion, (PrefixConversion)y?.Conversion);
        }

        int IComparer.Compare(object x, object y)
        {
            return this.Compare((PrefixConversionVm)x, (PrefixConversionVm)y);
        }
    }
}
