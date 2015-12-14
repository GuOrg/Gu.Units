namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.SpecificEnergy"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(SpecificEnergyUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{SpecificEnergyUnit.symbol}")]
    public struct SpecificEnergyUnit : IUnit, IUnit<SpecificEnergy>, IEquatable<SpecificEnergyUnit>
    {
        /// <summary>
        /// The SpecificEnergyUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly SpecificEnergyUnit JoulesPerKilogram = new SpecificEnergyUnit(joulesPerKilogram => joulesPerKilogram, joulesPerKilogram => joulesPerKilogram, "J/kg");

        private readonly Func<double, double> toJoulesPerKilogram;
        private readonly Func<double, double> fromJoulesPerKilogram;
        internal readonly string symbol;

        public SpecificEnergyUnit(Func<double, double> toJoulesPerKilogram, Func<double, double> fromJoulesPerKilogram, string symbol)
        {
            this.toJoulesPerKilogram = toJoulesPerKilogram;
            this.fromJoulesPerKilogram = fromJoulesPerKilogram;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.SpecificEnergyUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.SpecificEnergyUnit"/>
        /// </summary>
        public SpecificEnergyUnit SiUnit => JoulesPerKilogram;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.SpecificEnergyUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => JoulesPerKilogram;

        public static SpecificEnergy operator *(double left, SpecificEnergyUnit right)
        {
            return SpecificEnergy.From(left, right);
        }

        public static bool operator ==(SpecificEnergyUnit left, SpecificEnergyUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SpecificEnergyUnit left, SpecificEnergyUnit right)
        {
            return !left.Equals(right);
        }

        public static SpecificEnergyUnit Parse(string text)
        {
            return UnitParser<SpecificEnergyUnit>.Parse(text);
        }

        public static bool TryParse(string text, out SpecificEnergyUnit value)
        {
            return UnitParser<SpecificEnergyUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to JoulesPerKilogram.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toJoulesPerKilogram(value);
        }

        /// <summary>
        /// Converts a value from JoulesPerKilogram.
        /// </summary>
        /// <param name="value">The value in JoulesPerKilogram</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double joulesPerKilogram)
        {
            return this.fromJoulesPerKilogram(joulesPerKilogram);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new SpecificEnergy(value, this)</returns>
        public SpecificEnergy CreateQuantity(double value)
        {
            return new SpecificEnergy(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in SpecificEnergyUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(SpecificEnergy quantity)
        {
            return FromSiUnit(quantity.joulesPerKilogram);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(SpecificEnergyUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is SpecificEnergyUnit && Equals((SpecificEnergyUnit)obj);
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