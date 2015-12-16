namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Momentum"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(MomentumUnitTypeConverter))]
    public struct MomentumUnit : IUnit, IUnit<Momentum>, IEquatable<MomentumUnit>
    {
        /// <summary>
        /// The MomentumUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MomentumUnit NewtonSecond = new MomentumUnit(newtonSecond => newtonSecond, newtonSecond => newtonSecond, "N⋅s");

        private readonly Func<double, double> toNewtonSecond;
        private readonly Func<double, double> fromNewtonSecond;
        internal readonly string symbol;

        public MomentumUnit(Func<double, double> toNewtonSecond, Func<double, double> fromNewtonSecond, string symbol)
        {
            this.toNewtonSecond = toNewtonSecond;
            this.fromNewtonSecond = fromNewtonSecond;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.MomentumUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.MomentumUnit"/>
        /// </summary>
        public MomentumUnit SiUnit => NewtonSecond;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.MomentumUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => NewtonSecond;

        public static Momentum operator *(double left, MomentumUnit right)
        {
            return Momentum.From(left, right);
        }

        public static bool operator ==(MomentumUnit left, MomentumUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MomentumUnit left, MomentumUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="MomentumUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="MomentumUnit"/></returns>
        public static MomentumUnit Parse(string text)
        {
            return UnitParser<MomentumUnit>.Parse(text);
        }

        public static bool TryParse(string text, out MomentumUnit value)
        {
            return UnitParser<MomentumUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to NewtonSecond.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toNewtonSecond(value);
        }

        /// <summary>
        /// Converts a value from newtonSecond.
        /// </summary>
        /// <param name="newtonSecond">The value in NewtonSecond</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double newtonSecond)
        {
            return this.fromNewtonSecond(newtonSecond);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Momentum(<paramref name="value"/>, this)</returns>
        public Momentum CreateQuantity(double value)
        {
            return new Momentum(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in NewtonSecond
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Momentum quantity)
        {
            return FromSiUnit(quantity.newtonSecond);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            MomentumUnit unit;
            var paddedFormat = UnitFormatCache<MomentumUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<MomentumUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(MomentumUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MomentumUnit && Equals((MomentumUnit)obj);
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