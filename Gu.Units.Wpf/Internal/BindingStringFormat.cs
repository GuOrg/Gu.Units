namespace Gu.Units.Wpf
{
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Windows.Data;

    internal static class BindingStringFormat
    {
        internal static bool TryGet<TUnit>(this Binding binding, [NotNullWhen(true)] out QuantityFormat<TUnit>? format)
            where TUnit : struct, IUnit, IEquatable<TUnit>
        {
            if (binding?.StringFormat is { } stringFormat)
            {
                return StringFormatParser<TUnit>.TryParse(stringFormat, out format);
            }

            format = null;
            return false;
        }
    }
}
