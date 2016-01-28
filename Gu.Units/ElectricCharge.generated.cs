namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.ElectricCharge"/>.
    /// </summary>
    // [TypeConverter(typeof(ElectricChargeTypeConverter))]
    [Serializable]
    public partial struct ElectricCharge : IQuantity<ElectricChargeUnit>, IComparable<ElectricCharge>, IEquatable<ElectricCharge>
    {
        public static readonly ElectricCharge Zero = new ElectricCharge();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.ElectricChargeUnit.Coulombs"/>.
        /// </summary>
        internal readonly double coulombs;

        private ElectricCharge(double coulombs)
        {
            this.coulombs = coulombs;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.ElectricChargeUnit"/>.</param>
        public ElectricCharge(double value, ElectricChargeUnit unit)
        {
            this.coulombs = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.ElectricChargeUnit.Coulombs"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.coulombs;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.ElectricChargeUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public ElectricChargeUnit SiUnit => ElectricChargeUnit.Coulombs;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => ElectricChargeUnit.Coulombs;

        /// <summary>
        /// The quantity in coulombs".
        /// </summary>
        public double Coulombs
        {
            get
            {
                return this.coulombs;
            }
        }

        /// <summary>
        /// The quantity in Nanocoulombs
        /// </summary>
        public double Nanocoulombs => 1000000000 * this.coulombs;

        /// <summary>
        /// The quantity in Microcoulombs
        /// </summary>
        public double Microcoulombs => 1000000 * this.coulombs;

        /// <summary>
        /// The quantity in Millicoulombs
        /// </summary>
        public double Millicoulombs => 1000 * this.coulombs;

        /// <summary>
        /// The quantity in Kilocoulombs
        /// </summary>
        public double Kilocoulombs => this.coulombs / 1000;

        /// <summary>
        /// The quantity in Megacoulombs
        /// </summary>
        public double Megacoulombs => this.coulombs / 1000000;

        /// <summary>
        /// The quantity in Gigacoulombs
        /// </summary>
        public double Gigacoulombs => this.coulombs / 1000000000;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricCharge"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricCharge"/></param>
        /// <returns></returns>
		public static ElectricCharge Parse(string text)
        {
            return QuantityParser.Parse<ElectricChargeUnit, ElectricCharge>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricCharge"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricCharge"/></param>
        /// <returns></returns>
        public static ElectricCharge Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<ElectricChargeUnit, ElectricCharge>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricCharge"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricCharge"/></param>
        /// <returns></returns>
        public static ElectricCharge Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<ElectricChargeUnit, ElectricCharge>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricCharge"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricCharge"/></param>
        /// <returns></returns>
        public static ElectricCharge Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<ElectricChargeUnit, ElectricCharge>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricCharge"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricCharge"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out ElectricCharge result)
        {
            return QuantityParser.TryParse<ElectricChargeUnit, ElectricCharge>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricCharge"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricCharge"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out ElectricCharge result)
        {
            return QuantityParser.TryParse<ElectricChargeUnit, ElectricCharge>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricCharge"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricCharge"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out ElectricCharge result)
        {
            return QuantityParser.TryParse<ElectricChargeUnit, ElectricCharge>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.ElectricCharge"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.ElectricCharge"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out ElectricCharge result)
        {
            return QuantityParser.TryParse<ElectricChargeUnit, ElectricCharge>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.ElectricCharge"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.ElectricCharge"/></returns>
        public static ElectricCharge ReadFrom(XmlReader reader)
        {
            var v = new ElectricCharge();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static ElectricCharge From(double value, ElectricChargeUnit unit)
        {
            return new ElectricCharge(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <param name="coulombs">The value in <see cref="Gu.Units.ElectricChargeUnit.Coulombs"/></param>
        public static ElectricCharge FromCoulombs(double coulombs)
        {
            return new ElectricCharge(coulombs);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <param name="nanocoulombs">The value in nC</param>
        public static ElectricCharge FromNanocoulombs(double nanocoulombs)
        {
            return new ElectricCharge(nanocoulombs / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <param name="microcoulombs">The value in µC</param>
        public static ElectricCharge FromMicrocoulombs(double microcoulombs)
        {
            return new ElectricCharge(microcoulombs / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <param name="millicoulombs">The value in mC</param>
        public static ElectricCharge FromMillicoulombs(double millicoulombs)
        {
            return new ElectricCharge(millicoulombs / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <param name="kilocoulombs">The value in kC</param>
        public static ElectricCharge FromKilocoulombs(double kilocoulombs)
        {
            return new ElectricCharge(1000 * kilocoulombs);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <param name="megacoulombs">The value in MC</param>
        public static ElectricCharge FromMegacoulombs(double megacoulombs)
        {
            return new ElectricCharge(1000000 * megacoulombs);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <param name="gigacoulombs">The value in GC</param>
        public static ElectricCharge FromGigacoulombs(double gigacoulombs)
        {
            return new ElectricCharge(1000000000 * gigacoulombs);
        }

        public static Current operator /(ElectricCharge left, Time right)
        {
            return Current.FromAmperes(left.coulombs / right.seconds);
        }

        public static Time operator /(ElectricCharge left, Current right)
        {
            return Time.FromSeconds(left.coulombs / right.amperes);
        }

        public static Current operator *(ElectricCharge left, Frequency right)
        {
            return Current.FromAmperes(left.coulombs * right.hertz);
        }

        public static Energy operator *(ElectricCharge left, Voltage right)
        {
            return Energy.FromJoules(left.coulombs * right.volts);
        }

        public static Capacitance operator /(ElectricCharge left, Voltage right)
        {
            return Capacitance.FromFarads(left.coulombs / right.volts);
        }

        public static MagneticFlux operator *(ElectricCharge left, Resistance right)
        {
            return MagneticFlux.FromWebers(left.coulombs * right.ohm);
        }

        public static Voltage operator /(ElectricCharge left, Capacitance right)
        {
            return Voltage.FromVolts(left.coulombs / right.farads);
        }

        public static ElectricalConductance operator /(ElectricCharge left, MagneticFlux right)
        {
            return ElectricalConductance.FromSiemens(left.coulombs / right.webers);
        }

        public static MagneticFlux operator /(ElectricCharge left, ElectricalConductance right)
        {
            return MagneticFlux.FromWebers(left.coulombs / right.siemens);
        }

        public static MassFlow operator *(ElectricCharge left, MagneticFieldStrength right)
        {
            return MassFlow.FromKilogramsPerSecond(left.coulombs * right.teslas);
        }

        public static double operator /(ElectricCharge left, ElectricCharge right)
        {
            return left.coulombs / right.coulombs;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ElectricCharge"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        public static bool operator ==(ElectricCharge left, ElectricCharge right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.ElectricCharge"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        public static bool operator !=(ElectricCharge left, ElectricCharge right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ElectricCharge"/> is less than another specified <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        public static bool operator <(ElectricCharge left, ElectricCharge right)
        {
            return left.coulombs < right.coulombs;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ElectricCharge"/> is greater than another specified <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        public static bool operator >(ElectricCharge left, ElectricCharge right)
        {
            return left.coulombs > right.coulombs;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ElectricCharge"/> is less than or equal to another specified <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        public static bool operator <=(ElectricCharge left, ElectricCharge right)
        {
            return left.coulombs <= right.coulombs;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.ElectricCharge"/> is greater than or equal to another specified <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        public static bool operator >=(ElectricCharge left, ElectricCharge right)
        {
            return left.coulombs >= right.coulombs;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.ElectricCharge"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricCharge"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.ElectricCharge"/> with <paramref name="left"/> and returns the result.</returns>
        public static ElectricCharge operator *(double left, ElectricCharge right)
        {
            return new ElectricCharge(left * right.coulombs);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.ElectricCharge"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.ElectricCharge"/> with <paramref name="right"/> and returns the result.</returns>
        public static ElectricCharge operator *(ElectricCharge left, double right)
        {
            return new ElectricCharge(left.coulombs * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.ElectricCharge"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.ElectricCharge"/> with <paramref name="right"/> and returns the result.</returns>
        public static ElectricCharge operator /(ElectricCharge left, double right)
        {
            return new ElectricCharge(left.coulombs / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.ElectricCharge"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ElectricCharge"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricCharge"/>.</param>
        public static ElectricCharge operator +(ElectricCharge left, ElectricCharge right)
        {
            return new ElectricCharge(left.coulombs + right.coulombs);
        }

        /// <summary>
        /// Subtracts an ElectricCharge from another ElectricCharge and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ElectricCharge"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.ElectricCharge"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.ElectricCharge"/> (the subtrahend).</param>
        public static ElectricCharge operator -(ElectricCharge left, ElectricCharge right)
        {
            return new ElectricCharge(left.coulombs - right.coulombs);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.ElectricCharge"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.ElectricCharge"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="electricCharge">An instance of <see cref="Gu.Units.ElectricCharge"/></param>
        public static ElectricCharge operator -(ElectricCharge electricCharge)
        {
            return new ElectricCharge(-1 * electricCharge.coulombs);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.ElectricCharge"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="electricCharge"/>.
        /// </returns>
        /// <param name="electricCharge">An instance of <see cref="Gu.Units.ElectricCharge"/></param>
        public static ElectricCharge operator +(ElectricCharge electricCharge)
        {
            return electricCharge;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(ElectricChargeUnit unit)
        {
            return unit.FromSiUnit(this.coulombs);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="ElectricCharge"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="ElectricCharge"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 C\"</param>
        /// <returns>The string representation of the <see cref="ElectricCharge"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 C\"</param>
        /// <returns>The string representation of the <see cref="ElectricCharge"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex C</param>
        /// <returns>The string representation of the <see cref="ElectricCharge"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex C</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="ElectricCharge"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(ElectricChargeUnit unit)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(ElectricChargeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(ElectricChargeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(ElectricChargeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, ElectricChargeUnit unit)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, ElectricChargeUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, ElectricChargeUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, ElectricChargeUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ElectricChargeUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<ElectricChargeUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.ElectricCharge"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.ElectricCharge"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// 
        ///                     Value
        /// 
        ///                     Description
        /// 
        ///                     A negative integer
        /// 
        ///                     This instance is smaller than <paramref name="quantity"/>.
        /// 
        ///                     Zero
        /// 
        ///                     This instance is equal to <paramref name="quantity"/>.
        /// 
        ///                     A positive integer
        /// 
        ///                     This instance is larger than <paramref name="quantity"/>.
        /// 
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.ElectricCharge"/> object to compare to this instance.</param>
        public int CompareTo(ElectricCharge quantity)
        {
            return this.coulombs.CompareTo(quantity.coulombs);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ElectricCharge"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ElectricCharge as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.ElectricCharge"/> object to compare with this instance.</param>
        public bool Equals(ElectricCharge other)
        {
            return this.coulombs.Equals(other.coulombs);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.ElectricCharge"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same ElectricCharge as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.ElectricCharge"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(ElectricCharge other, ElectricCharge tolerance)
        {
            Ensure.GreaterThan(tolerance.coulombs, 0, nameof(tolerance));
            return Math.Abs(this.coulombs - other.coulombs) < tolerance.coulombs;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is ElectricCharge && this.Equals((ElectricCharge)obj);
        }

        public override int GetHashCode()
        {
            return this.coulombs.GetHashCode();
        }

        /// <summary>
        /// This method is reserved and should not be used. When implementing the IXmlSerializable interface, 
        /// you should return null (Nothing in Visual Basic) from this method, and instead, 
        /// if specifying a custom schema is required, apply the <see cref="System.Xml.Serialization.XmlSchemaProviderAttribute"/> to the class.
        /// </summary>
        /// <returns>
        /// An <see cref="System.Xml.Schema.XmlSchema"/> that describes the XML representation of the object that is produced by the
        ///  <see cref="M:System.Xml.Serialization.IXmlSerializable.WriteXml(System.Xml.XmlWriter)"/> 
        /// method and consumed by the <see cref="M:System.Xml.Serialization.IXmlSerializable.ReadXml(System.Xml.XmlReader)"/> method.
        /// </returns>
        public XmlSchema GetSchema()
        {
            return null;
        }

        /// <summary>
        /// Generates an object from its XML representation.
        /// </summary>
        /// <param name="reader">The <see cref="System.Xml.XmlReader"/> stream from which the object is deserialized. </param>
        public void ReadXml(XmlReader reader)
        {
            // Hacking set readonly fields here, can't think of a cleaner workaround
            XmlExt.SetReadonlyField(ref this, "coulombs", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.coulombs);
        }
    }
}