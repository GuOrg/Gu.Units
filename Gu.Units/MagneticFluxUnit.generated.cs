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
        /// The MagneticFluxUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MagneticFluxUnit Webers = new MagneticFluxUnit(webers => webers, webers => webers, "Wb");

        private readonly Func<double, double> toWebers;
        private readonly Func<double, double> fromWebers;
        internal readonly string symbol;

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

        public static MagneticFlux operator *(double left, MagneticFluxUnit right)
        {
            return MagneticFlux.From(left, right);
        }

        public static bool operator ==(MagneticFluxUnit left, MagneticFluxUnit right)
        {
            return left.Equals(right);
        }

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

        public static bool TryParse(string text, out MagneticFluxUnit value)
        {
            return UnitParser<MagneticFluxUnit>.TryParse(text, out value);
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

        public override string ToString()
        {
            return this.symbol;
        }

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

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<MagneticFluxUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(MagneticFluxUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MagneticFluxUnit && Equals((MagneticFluxUnit)obj);
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