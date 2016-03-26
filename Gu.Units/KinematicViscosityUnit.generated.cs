namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.KinematicViscosity"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(KinematicViscosityUnitTypeConverter))]
    public struct KinematicViscosityUnit : IUnit, IUnit<KinematicViscosity>, IEquatable<KinematicViscosityUnit>
    {
        /// <summary>
        /// The KinematicViscosityUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly KinematicViscosityUnit SquareMetresPerSecond = new KinematicViscosityUnit(squareMetresPerSecond => squareMetresPerSecond, squareMetresPerSecond => squareMetresPerSecond, "m²/s");

        private readonly Func<double, double> toSquareMetresPerSecond;
        private readonly Func<double, double> fromSquareMetresPerSecond;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="KinematicViscosityUnit"/>.
        /// </summary>
        /// <param name="toSquareMetresPerSecond">The conversion to <see cref="SquareMetresPerSecond"/></param>
        /// <param name="fromSquareMetresPerSecond">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="SquareMetresPerSecond"/></param>
        public KinematicViscosityUnit(Func<double, double> toSquareMetresPerSecond, Func<double, double> fromSquareMetresPerSecond, string symbol)
        {
            this.toSquareMetresPerSecond = toSquareMetresPerSecond;
            this.fromSquareMetresPerSecond = fromSquareMetresPerSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.KinematicViscosityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.KinematicViscosityUnit"/>
        /// </summary>
        public KinematicViscosityUnit SiUnit => SquareMetresPerSecond;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.KinematicViscosityUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => SquareMetresPerSecond;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the multiplication.</returns>
        public static KinematicViscosity operator *(double left, KinematicViscosityUnit right)
        {
            return KinematicViscosity.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.KinematicViscosityUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.KinematicViscosityUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.KinematicViscosityUnit"/>.</param>
	    public static bool operator ==(KinematicViscosityUnit left, KinematicViscosityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.KinematicViscosityUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.KinematicViscosityUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.KinematicViscosityUnit"/>.</param>
        public static bool operator !=(KinematicViscosityUnit left, KinematicViscosityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="KinematicViscosityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="KinematicViscosityUnit"/></returns>
        public static KinematicViscosityUnit Parse(string text)
        {
            return UnitParser<KinematicViscosityUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.KinematicViscosityUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.KinematicViscosityUnit"/></param>
        /// <param name="result">The parsed <see cref="KinematicViscosityUnit"/></param>
        /// <returns>True if an instance of <see cref="KinematicViscosityUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out KinematicViscosityUnit result)
        {
            return UnitParser<KinematicViscosityUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to SquareMetresPerSecond.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toSquareMetresPerSecond(value);
        }

        /// <summary>
        /// Converts a value from squareMetresPerSecond.
        /// </summary>
        /// <param name="squareMetresPerSecond">The value in SquareMetresPerSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double squareMetresPerSecond)
        {
            return this.fromSquareMetresPerSecond(squareMetresPerSecond);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new KinematicViscosity(<paramref name="value"/>, this)</returns>
        public KinematicViscosity CreateQuantity(double value)
        {
            return new KinematicViscosity(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in SquareMetresPerSecond
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(KinematicViscosity quantity)
        {
            return FromSiUnit(quantity.squareMetresPerSecond);
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
            KinematicViscosityUnit unit;
            var paddedFormat = UnitFormatCache<KinematicViscosityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<KinematicViscosityUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.KinematicViscosityUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.KinematicViscosityUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same KinematicViscosityUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(KinematicViscosityUnit other)
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

            return obj is KinematicViscosityUnit && Equals((KinematicViscosityUnit)obj);
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