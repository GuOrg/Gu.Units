namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.CatalyticActivity"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(CatalyticActivityUnitTypeConverter))]
    public struct CatalyticActivityUnit : IUnit, IUnit<CatalyticActivity>, IEquatable<CatalyticActivityUnit>
    {
        /// <summary>
        /// The Katals unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly CatalyticActivityUnit Katals = new CatalyticActivityUnit(katals => katals, katals => katals, "kat");

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.CatalyticActivityUnit"/>.
        /// </summary>
        internal readonly string symbol;

        private readonly Func<double, double> toKatals;
        private readonly Func<double, double> fromKatals;

        /// <summary>
        /// Initializes a new instance of the <see cref="CatalyticActivityUnit"/> struct.
        /// </summary>
        /// <param name="toKatals">The conversion to <see cref="Katals"/></param>
        /// <param name="fromKatals">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Katals"/></param>
        public CatalyticActivityUnit(Func<double, double> toKatals, Func<double, double> fromKatals, string symbol)
        {
            this.toKatals = toKatals;
            this.fromKatals = fromKatals;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.CatalyticActivityUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.CatalyticActivityUnit"/>
        /// </summary>
        public CatalyticActivityUnit SiUnit => Katals;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Katals;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="CatalyticActivity"/> that is the result from the multiplication.</returns>
        public static CatalyticActivity operator *(double left, CatalyticActivityUnit right)
        {
            return CatalyticActivity.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.CatalyticActivityUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.CatalyticActivityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.CatalyticActivityUnit"/>.</param>
        public static bool operator ==(CatalyticActivityUnit left, CatalyticActivityUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.CatalyticActivityUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.CatalyticActivityUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.CatalyticActivityUnit"/>.</param>
        public static bool operator !=(CatalyticActivityUnit left, CatalyticActivityUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="CatalyticActivityUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="CatalyticActivityUnit"/></returns>
        public static CatalyticActivityUnit Parse(string text)
        {
            return UnitParser<CatalyticActivityUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.CatalyticActivityUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.CatalyticActivityUnit"/></param>
        /// <param name="result">The parsed <see cref="CatalyticActivityUnit"/></param>
        /// <returns>True if an instance of <see cref="CatalyticActivityUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out CatalyticActivityUnit result)
        {
            return UnitParser<CatalyticActivityUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Katals.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toKatals(value);
        }

        /// <summary>
        /// Converts a value from katals.
        /// </summary>
        /// <param name="katals">The value in Katals</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double katals)
        {
            return this.fromKatals(katals);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new CatalyticActivity(<paramref name="value"/>, this)</returns>
        public CatalyticActivity CreateQuantity(double value)
        {
            return new CatalyticActivity(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Katals
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(CatalyticActivity quantity)
        {
            return this.FromSiUnit(quantity.katals);
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
            CatalyticActivityUnit unit;
            var paddedFormat = UnitFormatCache<CatalyticActivityUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<CatalyticActivityUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.CatalyticActivityUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.CatalyticActivityUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same CatalyticActivityUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(CatalyticActivityUnit other)
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

            return obj is CatalyticActivityUnit && this.Equals((CatalyticActivityUnit)obj);
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