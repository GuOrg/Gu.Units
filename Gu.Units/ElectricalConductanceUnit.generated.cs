namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.ElectricalConductance"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(ElectricalConductanceUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{ElectricalConductanceUnit.symbol}")]
    public struct ElectricalConductanceUnit : IUnit, IUnit<ElectricalConductance>, IEquatable<ElectricalConductanceUnit>
    {
        /// <summary>
        /// The ElectricalConductanceUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly ElectricalConductanceUnit Siemens = new ElectricalConductanceUnit(siemens => siemens, siemens => siemens, "S");

        private readonly Func<double, double> toSiemens;
        private readonly Func<double, double> fromSiemens;
        internal readonly string symbol;

        public ElectricalConductanceUnit(Func<double, double> toSiemens, Func<double, double> fromSiemens, string symbol)
        {
            this.toSiemens = toSiemens;
            this.fromSiemens = fromSiemens;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.ElectricalConductanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.ElectricalConductanceUnit"/>
        /// </summary>
        public ElectricalConductanceUnit SiUnit => Siemens;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.ElectricalConductanceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Siemens;

        public static ElectricalConductance operator *(double left, ElectricalConductanceUnit right)
        {
            return ElectricalConductance.From(left, right);
        }

        public static bool operator ==(ElectricalConductanceUnit left, ElectricalConductanceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(ElectricalConductanceUnit left, ElectricalConductanceUnit right)
        {
            return !left.Equals(right);
        }

        public static ElectricalConductanceUnit Parse(string text)
        {
            return UnitParser<ElectricalConductanceUnit>.Parse(text);
        }

        public static bool TryParse(string text, out ElectricalConductanceUnit value)
        {
            return UnitParser<ElectricalConductanceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Siemens.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toSiemens(value);
        }

        /// <summary>
        /// Converts a value from Siemens.
        /// </summary>
        /// <param name="value">The value in Siemens</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double siemens)
        {
            return this.fromSiemens(siemens);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new ElectricalConductance(value, this)</returns>
        public ElectricalConductance CreateQuantity(double value)
        {
            return new ElectricalConductance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in ElectricalConductanceUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(ElectricalConductance quantity)
        {
            return FromSiUnit(quantity.siemens);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(ElectricalConductanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ElectricalConductanceUnit && Equals((ElectricalConductanceUnit)obj);
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