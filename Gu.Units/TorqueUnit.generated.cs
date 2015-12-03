namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.TorqueUnit"/>.
	/// Contains conversion logic.
    /// </summary>
    [Serializable, TypeConverter(typeof(TorqueUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{NewtonMetres.symbol}")]
    public struct TorqueUnit : IUnit, IUnit<Torque>, IEquatable<TorqueUnit>
    {
        /// <summary>
        /// The NewtonMetres unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly TorqueUnit NewtonMetres = new TorqueUnit(1.0, "N⋅m");

        private readonly double conversionFactor;
        private readonly string symbol;

        public TorqueUnit(double conversionFactor, string symbol)
        {
            this.conversionFactor = conversionFactor;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.TorqueUnit"/>.
        /// </summary>
        public string Symbol
        {
            get
            {
                return this.symbol;
            }
        }

        /// <summary>
        /// The default unit for <see cref="Gu.Units.TorqueUnit"/>
        /// </summary>
        public TorqueUnit SiUnit => TorqueUnit.NewtonMetres;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.TorqueUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => TorqueUnit.NewtonMetres;

        public static Torque operator *(double left, TorqueUnit right)
        {
            return Torque.From(left, right);
        }

        public static bool operator ==(TorqueUnit left, TorqueUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(TorqueUnit left, TorqueUnit right)
        {
            return !left.Equals(right);
        }

        public static TorqueUnit Parse(string text)
        {
            return UnitParser<TorqueUnit>.Parse(text);
        }

        public static bool TryParse(string text, out TorqueUnit value)
        {
            return UnitParser<TorqueUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to NewtonMetres.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.conversionFactor * value;
        }

        /// <summary>
        /// Converts a value from NewtonMetres.
        /// </summary>
        /// <param name="value">The value in NewtonMetres</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double value)
        {
            return value / this.conversionFactor;
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Torque(value, this)</returns>
        public Torque CreateQuantity(double value)
        {
            return new Torque(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in NewtonMetres
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Torque quantity)
        {
            return FromSiUnit(quantity.newtonMetres);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(TorqueUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is TorqueUnit && Equals((TorqueUnit)obj);
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