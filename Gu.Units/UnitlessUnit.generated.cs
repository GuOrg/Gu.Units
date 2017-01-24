﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Unitless"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(UnitlessUnitTypeConverter))]
    public struct UnitlessUnit : IUnit, IUnit<Unitless>, IEquatable<UnitlessUnit>
    {
        /// <summary>
        /// The Scalar unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly UnitlessUnit Scalar = new UnitlessUnit(scalar => scalar, scalar => scalar, "ul");


        /// <summary>
        /// The Promilles unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit Promilles = new UnitlessUnit(promilles => promilles / 1000, scalar => 1000 * scalar, "‰");


        /// <summary>
        /// The PartsPerMillion unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit PartsPerMillion = new UnitlessUnit(partsPerMillion => partsPerMillion / 1000000, scalar => 1000000 * scalar, "ppm");


        /// <summary>
        /// The Percents unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly UnitlessUnit Percents = new UnitlessUnit(percents => percents / 100, scalar => 100 * scalar, "%");


        private readonly Func<double, double> toScalar;
        private readonly Func<double, double> fromScalar;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="UnitlessUnit"/>.
        /// </summary>
        /// <param name="toScalar">The conversion to <see cref="Scalar"/></param>
        /// <param name="fromScalar">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Scalar"/></param>
        public UnitlessUnit(Func<double, double> toScalar, Func<double, double> fromScalar, string symbol)
        {
            this.toScalar = toScalar;
            this.fromScalar = fromScalar;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.UnitlessUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.UnitlessUnit"/>
        /// </summary>
        public UnitlessUnit SiUnit => Scalar;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.UnitlessUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Scalar;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Unitless"/> that is the result from the multiplication.</returns>
        public static Unitless operator *(double left, UnitlessUnit right)
        {
            return Unitless.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.UnitlessUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.UnitlessUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.UnitlessUnit"/>.</param>
	    public static bool operator ==(UnitlessUnit left, UnitlessUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.UnitlessUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.UnitlessUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.UnitlessUnit"/>.</param>
        public static bool operator !=(UnitlessUnit left, UnitlessUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="UnitlessUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="UnitlessUnit"/></returns>
        public static UnitlessUnit Parse(string text)
        {
            return UnitParser<UnitlessUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.UnitlessUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.UnitlessUnit"/></param>
        /// <param name="result">The parsed <see cref="UnitlessUnit"/></param>
        /// <returns>True if an instance of <see cref="UnitlessUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out UnitlessUnit result)
        {
            return UnitParser<UnitlessUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Scalar.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toScalar(value);
        }

        /// <summary>
        /// Converts a value from scalar.
        /// </summary>
        /// <param name="scalar">The value in Scalar</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double scalar)
        {
            return this.fromScalar(scalar);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Unitless(<paramref name="value"/>, this)</returns>
        public Unitless CreateQuantity(double value)
        {
            return new Unitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Scalar
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Unitless quantity)
        {
            return FromSiUnit(quantity.scalar);
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
            UnitlessUnit unit;
            var paddedFormat = UnitFormatCache<UnitlessUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<UnitlessUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.UnitlessUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.UnitlessUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same UnitlessUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(UnitlessUnit other)
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

            return obj is UnitlessUnit && Equals((UnitlessUnit)obj);
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