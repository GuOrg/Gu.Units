﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AmountOfSubstance"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(AmountOfSubstanceUnitTypeConverter))]
    public struct AmountOfSubstanceUnit : IUnit, IUnit<AmountOfSubstance>, IEquatable<AmountOfSubstanceUnit>
    {
        /// <summary>
        /// The Moles unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly AmountOfSubstanceUnit Moles = new AmountOfSubstanceUnit(moles => moles, moles => moles, "mol");


        private readonly Func<double, double> toMoles;
        private readonly Func<double, double> fromMoles;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="AmountOfSubstanceUnit"/>.
        /// </summary>
        /// <param name="toMoles">The conversion to <see cref="Moles"/></param>
        /// <param name="fromMoles">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Moles"/></param>
        public AmountOfSubstanceUnit(Func<double, double> toMoles, Func<double, double> fromMoles, string symbol)
        {
            this.toMoles = toMoles;
            this.fromMoles = fromMoles;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AmountOfSubstanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AmountOfSubstanceUnit"/>
        /// </summary>
        public AmountOfSubstanceUnit SiUnit => Moles;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AmountOfSubstanceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Moles;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AmountOfSubstance"/> that is the result from the multiplication.</returns>
        public static AmountOfSubstance operator *(double left, AmountOfSubstanceUnit right)
        {
            return AmountOfSubstance.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AmountOfSubstanceUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstanceUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstanceUnit"/>.</param>
	    public static bool operator ==(AmountOfSubstanceUnit left, AmountOfSubstanceUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.AmountOfSubstanceUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.AmountOfSubstanceUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.AmountOfSubstanceUnit"/>.</param>
        public static bool operator !=(AmountOfSubstanceUnit left, AmountOfSubstanceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="AmountOfSubstanceUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="AmountOfSubstanceUnit"/></returns>
        public static AmountOfSubstanceUnit Parse(string text)
        {
            return UnitParser<AmountOfSubstanceUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.AmountOfSubstanceUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.AmountOfSubstanceUnit"/></param>
        /// <param name="result">The parsed <see cref="AmountOfSubstanceUnit"/></param>
        /// <returns>True if an instance of <see cref="AmountOfSubstanceUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out AmountOfSubstanceUnit result)
        {
            return UnitParser<AmountOfSubstanceUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Moles.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toMoles(value);
        }

        /// <summary>
        /// Converts a value from moles.
        /// </summary>
        /// <param name="moles">The value in Moles</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double moles)
        {
            return this.fromMoles(moles);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new AmountOfSubstance(<paramref name="value"/>, this)</returns>
        public AmountOfSubstance CreateQuantity(double value)
        {
            return new AmountOfSubstance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Moles
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AmountOfSubstance quantity)
        {
            return FromSiUnit(quantity.moles);
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
            AmountOfSubstanceUnit unit;
            var paddedFormat = UnitFormatCache<AmountOfSubstanceUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<AmountOfSubstanceUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.AmountOfSubstanceUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.AmountOfSubstanceUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same AmountOfSubstanceUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(AmountOfSubstanceUnit other)
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

            return obj is AmountOfSubstanceUnit && Equals((AmountOfSubstanceUnit)obj);
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