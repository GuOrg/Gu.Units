namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Inductance"/>.
    /// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(InductanceUnitTypeConverter))]
    public struct InductanceUnit : IUnit, IUnit<Inductance>, IEquatable<InductanceUnit>
    {
        /// <summary>
        /// The Henrys unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly InductanceUnit Henrys = new InductanceUnit(henrys => henrys, henrys => henrys, "H");

        /// <summary>
        /// The Nanohenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Nanohenrys = new InductanceUnit(nanohenrys => nanohenrys / 1000000000, henrys => 1000000000 * henrys, "nH");

        /// <summary>
        /// The Microhenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Microhenrys = new InductanceUnit(microhenrys => microhenrys / 1000000, henrys => 1000000 * henrys, "μH");

        /// <summary>
        /// The Millihenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Millihenrys = new InductanceUnit(millihenrys => millihenrys / 1000, henrys => 1000 * henrys, "mH");

        /// <summary>
        /// The Kilohenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Kilohenrys = new InductanceUnit(kilohenrys => 1000 * kilohenrys, henrys => henrys / 1000, "kH");

        /// <summary>
        /// The Megahenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Megahenrys = new InductanceUnit(megahenrys => 1000000 * megahenrys, henrys => henrys / 1000000, "MH");

        /// <summary>
        /// The Gigahenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Gigahenrys = new InductanceUnit(gigahenrys => 1000000000 * gigahenrys, henrys => henrys / 1000000000, "GH");

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.InductanceUnit"/>.
        /// </summary>
        internal readonly string symbol;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        private readonly Func<double, double> toHenrys;
        private readonly Func<double, double> fromHenrys;

        /// <summary>
        /// Initializes a new instance of the <see cref="InductanceUnit"/> struct.
        /// </summary>
        /// <param name="toHenrys">The conversion to <see cref="Henrys"/></param>
        /// <param name="fromHenrys">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="Henrys"/></param>
        public InductanceUnit(Func<double, double> toHenrys, Func<double, double> fromHenrys, string symbol)
        {
            this.toHenrys = toHenrys;
            this.fromHenrys = fromHenrys;
            this.symbol = symbol;
        }

        /// <summary>
        /// Gets the symbol for the <see cref="Gu.Units.InductanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// Gets the default unit for <see cref="Gu.Units.InductanceUnit"/>
        /// </summary>
        public InductanceUnit SiUnit => Henrys;

        /// <inheritdoc />
        IUnit IUnit.SiUnit => Henrys;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Inductance"/> that is the result from the multiplication.</returns>
        public static Inductance operator *(double left, InductanceUnit right)
        {
            return Inductance.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.InductanceUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.InductanceUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.InductanceUnit"/>.</param>
        public static bool operator ==(InductanceUnit left, InductanceUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.InductanceUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.InductanceUnit"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.InductanceUnit"/>.</param>
        public static bool operator !=(InductanceUnit left, InductanceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="InductanceUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text">The text representation of this unit.</param>
        /// <returns>An instance of <see cref="InductanceUnit"/></returns>
        public static InductanceUnit Parse(string text)
        {
            return UnitParser<InductanceUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.InductanceUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.InductanceUnit"/></param>
        /// <param name="result">The parsed <see cref="InductanceUnit"/></param>
        /// <returns>True if an instance of <see cref="InductanceUnit"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out InductanceUnit result)
        {
            return UnitParser<InductanceUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Henrys.
        /// </summary>
        /// <param name="value">The value in the unit of this instance.</param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toHenrys(value);
        }

        /// <summary>
        /// Converts a value from henrys.
        /// </summary>
        /// <param name="henrys">The value in Henrys</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double henrys)
        {
            return this.fromHenrys(henrys);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Inductance(<paramref name="value"/>, this)</returns>
        public Inductance CreateQuantity(double value)
        {
            return new Inductance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Henrys
        /// </summary>
        /// <param name="quantity">The quanity.</param>
        /// <returns>The SI-unit value.</returns>
        public double GetScalarValue(Inductance quantity)
        {
            return this.FromSiUnit(quantity.henrys);
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
            InductanceUnit unit;
            var paddedFormat = UnitFormatCache<InductanceUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<InductanceUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.InductanceUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.InductanceUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same InductanceUnit as this instance; otherwise, false.
        /// </returns>
        public bool Equals(InductanceUnit other)
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

            return obj is InductanceUnit && this.Equals((InductanceUnit)obj);
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
