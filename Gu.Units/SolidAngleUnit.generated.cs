﻿





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.SolidAngle"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(SolidAngleUnitTypeConverter))]
    public struct SolidAngleUnit : IUnit, IUnit<SolidAngle>, IEquatable<SolidAngleUnit>
    {
        /// <summary>
        /// The Steradians unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly SolidAngleUnit Steradians = new SolidAngleUnit(steradians => steradians, steradians => steradians, "sr");


        private readonly Func<double, double> toSteradians;
        private readonly Func<double, double> fromSteradians;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="SolidAngleUnit"/>.
        /// </summary>
        /// <param name="toSteradians">The conversion to <see cref="Steradians"/></param>
        /// <param name="fromSteradians">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Steradians"/></param>
        public SolidAngleUnit(Func<double, double> toSteradians, Func<double, double> fromSteradians, string symbol)
        {
            this.toSteradians = toSteradians;
            this.fromSteradians = fromSteradians;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.SolidAngleUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.SolidAngleUnit"/>
        /// </summary>
        public SolidAngleUnit SiUnit => Steradians;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.SolidAngleUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Steradians;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SolidAngle"/> that is the result from the multiplication.</returns>
        public static SolidAngle operator *(double left, SolidAngleUnit right)
        {
            return SolidAngle.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SolidAngleUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SolidAngleUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SolidAngleUnit"/>.</param>
	    public static bool operator ==(SolidAngleUnit left, SolidAngleUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.SolidAngleUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.SolidAngleUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.SolidAngleUnit"/>.</param>
        public static bool operator !=(SolidAngleUnit left, SolidAngleUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="SolidAngleUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="SolidAngleUnit"/></returns>
        public static SolidAngleUnit Parse(string text)
        {
            return UnitParser<SolidAngleUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.SolidAngleUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.SolidAngleUnit"/></param>
        /// <param name="result">The parsed <see cref="SolidAngleUnit"/></param>
        /// <returns>True if an instance of <see cref="SolidAngleUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out SolidAngleUnit result)
        {
            return UnitParser<SolidAngleUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Steradians.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toSteradians(value);
        }

        /// <summary>
        /// Converts a value from steradians.
        /// </summary>
        /// <param name="steradians">The value in Steradians</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double steradians)
        {
            return this.fromSteradians(steradians);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new SolidAngle(<paramref name="value"/>, this)</returns>
        public SolidAngle CreateQuantity(double value)
        {
            return new SolidAngle(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Steradians
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(SolidAngle quantity)
        {
            return FromSiUnit(quantity.steradians);
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
            SolidAngleUnit unit;
            var paddedFormat = UnitFormatCache<SolidAngleUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<SolidAngleUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.SolidAngleUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.SolidAngleUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same SolidAngleUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(SolidAngleUnit other)
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

            return obj is SolidAngleUnit && Equals((SolidAngleUnit)obj);
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