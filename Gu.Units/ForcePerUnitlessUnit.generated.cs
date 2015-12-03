namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.ForcePerUnitlessUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(ForcePerUnitlessUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{NewtonsPerUnitless.symbol}")]
    public struct ForcePerUnitlessUnit : IUnit, IUnit<ForcePerUnitless>, IEquatable<ForcePerUnitlessUnit>
    {
        /// <summary>
        /// The NewtonsPerUnitless unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly ForcePerUnitlessUnit NewtonsPerUnitless = new ForcePerUnitlessUnit(1.0, "N/ul");

        /// <summary>
        /// The NewtonsPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForcePerUnitlessUnit NewtonsPerPercent = new ForcePerUnitlessUnit(100, "N/%");

        /// <summary>
        /// The KilonewtonsPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForcePerUnitlessUnit KilonewtonsPerPercent = new ForcePerUnitlessUnit(100000, "kN/%");

        /// <summary>
        /// The MeganewtonsPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForcePerUnitlessUnit MeganewtonsPerPercent = new ForcePerUnitlessUnit(100000000, "MN/%");

        /// <summary>
        /// The GiganewtonsPerPercent unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly ForcePerUnitlessUnit GiganewtonsPerPercent = new ForcePerUnitlessUnit(100000000000, "GN/%");

        private readonly double conversionFactor;
        private readonly string symbol;

        public ForcePerUnitlessUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.ForcePerUnitlessUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.ForcePerUnitlessUnit"/>
        /// </summary>
        public ForcePerUnitlessUnit SiUnit => ForcePerUnitlessUnit.NewtonsPerUnitless;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.ForcePerUnitlessUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => ForcePerUnitlessUnit.NewtonsPerUnitless;

        public static ForcePerUnitless operator *(double left, ForcePerUnitlessUnit right)
        {
            return ForcePerUnitless.From(left, right);
        }

        public static bool operator ==(ForcePerUnitlessUnit left, ForcePerUnitlessUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ForcePerUnitlessUnit left, ForcePerUnitlessUnit right)
        {
            return !left.Equals(right);
        }

        public static ForcePerUnitlessUnit Parse(string text)
        {
            return UnitParser<ForcePerUnitlessUnit>.Parse(text);
        }

        public static bool TryParse(string text, out ForcePerUnitlessUnit value)
        {
            return UnitParser<ForcePerUnitlessUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to NewtonsPerUnitless.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from NewtonsPerUnitless.
        /// </summary>
        /// <param name="value">The value in NewtonsPerUnitless</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new ForcePerUnitless(value, this)</returns>
        public ForcePerUnitless CreateQuantity(double value)
        {
            return new ForcePerUnitless(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in NewtonsPerUnitless
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(ForcePerUnitless quantity)
        {
            return FromSiUnit(quantity.newtonsPerUnitless);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(ForcePerUnitlessUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ForcePerUnitlessUnit && Equals((ForcePerUnitlessUnit)obj);
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