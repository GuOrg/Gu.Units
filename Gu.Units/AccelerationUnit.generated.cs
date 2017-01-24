﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Acceleration"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(AccelerationUnitTypeConverter))]
    public struct AccelerationUnit : IUnit, IUnit<Acceleration>, IEquatable<AccelerationUnit>
    {
        /// <summary>
        /// The MetresPerSecondSquared unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AccelerationUnit MetresPerSecondSquared = new AccelerationUnit(metresPerSecondSquared => metresPerSecondSquared, metresPerSecondSquared => metresPerSecondSquared, "m/s²");


        /// <summary>
        /// The CentimetresPerSecondSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit CentimetresPerSecondSquared = new AccelerationUnit(centimetresPerSecondSquared => centimetresPerSecondSquared / 100, metresPerSecondSquared => 100 * metresPerSecondSquared, "cm/s²");


        /// <summary>
        /// The MillimetresPerSecondSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MillimetresPerSecondSquared = new AccelerationUnit(millimetresPerSecondSquared => millimetresPerSecondSquared / 1000, metresPerSecondSquared => 1000 * metresPerSecondSquared, "mm/s²");


        /// <summary>
        /// The MillimetresPerHourSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MillimetresPerHourSquared = new AccelerationUnit(millimetresPerHourSquared => millimetresPerHourSquared / 12960000000, metresPerSecondSquared => 12960000000 * metresPerSecondSquared, "mm/h²");


        /// <summary>
        /// The CentimetresPerHourSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit CentimetresPerHourSquared = new AccelerationUnit(centimetresPerHourSquared => centimetresPerHourSquared / 1296000000, metresPerSecondSquared => 1296000000 * metresPerSecondSquared, "cm/h²");


        /// <summary>
        /// The MetresPerHourSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MetresPerHourSquared = new AccelerationUnit(metresPerHourSquared => metresPerHourSquared / 12960000, metresPerSecondSquared => 12960000 * metresPerSecondSquared, "m/h²");


        /// <summary>
        /// The MetresPerMinuteSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MetresPerMinuteSquared = new AccelerationUnit(metresPerMinuteSquared => metresPerMinuteSquared / 3600, metresPerSecondSquared => 3600 * metresPerSecondSquared, "m/min²");


        /// <summary>
        /// The MillimetresPerMinuteSquared unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AccelerationUnit MillimetresPerMinuteSquared = new AccelerationUnit(millimetresPerMinuteSquared => millimetresPerMinuteSquared / 3600000, metresPerSecondSquared => 3600000 * metresPerSecondSquared, "mm/min²");


        private readonly Func<double, double> toMetresPerSecondSquared;
        private readonly Func<double, double> fromMetresPerSecondSquared;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="AccelerationUnit"/>.
        /// </summary>
        /// <param name="toMetresPerSecondSquared">The conversion to <see cref="MetresPerSecondSquared"/></param>
        /// <param name="fromMetresPerSecondSquared">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="MetresPerSecondSquared"/></param>
        public AccelerationUnit(Func<double, double> toMetresPerSecondSquared, Func<double, double> fromMetresPerSecondSquared, string symbol)
        {
            this.toMetresPerSecondSquared = toMetresPerSecondSquared;
            this.fromMetresPerSecondSquared = fromMetresPerSecondSquared;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AccelerationUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AccelerationUnit"/>
        /// </summary>
        public AccelerationUnit SiUnit => MetresPerSecondSquared;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AccelerationUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => MetresPerSecondSquared;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Acceleration"/> that is the result from the multiplication.</returns>
        public static Acceleration operator *(double left, AccelerationUnit right)
        {
            return Acceleration.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AccelerationUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AccelerationUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AccelerationUnit"/>.</param>
	    public static bool operator ==(AccelerationUnit left, AccelerationUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AccelerationUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AccelerationUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AccelerationUnit"/>.</param>
        public static bool operator !=(AccelerationUnit left, AccelerationUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AccelerationUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="AccelerationUnit"/></returns>
        public static AccelerationUnit Parse(string text)
        {
            return UnitParser<AccelerationUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AccelerationUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AccelerationUnit"/></param>
        /// <param name="result">The parsed <see cref="AccelerationUnit"/></param>
        /// <returns>True if an instance of <see cref="AccelerationUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out AccelerationUnit result)
        {
            return UnitParser<AccelerationUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to MetresPerSecondSquared.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMetresPerSecondSquared(value);
        }

        /// <summary>
        /// Converts a value from metresPerSecondSquared.
        /// </summary>
        /// <param name="metresPerSecondSquared">The value in MetresPerSecondSquared</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double metresPerSecondSquared)
        {
            return this.fromMetresPerSecondSquared(metresPerSecondSquared);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Acceleration(<paramref name="value"/>, this)</returns>
        public Acceleration CreateQuantity(double value)
        {
            return new Acceleration(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MetresPerSecondSquared
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Acceleration quantity)
        {
            return FromSiUnit(quantity.metresPerSecondSquared);
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
            AccelerationUnit unit;
            var paddedFormat = UnitFormatCache<AccelerationUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<AccelerationUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AccelerationUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.AccelerationUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AccelerationUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(AccelerationUnit other)
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

            return obj is AccelerationUnit && Equals((AccelerationUnit)obj);
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