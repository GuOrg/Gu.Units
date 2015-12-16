namespace Gu.Units
{
    using System;
    using System.ComponentModel;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Energy"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(EnergyUnitTypeConverter))]
    public struct EnergyUnit : IUnit, IUnit<Energy>, IEquatable<EnergyUnit>
    {
        /// <summary>
        /// The EnergyUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly EnergyUnit Joules = new EnergyUnit(joules => joules, joules => joules, "J");

        /// <summary>
        /// The Nanojoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Nanojoules = new EnergyUnit(nanojoules => nanojoules / 1000000000, joules => 1000000000 * joules, "nJ");

        /// <summary>
        /// The Microjoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Microjoules = new EnergyUnit(microjoules => microjoules / 1000000, joules => 1000000 * joules, "µJ");

        /// <summary>
        /// The Millijoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Millijoules = new EnergyUnit(millijoules => millijoules / 1000, joules => 1000 * joules, "mJ");

        /// <summary>
        /// The Kilojoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Kilojoules = new EnergyUnit(kilojoules => 1000 * kilojoules, joules => joules / 1000, "kJ");

        /// <summary>
        /// The Megajoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Megajoules = new EnergyUnit(megajoules => 1000000 * megajoules, joules => joules / 1000000, "MJ");

        /// <summary>
        /// The Gigajoules unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit Gigajoules = new EnergyUnit(gigajoules => 1000000000 * gigajoules, joules => joules / 1000000000, "GJ");

        /// <summary>
        /// The KilowattHours unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly EnergyUnit KilowattHours = new EnergyUnit(kilowattHours => 3600000 * kilowattHours, joules => joules / 3600000, "kWh");

        private readonly Func<double, double> toJoules;
        private readonly Func<double, double> fromJoules;
        internal readonly string symbol;

        public EnergyUnit(Func<double, double> toJoules, Func<double, double> fromJoules, string symbol)
        {
            this.toJoules = toJoules;
            this.fromJoules = fromJoules;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.EnergyUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.EnergyUnit"/>
        /// </summary>
        public EnergyUnit SiUnit => Joules;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.EnergyUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Joules;

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

        /// <summary>
        /// Constructs a <see cref="EnergyUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="EnergyUnit"/></returns>
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
            return this.toJoules(value);
        }

        /// <summary>
        /// Converts a value from joules.
        /// </summary>
        /// <param name="joules">The value in Joules</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double joules)
        {
            return this.fromJoules(joules);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Energy(<paramref name="value"/>, this)</returns>
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

        public string ToString(string format)
        {
            EnergyUnit unit;
            var paddedFormat = UnitFormatCache<EnergyUnit>.GetOrCreate(format, out unit);
            if (unit != this)
            {
                return format;
            }

            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public string ToString(SymbolFormat format)
        {
            var paddedFormat = UnitFormatCache<EnergyUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
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

        /// <summary>
        /// Returns the hashcode for this <see cref="LengthUnit"/>
        /// </summary>
        /// <returns></returns>
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