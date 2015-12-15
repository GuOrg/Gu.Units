namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.MassFlow"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MassFlowUnitTypeConverter))]
    public struct MassFlowUnit : IUnit, IUnit<MassFlow>, IEquatable<MassFlowUnit>
    {
        /// <summary>
        /// The MassFlowUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MassFlowUnit KilogramsPerSecond = new MassFlowUnit(kilogramsPerSecond => kilogramsPerSecond, kilogramsPerSecond => kilogramsPerSecond, "kg/s");

        private readonly Func<double, double> toKilogramsPerSecond;
        private readonly Func<double, double> fromKilogramsPerSecond;
        internal readonly string symbol;

        public MassFlowUnit(Func<double, double> toKilogramsPerSecond, Func<double, double> fromKilogramsPerSecond, string symbol)
        {
            this.toKilogramsPerSecond = toKilogramsPerSecond;
            this.fromKilogramsPerSecond = fromKilogramsPerSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.MassFlowUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.MassFlowUnit"/>
        /// </summary>
        public MassFlowUnit SiUnit => KilogramsPerSecond;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.MassFlowUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => KilogramsPerSecond;

        public static MassFlow operator *(double left, MassFlowUnit right)
        {
            return MassFlow.From(left, right);
        }

        public static bool operator ==(MassFlowUnit left, MassFlowUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MassFlowUnit left, MassFlowUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MassFlowUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="MassFlowUnit"/></returns>
        public static MassFlowUnit Parse(string text)
        {
            return UnitParser<MassFlowUnit>.Parse(text);
        }

        public static bool TryParse(string text, out MassFlowUnit value)
        {
            return UnitParser<MassFlowUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to KilogramsPerSecond.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKilogramsPerSecond(value);
        }

        /// <summary>
        /// Converts a value from kilogramsPerSecond.
        /// </summary>
        /// <param name="KilogramsPerSecond">The value in KilogramsPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double kilogramsPerSecond)
        {
            return this.fromKilogramsPerSecond(kilogramsPerSecond);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new MassFlow(<paramref name="value"/>, this)</returns>
        public MassFlow CreateQuantity(double value)
        {
            return new MassFlow(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in KilogramsPerSecond
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(MassFlow quantity)
        {
            return FromSiUnit(quantity.kilogramsPerSecond);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            MassFlowUnit unit;
            var paddedFormat = UnitFormatCache<MassFlowUnit>.GetOrCreate(format, out unit);
            if (unit != this)
            {
                return format;
            }

            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<MassFlowUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(MassFlowUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MassFlowUnit && Equals((MassFlowUnit)obj);
        }

        /// <summary>
        /// Returns the hashcode for this <see cref="LengthUnit"/>
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            if (this.symbol == null)
            {
                return 0; // Needed due to default ctor
            }

            return this.symbol.GetHashCode();
        }
    }
}