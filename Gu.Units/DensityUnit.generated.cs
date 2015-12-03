namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.DensityUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(DensityUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{KilogramsPerCubicMetre.symbol}")]
    public struct DensityUnit : IUnit, IUnit<Density>, IEquatable<DensityUnit>
    {
        /// <summary>
        /// The KilogramsPerCubicMetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit KilogramsPerCubicMetre = new DensityUnit(1.0, "kg/m³");

        /// <summary>
        /// The GramsPerCubicMillimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly DensityUnit GramsPerCubicMillimetre = new DensityUnit(999999.99999999988, "g/mm³");

        /// <summary>
        /// The GramsPerCubicCentimetre unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly DensityUnit GramsPerCubicCentimetre = new DensityUnit(999.99999999999989, "g/cm³");

        private readonly double conversionFactor;
        private readonly string symbol;

        public DensityUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.DensityUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.DensityUnit"/>
        /// </summary>
        public DensityUnit SiUnit => DensityUnit.KilogramsPerCubicMetre;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.DensityUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => DensityUnit.KilogramsPerCubicMetre;

        public static Density operator *(double left, DensityUnit right)
        {
            return Density.From(left, right);
        }

        public static bool operator ==(DensityUnit left, DensityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(DensityUnit left, DensityUnit right)
        {
            return !left.Equals(right);
        }

        public static DensityUnit Parse(string text)
        {
            return UnitParser<DensityUnit>.Parse(text);
        }

        public static bool TryParse(string text, out DensityUnit value)
        {
            return UnitParser<DensityUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to KilogramsPerCubicMetre.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from KilogramsPerCubicMetre.
        /// </summary>
        /// <param name="value">The value in KilogramsPerCubicMetre</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Density(value, this)</returns>
        public Density CreateQuantity(double value)
        {
            return new Density(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in KilogramsPerCubicMetre
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Density quantity)
        {
            return FromSiUnit(quantity.kilogramsPerCubicMetre);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(DensityUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is DensityUnit && Equals((DensityUnit)obj);
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