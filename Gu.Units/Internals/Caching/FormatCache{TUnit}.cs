namespace Gu.Units
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;

    internal static class FormatCache<TUnit>
        where TUnit : struct, IUnit, IEquatable<TUnit>
    {
        internal static readonly QuantityFormat<TUnit> DefaultQuantityFormat = CreateFromValueFormatAndUnit(new ValueAndUnitFormatKey(null, Unit<TUnit>.Default, DefaultSymbolFormat));

        private static readonly ConcurrentDictionary<IFormatKey, QuantityFormat<TUnit>> Cache = new ConcurrentDictionary<IFormatKey, QuantityFormat<TUnit>>();

        private static readonly StringComparer OrdinalComparer = StringComparer.Ordinal;

        /// <summary> For use as key in the cache. </summary>
        internal interface IFormatKey : IEquatable<IFormatKey>
        {
        }

        private static SymbolFormat DefaultSymbolFormat => SymbolFormat.FractionSuperScript;

        internal static QuantityFormat<TUnit> GetOrCreate(string? compositeFormat)
        {
            return Cache.GetOrAdd(new CompositeFormatKey(compositeFormat), _ => CompositeFormatParser.Create<TUnit>(compositeFormat));
        }

        internal static QuantityFormat<TUnit> GetOrCreate(string? valueFormat, TUnit unit)
        {
            var key = new ValueAndUnitFormatKey(valueFormat, unit, DefaultSymbolFormat);
            return Cache.GetOrAdd(key, _ => CreateFromValueFormatAndUnit(key));
        }

        internal static QuantityFormat<TUnit> GetOrCreate(string? valueFormat, TUnit unit, SymbolFormat symbolFormat)
        {
            var key = new ValueAndUnitFormatKey(valueFormat, unit, symbolFormat);
            return Cache.GetOrAdd(key, _ => CreateFromValueFormatAndUnit(key));
        }

        internal static QuantityFormat<TUnit> GetOrCreate(string valueFormat, string symbolFormat)
        {
            var key = new ValueAndSymbolFormatKey(valueFormat, symbolFormat);
            return Cache.GetOrAdd(key, _ => CreateFromValueAndSymbolFormats(key));
        }

        private static QuantityFormat<TUnit> CreateFromValueFormatAndUnit(ValueAndUnitFormatKey key)
        {
            var valueFormat = DoubleFormatCache.GetOrCreate(key.ValueFormat);
            var unit = key.Unit;
            var symbolFormat = UnitFormatCache<TUnit>.GetOrCreate(unit, key.SymbolFormat);
            return QuantityFormat<TUnit>.Create(valueFormat, symbolFormat, unit);
        }

        private static QuantityFormat<TUnit> CreateFromValueAndSymbolFormats(ValueAndSymbolFormatKey key)
        {
            var valueFormat = DoubleFormatCache.GetOrCreate(key.ValueFormat);

            var symbolFormat = UnitFormatCache<TUnit>.GetOrCreate(key.SymbolFormat, out var unit);

            return QuantityFormat<TUnit>.Create(valueFormat, symbolFormat, unit);
        }

        [DebuggerDisplay("CompositeFormat: {CompositeFormat}")]
        internal readonly struct CompositeFormatKey : IFormatKey, IEquatable<CompositeFormatKey>
        {
            internal readonly string? CompositeFormat;

            internal CompositeFormatKey(string? compositeFormat)
            {
                this.CompositeFormat = compositeFormat;
            }

            public static bool operator ==(CompositeFormatKey left, CompositeFormatKey right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(CompositeFormatKey left, CompositeFormatKey right)
            {
                return !left.Equals(right);
            }

            public bool Equals(CompositeFormatKey other)
            {
                return OrdinalComparer.Equals(this.CompositeFormat, other.CompositeFormat);
            }

            public bool Equals(IFormatKey? other)
            {
                return other is CompositeFormatKey key && this.Equals(key);
            }

            public override bool Equals(object? obj)
            {
                return obj is CompositeFormatKey key && this.Equals(key);
            }

            public override int GetHashCode()
            {
                return OrdinalComparer.GetHashCode(this.CompositeFormat ?? string.Empty);
            }
        }

        [DebuggerDisplay("ValueAndUnitFormatKey ValueFormat: {ValueFormat}, SymbolFormat: {SymbolFormat}, Unit: {Unit}")]
        internal readonly struct ValueAndUnitFormatKey : IFormatKey, IEquatable<ValueAndUnitFormatKey>
        {
            internal readonly string? ValueFormat;
            internal readonly TUnit Unit;
            internal readonly SymbolFormat SymbolFormat;

            internal ValueAndUnitFormatKey(string? valueFormat, TUnit unit, SymbolFormat symbolFormat)
            {
                this.ValueFormat = valueFormat;
                this.Unit = unit;
                this.SymbolFormat = symbolFormat;
            }

            public static bool operator ==(ValueAndUnitFormatKey left, ValueAndUnitFormatKey right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(ValueAndUnitFormatKey left, ValueAndUnitFormatKey right)
            {
                return !left.Equals(right);
            }

            public bool Equals(ValueAndUnitFormatKey other)
            {
                return OrdinalComparer.Equals(this.ValueFormat, other.ValueFormat) &&
                       this.Unit.Equals(other.Unit) &&
                       Equals(this.SymbolFormat, other.SymbolFormat);
            }

            public bool Equals(IFormatKey? other)
            {
                return other is ValueAndUnitFormatKey key && this.Equals(key);
            }

            public override bool Equals(object? obj)
            {
                return obj is ValueAndUnitFormatKey key && this.Equals(key);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = OrdinalComparer.GetHashCode(this.ValueFormat ?? string.Empty);
                    hashCode = (hashCode * 397) ^ this.SymbolFormat.GetHashCode();
                    hashCode = (hashCode * 397) ^ this.Unit.GetHashCode();
                    return hashCode;
                }
            }
        }

        [DebuggerDisplay("ValueAndSymbolFormatKey ValueFormat: {ValueFormat}, SymbolFormat: {SymbolFormat}")]
        internal readonly struct ValueAndSymbolFormatKey : IFormatKey, IEquatable<ValueAndSymbolFormatKey>
        {
            internal readonly string ValueFormat;
            internal readonly string SymbolFormat;

            internal ValueAndSymbolFormatKey(string valueFormat, string symbolFormat)
            {
                this.ValueFormat = valueFormat;
                this.SymbolFormat = symbolFormat;
            }

            public static bool operator ==(ValueAndSymbolFormatKey left, ValueAndSymbolFormatKey right)
            {
                return left.Equals(right);
            }

            public static bool operator !=(ValueAndSymbolFormatKey left, ValueAndSymbolFormatKey right)
            {
                return !left.Equals(right);
            }

            public bool Equals(ValueAndSymbolFormatKey other)
            {
                return OrdinalComparer.Equals(this.ValueFormat, other.ValueFormat) &&
                       OrdinalComparer.Equals(this.SymbolFormat, other.SymbolFormat);
            }

            public bool Equals(IFormatKey? other)
            {
                return other is ValueAndSymbolFormatKey key && this.Equals(key);
            }

            public override bool Equals(object? obj)
            {
                return obj is ValueAndSymbolFormatKey key && this.Equals(key);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = OrdinalComparer.GetHashCode(this.ValueFormat);
                    hashCode = (hashCode * 397) ^ OrdinalComparer.GetHashCode(this.SymbolFormat);
                    return hashCode;
                }
            }
        }
    }
}
