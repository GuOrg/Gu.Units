﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.MolarMass"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MolarMassUnitTypeConverter))]
    public struct MolarMassUnit : IUnit, IUnit<MolarMass>, IEquatable<MolarMassUnit>
    {
        /// <summary>
        /// The KilogramsPerMole unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MolarMassUnit KilogramsPerMole = new MolarMassUnit(kilogramsPerMole => kilogramsPerMole, kilogramsPerMole => kilogramsPerMole, "kg/mol");


        /// <summary>
        /// The GramsPerMole unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly MolarMassUnit GramsPerMole = new MolarMassUnit(gramsPerMole => gramsPerMole / 1000, kilogramsPerMole => 1000 * kilogramsPerMole, "g/mol");


        private readonly Func<double, double> toKilogramsPerMole;
        private readonly Func<double, double> fromKilogramsPerMole;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="MolarMassUnit"/>.
        /// </summary>
        /// <param name="toKilogramsPerMole">The conversion to <see cref="KilogramsPerMole"/></param>
        /// <param name="fromKilogramsPerMole">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="KilogramsPerMole"/></param>
        public MolarMassUnit(Func<double, double> toKilogramsPerMole, Func<double, double> fromKilogramsPerMole, string symbol)
        {
            this.toKilogramsPerMole = toKilogramsPerMole;
            this.fromKilogramsPerMole = fromKilogramsPerMole;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.MolarMassUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.MolarMassUnit"/>
        /// </summary>
        public MolarMassUnit SiUnit => KilogramsPerMole;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.MolarMassUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => KilogramsPerMole;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MolarMass"/> that is the result from the multiplication.</returns>
        public static MolarMass operator *(double left, MolarMassUnit right)
        {
            return MolarMass.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MolarMassUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarMassUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarMassUnit"/>.</param>
	    public static bool operator ==(MolarMassUnit left, MolarMassUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MolarMassUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MolarMassUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MolarMassUnit"/>.</param>
        public static bool operator !=(MolarMassUnit left, MolarMassUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MolarMassUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="MolarMassUnit"/></returns>
        public static MolarMassUnit Parse(string text)
        {
            return UnitParser<MolarMassUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MolarMassUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MolarMassUnit"/></param>
        /// <param name="result">The parsed <see cref="MolarMassUnit"/></param>
        /// <returns>True if an instance of <see cref="MolarMassUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out MolarMassUnit result)
        {
            return UnitParser<MolarMassUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to KilogramsPerMole.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKilogramsPerMole(value);
        }

        /// <summary>
        /// Converts a value from kilogramsPerMole.
        /// </summary>
        /// <param name="kilogramsPerMole">The value in KilogramsPerMole</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double kilogramsPerMole)
        {
            return this.fromKilogramsPerMole(kilogramsPerMole);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new MolarMass(<paramref name="value"/>, this)</returns>
        public MolarMass CreateQuantity(double value)
        {
            return new MolarMass(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in KilogramsPerMole
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(MolarMass quantity)
        {
            return FromSiUnit(quantity.kilogramsPerMole);
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
            MolarMassUnit unit;
            var paddedFormat = UnitFormatCache<MolarMassUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<MolarMassUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MolarMassUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.MolarMassUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MolarMassUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(MolarMassUnit other)
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

            return obj is MolarMassUnit && Equals((MolarMassUnit)obj);
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