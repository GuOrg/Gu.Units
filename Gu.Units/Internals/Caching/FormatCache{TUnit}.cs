namespace Gu.Units
{
    using System;
    using System.Collections.Concurrent;
    using System.Diagnostics;

    internal class FormatCache<TUnit> where TUnit : struct, IUnit, IEquatable<TUnit>
    {
        internal static QuantityFormat<TUnit> DefaultQuantityFormat = CreateFromValueFormatAndUnit(new ValueAndUnitFormatKey(null, Unit<TUnit>.Default, DefaultSymbolFormat));

        private static SymbolFormat DefaultSymbolFormat => SymbolFormat.FractionSuperScript;
        private static readonly ConcurrentDictionary<IFormatKey, QuantityFormat<TUnit>> Cache = new ConcurrentDictionary<IFormatKey, QuantityFormat<TUnit>>();

        internal static QuantityFormat<TUnit> GetOrCreate(string compositeFormat)
        {
            return Cache.GetOrAdd(new CompositeFormatKey(compositeFormat), _ => CompositeFormatParser.Create<TUnit>(compositeFormat));
        }

        internal static QuantityFormat<TUnit> GetOrCreate(string valueFormat, TUnit unit)
        {
            var key = new ValueAndUnitFormatKey(valueFormat, unit, DefaultSymbolFormat);
            return Cache.GetOrAdd(key, _ => CreateFromValueFormatAndUnit(key));
        }

        internal static QuantityFormat<TUnit> GetOrCreate(string valueFormat, TUnit unit, SymbolFormat symbolFormat)
        {
            var key = new ValueAndUnitFormatKey(valueFormat, unit, symbolFormat);
            return Cache.GetOrAdd(key, _ => CreateFromValueFormatAndUnit(key));
        }

        public static QuantityFormat<TUnit> GetOrCreate(string valueFormat, string symbolFormat)
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

            TUnit unit;
            var symbolFormat = UnitFormatCache<TUnit>.GetOrCreate(key.SymbolFormat, out unit);

            return QuantityFormat<TUnit>.Create(valueFormat, symbolFormat, unit);
        }

        #region Keys

        internal interface IFormatKey : IEquatable<IFormatKey>
        {
        }

        [DebuggerDisplay("CompositeFormat: {CompositeFormat}")]
        internal struct CompositeFormatKey : IFormatKey, IEquatable<CompositeFormatKey>
        {
            internal readonly string CompositeFormat;

            public CompositeFormatKey(string compositeFormat)
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
                return string.Equals(this.CompositeFormat, other.CompositeFormat);
            }

            public bool Equals(IFormatKey other)
            {
                if (ReferenceEquals(null, other))
                {
                    return false;
                }

                return other is CompositeFormatKey && Equals((CompositeFormatKey)other);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                return obj is CompositeFormatKey && Equals((CompositeFormatKey)obj);
            }

            public override int GetHashCode()
            {
                return this.CompositeFormat?.GetHashCode() ?? 0;
            }
        }

        [DebuggerDisplay("ValueAndUnitFormatKey ValueFormat: {ValueFormat}, SymbolFormat: {SymbolFormat}, Unit: {Unit}")]
        internal struct ValueAndUnitFormatKey : IFormatKey, IEquatable<ValueAndUnitFormatKey>
        {
            internal readonly string ValueFormat;
            internal readonly TUnit Unit;
            internal readonly SymbolFormat SymbolFormat;

            public ValueAndUnitFormatKey(string valueFormat, TUnit unit, SymbolFormat symbolFormat)
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
                return string.Equals(this.ValueFormat, other.ValueFormat) &&
                       this.Unit.Equals(other.Unit) &&
                       string.Equals(this.SymbolFormat, other.SymbolFormat);
            }

            public bool Equals(IFormatKey other)
            {
                if (ReferenceEquals(null, other))
                {
                    return false;
                }

                return other is ValueAndUnitFormatKey && Equals((ValueAndUnitFormatKey)other);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                    return false;
                return obj is ValueAndUnitFormatKey && Equals((ValueAndUnitFormatKey)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = this.ValueFormat?.GetHashCode() ?? 0;
                    hashCode = (hashCode * 397) ^ (this.SymbolFormat.GetHashCode());
                    hashCode = (hashCode * 397) ^ this.Unit.GetHashCode();
                    return hashCode;
                }
            }
        }

        [DebuggerDisplay("ValueAndSymbolFormatKey ValueFormat: {ValueFormat}, SymbolFormat: {SymbolFormat}")]
        internal struct ValueAndSymbolFormatKey : IFormatKey, IEquatable<ValueAndSymbolFormatKey>
        {
            internal readonly string ValueFormat;
            internal readonly string SymbolFormat;

            public ValueAndSymbolFormatKey(string valueFormat, string symbolFormat)
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
                return string.Equals(this.ValueFormat, other.ValueFormat) &&
                       string.Equals(this.SymbolFormat, other.SymbolFormat);
            }

            public bool Equals(IFormatKey other)
            {
                if (ReferenceEquals(null, other))
                {
                    return false;
                }

                return other is ValueAndSymbolFormatKey && Equals((ValueAndSymbolFormatKey)other);
            }

            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj))
                {
                    return false;
                }

                return obj is ValueAndSymbolFormatKey && Equals((ValueAndSymbolFormatKey)obj);
            }

            public override int GetHashCode()
            {
                unchecked
                {
                    var hashCode = this.ValueFormat?.GetHashCode() ?? 0;
                    hashCode = (hashCode * 397) ^ (this.SymbolFormat?.GetHashCode() ?? 0);
                    return hashCode;
                }
            }
        }

        #endregion Keys
    }
}
