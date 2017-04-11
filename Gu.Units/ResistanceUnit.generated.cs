namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Resistance"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ResistanceUnitTypeConverter))]
    public struct ResistanceUnit : IUnit, IUnit<Resistance>, IEquatable<ResistanceUnit>
    {
        /// <summary>
        /// The Ohms unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly ResistanceUnit Ohms = new ResistanceUnit(ohms => ohms, ohms => ohms, "Ω");

        /// <summary>
        /// The Microohms unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Microohms = new ResistanceUnit(microohms => microohms / 1000000, ohms => 1000000 * ohms, "µΩ");

        /// <summary>
        /// The Milliohms unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Milliohms = new ResistanceUnit(milliohms => milliohms / 1000, ohms => 1000 * ohms, "mΩ");

        /// <summary>
        /// The Kiloohms unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Kiloohms = new ResistanceUnit(kiloohms => 1000 * kiloohms, ohms => ohms / 1000, "kΩ");

        /// <summary>
        /// The Megaohms unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ResistanceUnit Megaohms = new ResistanceUnit(megaohms => 1000000 * megaohms, ohms => ohms / 1000000, "MΩ");

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.ResistanceUnit"/>.
        /// </summary>
        internal readonly string symbol;

        private readonly Func<double, double> toOhms;
        private readonly Func<double, double> fromOhms;

        /// <summary>
        /// Initializes a new instance of the <see cref="ResistanceUnit"/> struct.
        /// </summary>
        /// <param name="toOhms">The conversion to <see cref="Ohms"/></param>
        /// <param name="fromOhms">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Ohms"/></param>
        public ResistanceUnit(Func<double, double> toOhms, Func<double, double> fromOhms, string symbol)
        {
            this.toOhms = toOhms;
            this.fromOhms = fromOhms;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.ResistanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.ResistanceUnit"/>
        /// </summary>
        public ResistanceUnit SiUnit => Ohms;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Ohms;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Resistance"/> that is the result from the multiplication.</returns>
        public static Resistance operator *(double left, ResistanceUnit right)
        {
            return Resistance.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ResistanceUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ResistanceUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ResistanceUnit"/>.</param>
        public static bool operator ==(ResistanceUnit left, ResistanceUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ResistanceUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.ResistanceUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.ResistanceUnit"/>.</param>
        public static bool operator !=(ResistanceUnit left, ResistanceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="ResistanceUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="ResistanceUnit"/></returns>
        public static ResistanceUnit Parse(string text)
        {
            return UnitParser<ResistanceUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ResistanceUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ResistanceUnit"/></param>
        /// <param name="result">The parsed <see cref="ResistanceUnit"/></param>
        /// <returns>True if an instance of <see cref="ResistanceUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out ResistanceUnit result)
        {
            return UnitParser<ResistanceUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Ohms.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toOhms(value);
        }

        /// <summary>
        /// Converts a value from ohms.
        /// </summary>
        /// <param name="ohms">The value in Ohms</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double ohms)
        {
            return this.fromOhms(ohms);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Resistance(<paramref name="value"/>, this)</returns>
        public Resistance CreateQuantity(double value)
        {
            return new Resistance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Ohms
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Resistance quantity)
        {
            return this.FromSiUnit(quantity.ohms);
        }

        /// <inheritdoc />
        public override string ToString()
        {
            return this.symbol;
        }

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="format">The format to use when convereting</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string format)
        {
            ResistanceUnit unit;
            var paddedFormat = UnitFormatCache<ResistanceUnit>.GetOrCreate(format, out unit);
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

        /// <summary>
        /// Converts the unit value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(SymbolFormat symbolFormat)
        {
            var paddedFormat = UnitFormatCache<ResistanceUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ResistanceUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.ResistanceUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ResistanceUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(ResistanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        /// <inheritdoc />
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ResistanceUnit && this.Equals((ResistanceUnit)obj);
        }

        /// <inheritdoc />
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