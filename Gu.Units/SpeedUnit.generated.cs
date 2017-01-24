﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Speed"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(SpeedUnitTypeConverter))]
    public struct SpeedUnit : IUnit, IUnit<Speed>, IEquatable<SpeedUnit>
    {
        /// <summary>
        /// The MetresPerSecond unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerSecond = new SpeedUnit(metresPerSecond => metresPerSecond, metresPerSecond => metresPerSecond, "m/s");


        /// <summary>
        /// The KilometresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit KilometresPerHour = new SpeedUnit(kilometresPerHour => 0.277777777777778 * kilometresPerHour, metresPerSecond => metresPerSecond / 0.277777777777778, "km/h");


        /// <summary>
        /// The CentimetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit CentimetresPerMinute = new SpeedUnit(centimetresPerMinute => centimetresPerMinute / 6000, metresPerSecond => 6000 * metresPerSecond, "cm/min");


        /// <summary>
        /// The MetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerMinute = new SpeedUnit(metresPerMinute => metresPerMinute / 60, metresPerSecond => 60 * metresPerSecond, "m/min");


        /// <summary>
        /// The MetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MetresPerHour = new SpeedUnit(metresPerHour => metresPerHour / 3600, metresPerSecond => 3600 * metresPerSecond, "m/h");


        /// <summary>
        /// The MillimetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MillimetresPerHour = new SpeedUnit(millimetresPerHour => millimetresPerHour / 3600000, metresPerSecond => 3600000 * metresPerSecond, "mm/h");


        /// <summary>
        /// The CentimetresPerHour unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit CentimetresPerHour = new SpeedUnit(centimetresPerHour => centimetresPerHour / 360000, metresPerSecond => 360000 * metresPerSecond, "cm/h");


        /// <summary>
        /// The MillimetresPerMinute unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MillimetresPerMinute = new SpeedUnit(millimetresPerMinute => millimetresPerMinute / 60000, metresPerSecond => 60000 * metresPerSecond, "mm/min");


        /// <summary>
        /// The MillimetresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit MillimetresPerSecond = new SpeedUnit(millimetresPerSecond => millimetresPerSecond / 1000, metresPerSecond => 1000 * metresPerSecond, "mm/s");


        /// <summary>
        /// The CentimetresPerSecond unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly SpeedUnit CentimetresPerSecond = new SpeedUnit(centimetresPerSecond => centimetresPerSecond / 100, metresPerSecond => 100 * metresPerSecond, "cm/s");


        private readonly Func<double, double> toMetresPerSecond;
        private readonly Func<double, double> fromMetresPerSecond;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="SpeedUnit"/>.
        /// </summary>
        /// <param name="toMetresPerSecond">The conversion to <see cref="MetresPerSecond"/></param>
        /// <param name="fromMetresPerSecond">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="MetresPerSecond"/></param>
        public SpeedUnit(Func<double, double> toMetresPerSecond, Func<double, double> fromMetresPerSecond, string symbol)
        {
            this.toMetresPerSecond = toMetresPerSecond;
            this.fromMetresPerSecond = fromMetresPerSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.SpeedUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.SpeedUnit"/>
        /// </summary>
        public SpeedUnit SiUnit => MetresPerSecond;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.SpeedUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => MetresPerSecond;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the multiplication.</returns>
        public static Speed operator *(double left, SpeedUnit right)
        {
            return Speed.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpeedUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpeedUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpeedUnit"/>.</param>
	    public static bool operator ==(SpeedUnit left, SpeedUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SpeedUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SpeedUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SpeedUnit"/>.</param>
        public static bool operator !=(SpeedUnit left, SpeedUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="SpeedUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="SpeedUnit"/></returns>
        public static SpeedUnit Parse(string text)
        {
            return UnitParser<SpeedUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SpeedUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SpeedUnit"/></param>
        /// <param name="result">The parsed <see cref="SpeedUnit"/></param>
        /// <returns>True if an instance of <see cref="SpeedUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out SpeedUnit result)
        {
            return UnitParser<SpeedUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerSecond.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerSecond(value);
        }

        /// <summary>
        /// Converts a value from metresPerSecond.
        /// </summary>
        /// <param name="metresPerSecond">The value in MetresPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerSecond)
        {
            return this.fromMetresPerSecond(metresPerSecond);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Speed(<paramref name="value"/>, this)</returns>
        public Speed CreateQuantity(double value)
        {
            return new Speed(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerSecond
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Speed quantity)
        {
            return FromSiUnit(quantity.metresPerSecond);
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
            SpeedUnit unit;
            var paddedFormat = UnitFormatCache<SpeedUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<SpeedUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SpeedUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.SpeedUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SpeedUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(SpeedUnit other)
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

            return obj is SpeedUnit && Equals((SpeedUnit)obj);
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