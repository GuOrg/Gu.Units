namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="T:Gu.Units.VolumeUnit"/>.
    /// Contains conversion logic.
    /// </summary>
    [Serializable, DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{CubicMetres.symbol}")]
    public struct VolumeUnit : IUnit, IUnit<Volume>, IEquatable<VolumeUnit>
    {
        /// <summary>
        /// The <see cref="T:Gu.Units.CubicMetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicMetres = new VolumeUnit(1.0, "m³");

        /// <summary>
        /// The <see cref="T:Gu.Units.Litres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit Litres = new VolumeUnit(0.0010000000000000002, "L");
        /// <summary>
        /// The <see cref="T:Gu.Units.Litres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit L = Litres;

        /// <summary>
        /// The <see cref="T:Gu.Units.CubicCentimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicCentimetres = new VolumeUnit(1.0000000000000002E-06, "cm³");

        /// <summary>
        /// The <see cref="T:Gu.Units.CubicMillimetres"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicMillimetres = new VolumeUnit(1E-09, "mm³");

        /// <summary>
        /// The <see cref="T:Gu.Units.CubicInches"/> unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly VolumeUnit CubicInches = new VolumeUnit(1.6387064E-05, "in³");

        private readonly double conversionFactor;
        private readonly string symbol;

        public VolumeUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for <see cref="T:Gu.Units.CubicMetres"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        public static Volume operator *(double left, VolumeUnit right)
        {
            return Volume.From(left, right);
        }

        public static bool operator ==(VolumeUnit left, VolumeUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(VolumeUnit left, VolumeUnit right)
        {
            return !left.Equals(right);
        }

        public static VolumeUnit Parse(string text)
        {
            return Parser.ParseUnit<VolumeUnit>(text);
        }

        /// <summary>
        /// Converts a value to <see cref="T:Gu.Units.CubicMetres"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from CubicMetres.
        /// </summary>
        /// <param name="value">The value in CubicMetres</param>
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
        public Volume CreateQuantity(double value)
        {
            return new Volume(value, this);
        }

        /// <summary>
        /// Gets the scalar value
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Volume quantity)
        {
            return FromSiUnit(quantity.cubicMetres);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(VolumeUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is VolumeUnit && Equals((VolumeUnit)obj);
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