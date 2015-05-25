namespace Gu.Units
{
    using System;
    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.DensityUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable]
    public struct DensityUnit : IUnit, IUnit<Density>, IEquatable<DensityUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.KilogramsPerCubicMetre"/> unit
        /// Contains coonversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit KilogramsPerCubicMetre = new DensityUnit(1.0, "kg/m³");

        /// <summary>
        /// The <see cref="T:Gu.Units.GramsPerCubicMillimetre"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly DensityUnit GramsPerCubicMillimetre = new DensityUnit(999999.99999999988, "g/mm³");

        /// <summary>
        /// The <see cref="T:Gu.Units.GramsPerCubicCentimetre"/> unit
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
        /// The symbol for <see cref="T:Gu.Units.KilogramsPerCubicMetre"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

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

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.KilogramsPerCubicMetre"/>.
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
        /// <returns>new TTQuantity(value, this)</returns>
        public Density CreateQuantity(double value)
        {
            return new Density(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Density quantity)
        {
            return FromSiUnit(quantity.kilogramsPerCubicMetre);
        }

        public override string ToString()
        {
            return string.Format("1{0} == {1}{2}", this.symbol, this.ToSiUnit(1), KilogramsPerCubicMetre.symbol);
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