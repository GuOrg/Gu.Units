





namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.MagneticFlux"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MagneticFluxUnitTypeConverter))]
    public struct MagneticFluxUnit : IUnit, IUnit<MagneticFlux>, IEquatable<MagneticFluxUnit>
    {
        /// <summary>
        /// The Webers unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MagneticFluxUnit Webers = new MagneticFluxUnit(webers => webers, webers => webers, "Wb");


        private readonly Func<double, double> toWebers;
        private readonly Func<double, double> fromWebers;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="MagneticFluxUnit"/>.
        /// </summary>
        /// <param name="toWebers">The conversion to <see cref="Webers"/></param>
        /// <param name="fromWebers">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Webers"/></param>
        public MagneticFluxUnit(Func<double, double> toWebers, Func<double, double> fromWebers, string symbol)
        {
            this.toWebers = toWebers;
            this.fromWebers = fromWebers;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.MagneticFluxUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.MagneticFluxUnit"/>
        /// </summary>
        public MagneticFluxUnit SiUnit => Webers;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.MagneticFluxUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Webers;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFlux"/> that is the result from the multiplication.</returns>
        public static MagneticFlux operator *(double left, MagneticFluxUnit right)
        {
            return MagneticFlux.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MagneticFluxUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFluxUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFluxUnit"/>.</param>
	    public static bool operator ==(MagneticFluxUnit left, MagneticFluxUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MagneticFluxUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MagneticFluxUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MagneticFluxUnit"/>.</param>
        public static bool operator !=(MagneticFluxUnit left, MagneticFluxUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MagneticFluxUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="MagneticFluxUnit"/></returns>
        public static MagneticFluxUnit Parse(string text)
        {
            return UnitParser<MagneticFluxUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFluxUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFluxUnit"/></param>
        /// <param name="result">The parsed <see cref="MagneticFluxUnit"/></param>
        /// <returns>True if an instance of <see cref="MagneticFluxUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out MagneticFluxUnit result)
        {
            return UnitParser<MagneticFluxUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Webers.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toWebers(value);
        }

        /// <summary>
        /// Converts a value from webers.
        /// </summary>
        /// <param name="webers">The value in Webers</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double webers)
        {
            return this.fromWebers(webers);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new MagneticFlux(<paramref name="value"/>, this)</returns>
        public MagneticFlux CreateQuantity(double value)
        {
            return new MagneticFlux(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Webers
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(MagneticFlux quantity)
        {
            return FromSiUnit(quantity.webers);
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
            MagneticFluxUnit unit;
            var paddedFormat = UnitFormatCache<MagneticFluxUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<MagneticFluxUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MagneticFluxUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.MagneticFluxUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MagneticFluxUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(MagneticFluxUnit other)
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

            return obj is MagneticFluxUnit && Equals((MagneticFluxUnit)obj);
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