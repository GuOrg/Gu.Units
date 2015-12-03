namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.LuminousIntensityUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(LuminousIntensityUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Candelas.symbol}")]
    public struct LuminousIntensityUnit : IUnit, IUnit<LuminousIntensity>, IEquatable<LuminousIntensityUnit>
    {
        /// <summary>
        /// The Candelas unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly LuminousIntensityUnit Candelas = new LuminousIntensityUnit(1.0, "cd");

        /// <summary>
        /// The Candelas unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly LuminousIntensityUnit cd = Candelas;

        private readonly double conversionFactor;
        private readonly string symbol;

        public LuminousIntensityUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.LuminousIntensityUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.LuminousIntensityUnit"/>
        /// </summary>
        public LuminousIntensityUnit SiUnit => LuminousIntensityUnit.Candelas;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.LuminousIntensityUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => LuminousIntensityUnit.Candelas;

        public static LuminousIntensity operator *(double left, LuminousIntensityUnit right)
        {
            return LuminousIntensity.From(left, right);
        }

        public static bool operator ==(LuminousIntensityUnit left, LuminousIntensityUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(LuminousIntensityUnit left, LuminousIntensityUnit right)
        {
            return !left.Equals(right);
        }

        public static LuminousIntensityUnit Parse(string text)
        {
            return UnitParser<LuminousIntensityUnit>.Parse(text);
        }

        public static bool TryParse(string text, out LuminousIntensityUnit value)
        {
            return UnitParser<LuminousIntensityUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Candelas.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Candelas.
        /// </summary>
        /// <param name="value">The value in Candelas</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new LuminousIntensity(value, this)</returns>
        public LuminousIntensity CreateQuantity(double value)
        {
            return new LuminousIntensity(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Candelas
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(LuminousIntensity quantity)
        {
            return FromSiUnit(quantity.candelas);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(LuminousIntensityUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is LuminousIntensityUnit && Equals((LuminousIntensityUnit)obj);
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