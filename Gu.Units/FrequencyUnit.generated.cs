namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Frequency"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(FrequencyUnitTypeConverter))]
    public struct FrequencyUnit : IUnit, IUnit<Frequency>, IEquatable<FrequencyUnit>
    {
        /// <summary>
        /// The FrequencyUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly FrequencyUnit Hertz = new FrequencyUnit(hertz => hertz, hertz => hertz, "Hz");

        /// <summary>
        /// The Millihertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Millihertz = new FrequencyUnit(millihertz => millihertz / 1000, hertz => 1000 * hertz, "mHz");

        /// <summary>
        /// The Kilohertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Kilohertz = new FrequencyUnit(kilohertz => 1000 * kilohertz, hertz => hertz / 1000, "kHz");

        /// <summary>
        /// The Megahertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Megahertz = new FrequencyUnit(megahertz => 1000000 * megahertz, hertz => hertz / 1000000, "MHz");

        /// <summary>
        /// The Gigahertz unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly FrequencyUnit Gigahertz = new FrequencyUnit(gigahertz => 1000000000 * gigahertz, hertz => hertz / 1000000000, "GHz");

        private readonly Func<double, double> toHertz;
        private readonly Func<double, double> fromHertz;
        internal readonly string symbol;

        public FrequencyUnit(Func<double, double> toHertz, Func<double, double> fromHertz, string symbol)
        {
            this.toHertz = toHertz;
            this.fromHertz = fromHertz;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.FrequencyUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.FrequencyUnit"/>
        /// </summary>
        public FrequencyUnit SiUnit => Hertz;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.FrequencyUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Hertz;

        public static Frequency operator *(double left, FrequencyUnit right)
        {
            return Frequency.From(left, right);
        }

        public static bool operator ==(FrequencyUnit left, FrequencyUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(FrequencyUnit left, FrequencyUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="FrequencyUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="FrequencyUnit"/></returns>
        public static FrequencyUnit Parse(string text)
        {
            return UnitParser<FrequencyUnit>.Parse(text);
        }

        public static bool TryParse(string text, out FrequencyUnit value)
        {
            return UnitParser<FrequencyUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Hertz.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toHertz(value);
        }

        /// <summary>
        /// Converts a value from hertz.
        /// </summary>
        /// <param name="Hertz">The value in Hertz</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double hertz)
        {
            return this.fromHertz(hertz);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Frequency(<paramref name="value"/>, this)</returns>
        public Frequency CreateQuantity(double value)
        {
            return new Frequency(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Hertz
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Frequency quantity)
        {
            return FromSiUnit(quantity.hertz);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            FrequencyUnit unit;
            var paddedFormat = UnitFormatCache<FrequencyUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<FrequencyUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(FrequencyUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is FrequencyUnit && Equals((FrequencyUnit)obj);
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