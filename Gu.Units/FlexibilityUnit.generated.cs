namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Flexibility"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(FlexibilityUnitTypeConverter))]
    public struct FlexibilityUnit : IUnit, IUnit<Flexibility>, IEquatable<FlexibilityUnit>
    {
        /// <summary>
        /// The FlexibilityUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MetresPerNewton = new FlexibilityUnit(metresPerNewton => metresPerNewton, metresPerNewton => metresPerNewton, "m/N");

        /// <summary>
        /// The MillimetresPerNewton unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerNewton = new FlexibilityUnit(millimetresPerNewton => millimetresPerNewton / 1000, metresPerNewton => 1000 * metresPerNewton, "mm/N");

        /// <summary>
        /// The MillimetresPerKilonewton unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MillimetresPerKilonewton = new FlexibilityUnit(millimetresPerKilonewton => millimetresPerKilonewton / 1000000, metresPerNewton => 1000000 * metresPerNewton, "mm/kN");

        /// <summary>
        /// The MicrometresPerKilonewton unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FlexibilityUnit MicrometresPerKilonewton = new FlexibilityUnit(micrometresPerKilonewton => micrometresPerKilonewton / 1000000000, metresPerNewton => 1000000000 * metresPerNewton, "µm/kN");

        private readonly Func<double, double> toMetresPerNewton;
        private readonly Func<double, double> fromMetresPerNewton;
        internal readonly string symbol;

        public FlexibilityUnit(Func<double, double> toMetresPerNewton, Func<double, double> fromMetresPerNewton, string symbol)
        {
            this.toMetresPerNewton = toMetresPerNewton;
            this.fromMetresPerNewton = fromMetresPerNewton;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.FlexibilityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.FlexibilityUnit"/>
        /// </summary>
        public FlexibilityUnit SiUnit => MetresPerNewton;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.FlexibilityUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => MetresPerNewton;

        public static Flexibility operator *(double left, FlexibilityUnit right)
        {
            return Flexibility.From(left, right);
        }

        public static bool operator ==(FlexibilityUnit left, FlexibilityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FlexibilityUnit left, FlexibilityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="FlexibilityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="FlexibilityUnit"/></returns>
        public static FlexibilityUnit Parse(string text)
        {
            return UnitParser<FlexibilityUnit>.Parse(text);
        }

        public static bool TryParse(string text, out FlexibilityUnit value)
        {
            return UnitParser<FlexibilityUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerNewton.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerNewton(value);
        }

        /// <summary>
        /// Converts a value from metresPerNewton.
        /// </summary>
        /// <param name="MetresPerNewton">The value in MetresPerNewton</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerNewton)
        {
            return this.fromMetresPerNewton(metresPerNewton);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Flexibility(<paramref name="value"/>, this)</returns>
        public Flexibility CreateQuantity(double value)
        {
            return new Flexibility(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerNewton
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Flexibility quantity)
        {
            return FromSiUnit(quantity.metresPerNewton);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            FlexibilityUnit unit;
            var paddedFormat = UnitFormatCache<FlexibilityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<FlexibilityUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(FlexibilityUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is FlexibilityUnit && Equals((FlexibilityUnit)obj);
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