namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Inductance"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable, TypeConverter(typeof(InductanceUnitTypeConverter)), DebuggerDisplay("1{symbol} == {ToSiUnit(1)}{InductanceUnit.symbol}")]
    public struct InductanceUnit : IUnit, IUnit<Inductance>, IEquatable<InductanceUnit>
    {
        /// <summary>
        /// The InductanceUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly InductanceUnit Henrys = new InductanceUnit(henrys => henrys, henrys => henrys, "H");

        /// <summary>
        /// The Nanohenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Nanohenrys = new InductanceUnit(nanohenrys => nanohenrys / 1000000000, henrys => 1000000000 * henrys, "nH");

        /// <summary>
        /// The Microhenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Microhenrys = new InductanceUnit(microhenrys => microhenrys / 1000000, henrys => 1000000 * henrys, "µH");

        /// <summary>
        /// The Millihenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Millihenrys = new InductanceUnit(millihenrys => millihenrys / 1000, henrys => 1000 * henrys, "mH");

        /// <summary>
        /// The Kilohenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Kilohenrys = new InductanceUnit(kilohenrys => 1000 * kilohenrys, henrys => henrys / 1000, "kH");

        /// <summary>
        /// The Megahenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Megahenrys = new InductanceUnit(megahenrys => 1000000 * megahenrys, henrys => henrys / 1000000, "MH");

        /// <summary>
        /// The Gigahenrys unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly InductanceUnit Gigahenrys = new InductanceUnit(gigahenrys => 1000000000 * gigahenrys, henrys => henrys / 1000000000, "GH");

        private readonly Func<double, double> toHenrys;
        private readonly Func<double, double> fromHenrys;
        internal readonly string symbol;

        public InductanceUnit(Func<double, double> toHenrys, Func<double, double> fromHenrys, string symbol)
        {
            this.toHenrys = toHenrys;
            this.fromHenrys = fromHenrys;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.InductanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.InductanceUnit"/>
        /// </summary>
        public InductanceUnit SiUnit => Henrys;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.InductanceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Henrys;

        public static Inductance operator *(double left, InductanceUnit right)
        {
            return Inductance.From(left, right);
        }

        public static bool operator ==(InductanceUnit left, InductanceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(InductanceUnit left, InductanceUnit right)
        {
            return !left.Equals(right);
        }

        public static InductanceUnit Parse(string text)
        {
            return UnitParser<InductanceUnit>.Parse(text);
        }

        public static bool TryParse(string text, out InductanceUnit value)
        {
            return UnitParser<InductanceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Henrys.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toHenrys(value);
        }

        /// <summary>
        /// Converts a value from Henrys.
        /// </summary>
        /// <param name="value">The value in Henrys</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double henrys)
        {
            return this.fromHenrys(henrys);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value"></param>
        /// <returns>new Inductance(value, this)</returns>
        public Inductance CreateQuantity(double value)
        {
            return new Inductance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in InductanceUnit
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Inductance quantity)
        {
            return FromSiUnit(quantity.henrys);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public bool Equals(InductanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is InductanceUnit && Equals((InductanceUnit)obj);
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