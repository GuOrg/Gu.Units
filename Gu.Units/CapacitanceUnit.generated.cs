namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;

    /// <summary>
    /// A type for the unit <see cref="Gu.Units.Capacitance"/>.
	/// Contains logic for conversion and formatting.
    /// </summary>
    [Serializable]
    [TypeConverter(typeof(CapacitanceUnitTypeConverter))]
    public struct CapacitanceUnit : IUnit, IUnit<Capacitance>, IEquatable<CapacitanceUnit>
    {
        /// <summary>
        /// The CapacitanceUnit unit
        /// Contains logic for conversion and formatting.
        /// </summary>
        public static readonly CapacitanceUnit Farads = new CapacitanceUnit(farads => farads, farads => farads, "F");

        /// <summary>
        /// The Nanofarads unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CapacitanceUnit Nanofarads = new CapacitanceUnit(nanofarads => nanofarads / 1000000000, farads => 1000000000 * farads, "nF");

        /// <summary>
        /// The Microfarads unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CapacitanceUnit Microfarads = new CapacitanceUnit(microfarads => microfarads / 1000000, farads => 1000000 * farads, "µF");

        /// <summary>
        /// The Millifarads unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CapacitanceUnit Millifarads = new CapacitanceUnit(millifarads => millifarads / 1000, farads => 1000 * farads, "mF");

        /// <summary>
        /// The Kilofarads unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CapacitanceUnit Kilofarads = new CapacitanceUnit(kilofarads => 1000 * kilofarads, farads => farads / 1000, "kF");

        /// <summary>
        /// The Megafarads unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CapacitanceUnit Megafarads = new CapacitanceUnit(megafarads => 1000000 * megafarads, farads => farads / 1000000, "MF");

        /// <summary>
        /// The Gigafarads unit
        /// Contains conversion logic to from and formatting.
        /// </summary>
        public static readonly CapacitanceUnit Gigafarads = new CapacitanceUnit(gigafarads => 1000000000 * gigafarads, farads => farads / 1000000000, "GF");

        private readonly Func<double, double> toFarads;
        private readonly Func<double, double> fromFarads;
        internal readonly string symbol;

        public CapacitanceUnit(Func<double, double> toFarads, Func<double, double> fromFarads, string symbol)
        {
            this.toFarads = toFarads;
            this.fromFarads = fromFarads;
            this.symbol = symbol;
        }

        /// <summary>
        /// The symbol for the <see cref="Gu.Units.CapacitanceUnit"/>.
        /// </summary>
        public string Symbol => this.symbol;

        /// <summary>
        /// The default unit for <see cref="Gu.Units.CapacitanceUnit"/>
        /// </summary>
        public CapacitanceUnit SiUnit => Farads;

        /// <summary>
        /// The default <see cref="Gu.Units.IUnit"/> for <see cref="Gu.Units.CapacitanceUnit"/>
        /// </summary>
        IUnit IUnit.SiUnit => Farads;

        public static Capacitance operator *(double left, CapacitanceUnit right)
        {
            return Capacitance.From(left, right);
        }

        public static bool operator ==(CapacitanceUnit left, CapacitanceUnit right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(CapacitanceUnit left, CapacitanceUnit right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Constructs a <see cref="CapacitanceUnit"/> from a string.
        /// Leading and trailing whitespace characters are allowed.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>An instance of <see cref="CapacitanceUnit"/></returns>
        public static CapacitanceUnit Parse(string text)
        {
            return UnitParser<CapacitanceUnit>.Parse(text);
        }

        public static bool TryParse(string text, out CapacitanceUnit value)
        {
            return UnitParser<CapacitanceUnit>.TryParse(text, out value);
        }

        /// <summary>
        /// Converts <paramref name="value"/> to Farads.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The converted value</returns>
        public double ToSiUnit(double value)
        {
            return this.toFarads(value);
        }

        /// <summary>
        /// Converts a value from farads.
        /// </summary>
        /// <param name="Farads">The value in Farads</param>
        /// <returns>The converted value</returns>
        public double FromSiUnit(double farads)
        {
            return this.fromFarads(farads);
        }

        /// <summary>
        /// Creates a quantity with this unit
        /// </summary>
        /// <param name="value">The scalar value"</param>
        /// <returns>new Capacitance(<paramref name="value"/>, this)</returns>
        public Capacitance CreateQuantity(double value)
        {
            return new Capacitance(value, this);
        }

        /// <summary>
        /// Gets the scalar value of <paramref name="quantity"/> in Farads
        /// </summary>
        /// <param name="quantity"></param>
        /// <returns></returns>
        public double GetScalarValue(Capacitance quantity)
        {
            return FromSiUnit(quantity.farads);
        }

        public override string ToString()
        {
            return this.symbol;
        }

        public string ToString(string format)
        {
            CapacitanceUnit unit;
            var paddedFormat = UnitFormatCache<CapacitanceUnit>.GetOrCreate(format, out unit);
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
            var paddedFormat = UnitFormatCache<CapacitanceUnit>.GetOrCreate(this, format);
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(paddedFormat.PrePadding);
                builder.Append(paddedFormat.Format);
                builder.Append(paddedFormat.PostPadding);
                return builder.ToString();
            }
        }

        public bool Equals(CapacitanceUnit other)
        {
            return this.symbol == other.symbol;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is CapacitanceUnit && Equals((CapacitanceUnit)obj);
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