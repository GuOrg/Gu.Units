namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Mass"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MassUnitTypeConverter))]
    public struct MassUnit : IUnit, IUnit<Mass>, IEquatable<MassUnit>
    {
        /// <summary>
        /// The MassUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MassUnit Kilograms = new MassUnit(kilograms => kilograms, kilograms => kilograms, "kg");

        /// <summary>
        /// The Grams unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Grams = new MassUnit(grams => grams / 1000, kilograms => 1000 * kilograms, "g");

        /// <summary>
        /// The Milligrams unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Milligrams = new MassUnit(milligrams => milligrams / 1000000, kilograms => 1000000 * kilograms, "mg");

        /// <summary>
        /// The Micrograms unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MassUnit Micrograms = new MassUnit(micrograms => micrograms / 1000000000, kilograms => 1000000000 * kilograms, "µg");

        private readonly Func<double, double> toKilograms;
        private readonly Func<double, double> fromKilograms;
        internal readonly string symbol;

        public MassUnit(Func<double, double> toKilograms, Func<double, double> fromKilograms, string symbol)
        {
            this.toKilograms = toKilograms;
            this.fromKilograms = fromKilograms;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.MassUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.MassUnit"/>
        /// </summary>
        public MassUnit SiUnit => Kilograms;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.MassUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Kilograms;

        public static Mass operator *(double left, MassUnit right)
        {
            return Mass.From(left, right);
        }

        public static bool operator ==(MassUnit left, MassUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MassUnit left, MassUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MassUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="MassUnit"/></returns>
        public static MassUnit Parse(string text)
        {
            return UnitParser<MassUnit>.Parse(text);
        }

        public static bool TryParse(string text, out MassUnit value)
        {
            return UnitParser<MassUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Kilograms.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKilograms(value);
        }

        /// <summary>
        /// Converts a value from kilograms.
        /// </summary>
        /// <param name="kilograms">The value in Kilograms</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double kilograms)
        {
            return this.fromKilograms(kilograms);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Mass(<paramref name="value"/>, this)</returns>
        public Mass CreateQuantity(double value)
        {
            return new Mass(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Kilograms
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Mass quantity)
        {
            return FromSiUnit(quantity.kilograms);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            MassUnit unit;
            var paddedFormat = UnitFormatCache<MassUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<MassUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(MassUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MassUnit && Equals((MassUnit)obj);
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