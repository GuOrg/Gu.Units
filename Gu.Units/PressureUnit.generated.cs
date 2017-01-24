﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Pressure"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(PressureUnitTypeConverter))]
    public struct PressureUnit : IUnit, IUnit<Pressure>, IEquatable<PressureUnit>
    {
        /// <summary>
        /// The Pascals unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly PressureUnit Pascals = new PressureUnit(pascals => pascals, pascals => pascals, "Pa");


        /// <summary>
        /// The Bars unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Bars = new PressureUnit(bars => 100000 * bars, pascals => pascals / 100000, "bar");


        /// <summary>
        /// The Millibars unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Millibars = new PressureUnit(millibars => 100 * millibars, pascals => pascals / 100, "mbar");


        /// <summary>
        /// The Nanopascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Nanopascals = new PressureUnit(nanopascals => nanopascals / 1000000000, pascals => 1000000000 * pascals, "nPa");


        /// <summary>
        /// The Micropascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Micropascals = new PressureUnit(micropascals => micropascals / 1000000, pascals => 1000000 * pascals, "µPa");


        /// <summary>
        /// The Millipascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Millipascals = new PressureUnit(millipascals => millipascals / 1000, pascals => 1000 * pascals, "mPa");


        /// <summary>
        /// The Kilopascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Kilopascals = new PressureUnit(kilopascals => 1000 * kilopascals, pascals => pascals / 1000, "kPa");


        /// <summary>
        /// The Megapascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Megapascals = new PressureUnit(megapascals => 1000000 * megapascals, pascals => pascals / 1000000, "MPa");


        /// <summary>
        /// The Gigapascals unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit Gigapascals = new PressureUnit(gigapascals => 1000000000 * gigapascals, pascals => pascals / 1000000000, "GPa");


        /// <summary>
        /// The NewtonsPerSquareMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit NewtonsPerSquareMillimetre = new PressureUnit(newtonsPerSquareMillimetre => 1000000 * newtonsPerSquareMillimetre, pascals => pascals / 1000000, "N⋅mm⁻²");


        /// <summary>
        /// The KilonewtonsPerSquareMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit KilonewtonsPerSquareMillimetre = new PressureUnit(kilonewtonsPerSquareMillimetre => 1000000000 * kilonewtonsPerSquareMillimetre, pascals => pascals / 1000000000, "kN⋅mm⁻²");


        /// <summary>
        /// The NewtonsPerSquareMetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly PressureUnit NewtonsPerSquareMetre = new PressureUnit(newtonsPerSquareMetre => newtonsPerSquareMetre, pascals => pascals, "N/m²");


        private readonly Func<double, double> toPascals;
        private readonly Func<double, double> fromPascals;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="PressureUnit"/>.
        /// </summary>
        /// <param name="toPascals">The conversion to <see cref="Pascals"/></param>
        /// <param name="fromPascals">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Pascals"/></param>
        public PressureUnit(Func<double, double> toPascals, Func<double, double> fromPascals, string symbol)
        {
            this.toPascals = toPascals;
            this.fromPascals = fromPascals;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.PressureUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.PressureUnit"/>
        /// </summary>
        public PressureUnit SiUnit => Pascals;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.PressureUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Pascals;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Pressure"/> that is the result from the multiplication.</returns>
        public static Pressure operator *(double left, PressureUnit right)
        {
            return Pressure.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.PressureUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.PressureUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.PressureUnit"/>.</param>
	    public static bool operator ==(PressureUnit left, PressureUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.PressureUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.PressureUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.PressureUnit"/>.</param>
        public static bool operator !=(PressureUnit left, PressureUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="PressureUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="PressureUnit"/></returns>
        public static PressureUnit Parse(string text)
        {
            return UnitParser<PressureUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.PressureUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.PressureUnit"/></param>
        /// <param name="result">The parsed <see cref="PressureUnit"/></param>
        /// <returns>True if an instance of <see cref="PressureUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out PressureUnit result)
        {
            return UnitParser<PressureUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Pascals.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toPascals(value);
        }

        /// <summary>
        /// Converts a value from pascals.
        /// </summary>
        /// <param name="pascals">The value in Pascals</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double pascals)
        {
            return this.fromPascals(pascals);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Pressure(<paramref name="value"/>, this)</returns>
        public Pressure CreateQuantity(double value)
        {
            return new Pressure(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Pascals
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Pressure quantity)
        {
            return FromSiUnit(quantity.pascals);
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
            PressureUnit unit;
            var paddedFormat = UnitFormatCache<PressureUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<PressureUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.PressureUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.PressureUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same PressureUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(PressureUnit other)
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

            return obj is PressureUnit && Equals((PressureUnit)obj);
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