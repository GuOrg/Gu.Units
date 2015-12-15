namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Wavenumber"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(WavenumberUnitTypeConverter))]
    public struct WavenumberUnit : IUnit, IUnit<Wavenumber>, IEquatable<WavenumberUnit>
    {
        /// <summary>
        /// The WavenumberUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly WavenumberUnit ReciprocalMetres = new WavenumberUnit(reciprocalMetres => reciprocalMetres, reciprocalMetres => reciprocalMetres, "m⁻¹");

        private readonly Func<double, double> toReciprocalMetres;
        private readonly Func<double, double> fromReciprocalMetres;
        internal readonly string symbol;

        public WavenumberUnit(Func<double, double> toReciprocalMetres, Func<double, double> fromReciprocalMetres, string symbol)
        {
            this.toReciprocalMetres = toReciprocalMetres;
            this.fromReciprocalMetres = fromReciprocalMetres;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.WavenumberUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.WavenumberUnit"/>
        /// </summary>
        public WavenumberUnit SiUnit => ReciprocalMetres;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.WavenumberUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => ReciprocalMetres;

        public static Wavenumber operator *(double left, WavenumberUnit right)
        {
            return Wavenumber.From(left, right);
        }

        public static bool operator ==(WavenumberUnit left, WavenumberUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(WavenumberUnit left, WavenumberUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="WavenumberUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="WavenumberUnit"/></returns>
        public static WavenumberUnit Parse(string text)
        {
            return UnitParser<WavenumberUnit>.Parse(text);
        }

        public static bool TryParse(string text, out WavenumberUnit value)
        {
            return UnitParser<WavenumberUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to ReciprocalMetres.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toReciprocalMetres(value);
        }

        /// <summary>
        /// Converts a value from reciprocalMetres.
        /// </summary>
        /// <param name="ReciprocalMetres">The value in ReciprocalMetres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double reciprocalMetres)
        {
            return this.fromReciprocalMetres(reciprocalMetres);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Wavenumber(<paramref name="value"/>, this)</returns>
        public Wavenumber CreateQuantity(double value)
        {
            return new Wavenumber(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in ReciprocalMetres
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Wavenumber quantity)
        {
            return FromSiUnit(quantity.reciprocalMetres);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            WavenumberUnit unit;
            var paddedFormat = UnitFormatCache<WavenumberUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<WavenumberUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(WavenumberUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is WavenumberUnit && Equals((WavenumberUnit)obj);
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