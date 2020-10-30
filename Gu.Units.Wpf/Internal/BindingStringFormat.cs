namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Data;

    internal static class BindingStringFormat
    {
        internal static bool TryGet<TUnit>(this Binding binding, out QuantityFormat<TUnit> format)
            where TUnit : struct, IUnit, IEquatable<TUnit>
        {
            var stringFormat = binding?.StringFormat;
            if (stringFormat == null)
            {
                format = null;
                return false;
            }

            return StringFormatParser<TUnit>.TryParse(stringFormat, out format);
        }
    }
}
