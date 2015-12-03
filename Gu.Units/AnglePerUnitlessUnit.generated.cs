namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.AnglePerUnitlessUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(AnglePerUnitlessUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{RadiansPerUnitless.symbol}")]
    public struct AnglePerUnitlessUnit : IUnit, IUnit<AnglePerUnitless>, IEquatable<AnglePerUnitlessUnit>
    {
        /// <summary>
        /// The RadiansPerUnitless unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly AnglePerUnitlessUnit RadiansPerUnitless = new AnglePerUnitlessUnit(1.0, "rad/ul");

        /// <summary>
        /// The DegreesPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AnglePerUnitlessUnit DegreesPerPercent = new AnglePerUnitlessUnit(1.7453292519943295, "°/%");

        /// <summary>
        /// The RadiansPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly AnglePerUnitlessUnit RadiansPerPercent = new AnglePerUnitlessUnit(100, "rad/%");

        private readonly double conversionFactor;
        private readonly string symbol;

        public AnglePerUnitlessUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.AnglePerUnitlessUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.AnglePerUnitlessUnit"/>
        /// </summary>
        public AnglePerUnitlessUnit SiUnit => AnglePerUnitlessUnit.RadiansPerUnitless;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.AnglePerUnitlessUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => AnglePerUnitlessUnit.RadiansPerUnitless;

        public static AnglePerUnitless operator *(double left, AnglePerUnitlessUnit right)
        {
            return AnglePerUnitless.From(left, right);
        }

        public static bool operator ==(AnglePerUnitlessUnit left, AnglePerUnitlessUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(AnglePerUnitlessUnit left, AnglePerUnitlessUnit right)
        {
            return !left.Equals(right);
        }

        public static AnglePerUnitlessUnit Parse(string text)
        {
            return UnitParser<AnglePerUnitlessUnit>.Parse(text);
        }

        public static bool TryParse(string text, out AnglePerUnitlessUnit value)
        {
            return UnitParser<AnglePerUnitlessUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to RadiansPerUnitless.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from RadiansPerUnitless.
        /// </summary>
        /// <param name="value">The value in RadiansPerUnitless</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new AnglePerUnitless(value, this)</returns>
        public AnglePerUnitless CreateQuantity(double value)
        {
            return new AnglePerUnitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in RadiansPerUnitless
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(AnglePerUnitless quantity)
        {
            return FromSiUnit(quantity.radiansPerUnitless);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(AnglePerUnitlessUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is AnglePerUnitlessUnit && Equals((AnglePerUnitlessUnit)obj);
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