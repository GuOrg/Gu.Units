namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.EnergyUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(EnergyUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{Joules.symbol}")]
    public struct EnergyUnit : IUnit, IUnit<Energy>, IEquatable<EnergyUnit>
    {
        /// <summary>
        /// The Joules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Joules = new EnergyUnit(1.0, "J");

        /// <summary>
        /// The Joules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit J = Joules;

        /// <summary>
        /// The Nanojoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit Nanojoules = new EnergyUnit(1E-09, "nJ");

        /// <summary>
        /// The Nanojoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit nJ = Nanojoules;

        /// <summary>
        /// The Microjoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit Microjoules = new EnergyUnit(1E-06, "µJ");

        /// <summary>
        /// The Microjoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit µJ = Microjoules;

        /// <summary>
        /// The Millijoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit Millijoules = new EnergyUnit(0.001, "mJ");

        /// <summary>
        /// The Millijoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit mJ = Millijoules;

        /// <summary>
        /// The Kilojoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit Kilojoules = new EnergyUnit(1000, "kJ");

        /// <summary>
        /// The Kilojoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit kJ = Kilojoules;

        /// <summary>
        /// The Megajoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit Megajoules = new EnergyUnit(1000000, "MJ");

        /// <summary>
        /// The Megajoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit MJ = Megajoules;

        /// <summary>
        /// The Gigajoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit Gigajoules = new EnergyUnit(1000000000, "GJ");

        /// <summary>
        /// The Gigajoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit GJ = Gigajoules;

        /// <summary>
        /// The KilowattHours unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit KilowattHours = new EnergyUnit(3600000, "kWh");

        /// <summary>
        /// The KilowattHours unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
		public static readonly EnergyUnit kWh = KilowattHours;

        private readonly double conversionFactor;
        private readonly string symbol;

        public EnergyUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.EnergyUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.EnergyUnit"/>
        /// </summary>
        public EnergyUnit SiUnit => EnergyUnit.Joules;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.EnergyUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => EnergyUnit.Joules;

        public static Energy operator *(double left, EnergyUnit right)
        {
            return Energy.From(left, right);
        }

        public static bool operator ==(EnergyUnit left, EnergyUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(EnergyUnit left, EnergyUnit right)
        {
            return !left.Equals(right);
        }

        public static EnergyUnit Parse(string text)
        {
            return UnitParser<EnergyUnit>.Parse(text);
        }

        public static bool TryParse(string text, out EnergyUnit value)
        {
            return UnitParser<EnergyUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Joules.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from Joules.
        /// </summary>
        /// <param name="value">The value in Joules</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Energy(value, this)</returns>
        public Energy CreateQuantity(double value)
        {
            return new Energy(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Joules
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Energy quantity)
        {
            return FromSiUnit(quantity.joules);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(EnergyUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is EnergyUnit && Equals((EnergyUnit)obj);
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