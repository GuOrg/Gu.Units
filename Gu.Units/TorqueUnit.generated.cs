namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Torque"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(TorqueUnitTypeConverter))]
    public struct TorqueUnit : IUnit, IUnit<Torque>, IEquatable<TorqueUnit>
    {
        /// <summary>
        /// The TorqueUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly TorqueUnit NewtonMetres = new TorqueUnit(newtonMetres => newtonMetres, newtonMetres => newtonMetres, "N⋅m");

        private readonly Func<double, double> toNewtonMetres;
        private readonly Func<double, double> fromNewtonMetres;
        internal readonly string symbol;

        /// <summary>
        /// Initializes a new instance of <see cref="TorqueUnit"/>.
        /// </summary>
        /// <param name="toNewtonMetres">The conversion to <see cref="NewtonMetres"/></param>
        /// <param name="fromNewtonMetres">The conversion to <paramref name="symbol"/></param>
        /// <param name="symbol">The symbol for the <see cref="NewtonMetres"/></param>
        public TorqueUnit(Func<double, double> toNewtonMetres, Func<double, double> fromNewtonMetres, string symbol)
        {
            this.toNewtonMetres = toNewtonMetres;
            this.fromNewtonMetres = fromNewtonMetres;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.TorqueUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.TorqueUnit"/>
        /// </summary>
        public TorqueUnit SiUnit => NewtonMetres;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.TorqueUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => NewtonMetres;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Torque"/> that is the result from the multiplication.</returns>
        public static Torque operator *(double left, TorqueUnit right)
        {
            return Torque.From(left, right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.TorqueUnit"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.TorqueUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.TorqueUnit"/>.</param>
	    public static bool operator ==(TorqueUnit left, TorqueUnit right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.TorqueUnit"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.TorqueUnit"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.TorqueUnit"/>.</param>
        public static bool operator !=(TorqueUnit left, TorqueUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="TorqueUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="TorqueUnit"/></returns>
        public static TorqueUnit Parse(string text)
        {
            return UnitParser<TorqueUnit>.Parse(text);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.TorqueUnit"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.TorqueUnit"/></param>
        /// <param name="result">The parsed <see cref="TorqueUnit"/></param>
        /// <returns>True if an instance of <see cref="TorqueUnit"/> could be parsed from <paramref name="text"/></returns>	
        public static bool TryParse(string text, out TorqueUnit result)
        {
            return UnitParser<TorqueUnit>.TryParse(text, out result);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to NewtonMetres.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toNewtonMetres(value);
        }

        /// <summary>
        /// Converts a value from newtonMetres.
        /// </summary>
        /// <param name="newtonMetres">The value in NewtonMetres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double newtonMetres)
        {
            return this.fromNewtonMetres(newtonMetres);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Torque(<paramref name="value"/>, this)</returns>
        public Torque CreateQuantity(double value)
        {
            return new Torque(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in NewtonMetres
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Torque quantity)
        {
            return FromSiUnit(quantity.newtonMetres);
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
            TorqueUnit unit;
            var paddedFormat = UnitFormatCache<TorqueUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<TorqueUnit>.GetOrCreate(this, symbolFormat);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.TorqueUnit"/> object.
        /// </summary>
        /// <param name="other">An instance of <see cref="Gu.Units.TorqueUnit"/> object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="other"/> represents the same TorqueUnit as this instance; otherwise, false.
        /// </returns>
		public bool Equals(TorqueUnit other)
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

            return obj is TorqueUnit && Equals((TorqueUnit)obj);
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