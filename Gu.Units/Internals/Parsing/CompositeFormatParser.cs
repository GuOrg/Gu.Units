namespace Gu.Units
{
    using System;

    internal static class CompositeFormatParser
    {
        internal static QuantityFormat<TUnit> Create<TUnit>(string format) where TUnit : struct, IUnit, IEquatable<TUnit>
        {
            QuantityFormat<TUnit> result;
            TryParse(format, out result);
            return result;
        }

        internal static bool TryParse<TUnit>(string format, out QuantityFormat<TUnit> result)
            where TUnit : struct, IUnit, IEquatable<TUnit>
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                result = QuantityFormat<TUnit>.Default;
                return true;
            }

            int pos = 0;
            return TryParse(format, ref pos, out result);
        }

        internal static bool TryParse<TUnit>(string format, ref int pos,  out QuantityFormat<TUnit> result)
                where TUnit : struct, IUnit, IEquatable<TUnit>
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                result = QuantityFormat<TUnit>.Default;
                return true;
            }

            var valueFormat = DoubleFormatCache.GetOrCreate(format, ref pos);

            TUnit unit;
            var symbolFormat = UnitFormatCache<TUnit>.GetOrCreate(format, ref pos, out unit);
            if (valueFormat.PostPadding == null &&
                symbolFormat.PrePadding == null)
            {
                valueFormat = valueFormat.WithPostPadding(string.Empty);
                // we want to keep the padding specified in the format
                // if both are null QuantityFormat infers padding.
            }
            if (valueFormat.IsUnknown)
            {
                if (symbolFormat.IsUnknown)
                {
                    result = QuantityFormat<TUnit>.CreateUnknown(format, Unit<TUnit>.Default);
                    return false;
                }

                if (valueFormat.Format.StartsWith(symbolFormat.Format))
                {
                    valueFormat = valueFormat.WithFormat(null);
                }
            }
            result = QuantityFormat<TUnit>.Create(valueFormat, symbolFormat, unit);

            return !(valueFormat.IsUnknown || symbolFormat.IsUnknown);
        }
    }
}
