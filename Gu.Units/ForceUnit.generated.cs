namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Force"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(ForceUnitTypeConverter))]
    public struct ForceUnit : IUnit, IUnit<Force>, IEquatable<ForceUnit>
    {
        /// <summary>
        /// The ForceUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly ForceUnit Newtons = new ForceUnit(newtons => newtons, newtons => newtons, "N");

        /// <summary>
        /// The Nanonewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Nanonewtons = new ForceUnit(nanonewtons => nanonewtons / 1000000000, newtons => 1000000000 * newtons, "nN");

        /// <summary>
        /// The Micronewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Micronewtons = new ForceUnit(micronewtons => micronewtons / 1000000, newtons => 1000000 * newtons, "µN");

        /// <summary>
        /// The Millinewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Millinewtons = new ForceUnit(millinewtons => millinewtons / 1000, newtons => 1000 * newtons, "mN");

        /// <summary>
        /// The Kilonewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Kilonewtons = new ForceUnit(kilonewtons => 1000 * kilonewtons, newtons => newtons / 1000, "kN");

        /// <summary>
        /// The Meganewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Meganewtons = new ForceUnit(meganewtons => 1000000 * meganewtons, newtons => newtons / 1000000, "MN");

        /// <summary>
        /// The Giganewtons unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForceUnit Giganewtons = new ForceUnit(giganewtons => 1000000000 * giganewtons, newtons => newtons / 1000000000, "GN");

        private readonly Func<double, double> toNewtons;
        private readonly Func<double, double> fromNewtons;
        internal readonly string symbol;

        public ForceUnit(Func<double, double> toNewtons, Func<double, double> fromNewtons, string symbol)
        {
            this.toNewtons = toNewtons;
            this.fromNewtons = fromNewtons;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.ForceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.ForceUnit"/>
        /// </summary>
        public ForceUnit SiUnit => Newtons;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.ForceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Newtons;

        public static Force operator *(double left, ForceUnit right)
        {
            return Force.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ForceUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForceUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForceUnit"/>.</param>
	    public static bool operator ==(ForceUnit left, ForceUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ForceUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ForceUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ForceUnit"/>.</param>
        public static bool operator !=(ForceUnit left, ForceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="ForceUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="ForceUnit"/></returns>
        public static ForceUnit Parse(string text)
        {
            return UnitParser<ForceUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ForceUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ForceUnit"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="ForceUnit"/></param>
        /// <returns>True if an instance of <see cref="ForceUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out ForceUnit value)
        {
            return UnitParser<ForceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Newtons.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toNewtons(value);
        }

        /// <summary>
        /// Converts a value from newtons.
        /// </summary>
        /// <param name="newtons">The value in Newtons</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double newtons)
        {
            return this.fromNewtons(newtons);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Force(<paramref name="value"/>, this)</returns>
        public Force CreateQuantity(double value)
        {
            return new Force(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Newtons
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Force quantity)
        {
            return FromSiUnit(quantity.newtons);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            ForceUnit unit;
            var paddedFormat = UnitFormatCache<ForceUnit>.GetOrCreate(format, out unit);
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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<ForceUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(ForceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ForceUnit && Equals((ForceUnit)obj);
        }

        /// <summary>
        /// Returns the hashcode for this <see cref="LengthUnit"/>
        /// </summary>
        /// <returns></returns>
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