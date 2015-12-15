namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

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

        public static Torque operator *(double left, TorqueUnit right)
        {
            return Torque.From(left, right);
        }

        public static bool operator ==(TorqueUnit left, TorqueUnit right)
        {
            return left.Equals(right);
        }

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

        public static bool TryParse(string text, out TorqueUnit value)
        {
            return UnitParser<TorqueUnit>.TryParse(text, out value);
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
        /// <param name="NewtonMetres">The value in NewtonMetres</param>
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

        public override string ToString()
        {
            return this.symbol;
        }

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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<TorqueUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(TorqueUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TorqueUnit && Equals((TorqueUnit)obj);
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