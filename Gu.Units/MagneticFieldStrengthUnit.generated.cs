namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.MagneticFieldStrength"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(MagneticFieldStrengthUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{MagneticFieldStrengthUnit.symbol}")]
    public struct MagneticFieldStrengthUnit : IUnit, IUnit<MagneticFieldStrength>, IEquatable<MagneticFieldStrengthUnit>
    {
        /// <summary>
        /// The MagneticFieldStrengthUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly MagneticFieldStrengthUnit Teslas = new MagneticFieldStrengthUnit(teslas => teslas, teslas => teslas, "T");

        private readonly Func<double, double> toTeslas;
        private readonly Func<double, double> fromTeslas;
        internal readonly string symbol;

        public MagneticFieldStrengthUnit(Func<double, double> toTeslas, Func<double, double> fromTeslas, string symbol)
        {
            this.toTeslas = toTeslas;
            this.fromTeslas = fromTeslas;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.MagneticFieldStrengthUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.MagneticFieldStrengthUnit"/>
        /// </summary>
        public MagneticFieldStrengthUnit SiUnit => Teslas;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.MagneticFieldStrengthUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Teslas;

        public static MagneticFieldStrength operator *(double left, MagneticFieldStrengthUnit right)
        {
            return MagneticFieldStrength.From(left, right);
        }

        public static bool operator ==(MagneticFieldStrengthUnit left, MagneticFieldStrengthUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(MagneticFieldStrengthUnit left, MagneticFieldStrengthUnit right)
        {
            return !left.Equals(right);
        }

        public static MagneticFieldStrengthUnit Parse(string text)
        {
            return UnitParser<MagneticFieldStrengthUnit>.Parse(text);
        }

        public static bool TryParse(string text, out MagneticFieldStrengthUnit value)
        {
            return UnitParser<MagneticFieldStrengthUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Teslas.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toTeslas(value);
        }

        /// <summary>
        /// Converts a value from Teslas.
        /// </summary>
        /// <param name="value">The value in Teslas</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double teslas)
        {
            return this.fromTeslas(teslas);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new MagneticFieldStrength(value, this)</returns>
        public MagneticFieldStrength CreateQuantity(double value)
        {
            return new MagneticFieldStrength(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in MagneticFieldStrengthUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(MagneticFieldStrength quantity)
        {
            return FromSiUnit(quantity.teslas);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(MagneticFieldStrengthUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MagneticFieldStrengthUnit && Equals((MagneticFieldStrengthUnit)obj);
        }

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