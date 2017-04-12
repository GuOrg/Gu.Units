namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Capacitance"/>.
    /// </summary>
    [TypeConverter(typeof(CapacitanceTypeConverter))]
    [Serializable]
    public partial struct Capacitance : IQuantity<CapacitanceUnit>, IComparable<Capacitance>, IEquatable<Capacitance>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.CapacitanceUnit.Farads"/>
        /// </summary>
        public static readonly Capacitance Zero = default(Capacitance);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.CapacitanceUnit.Farads"/>.
        /// </summary>
        internal readonly double farads;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Capacitance"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.CapacitanceUnit"/>.</param>
        public Capacitance(double value, CapacitanceUnit unit)
        {
            this.farads = unit.ToSiUnit(value);
        }

        private Capacitance(double farads)
        {
            this.farads = farads;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.CapacitanceUnit.Farads"/>
        /// </summary>
        public double SiValue => this.farads;

        /// <summary>
        /// Gets the <see cref="Gu.Units.CapacitanceUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public CapacitanceUnit SiUnit => CapacitanceUnit.Farads;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => CapacitanceUnit.Farads;

        /// <summary>
        /// Gets the quantity in farads".
        /// </summary>
        public double Farads => this.farads;

        /// <summary>
        /// Gets the quantity in Nanofarads
        /// </summary>
        public double Nanofarads => 1000000000 * this.farads;

        /// <summary>
        /// Gets the quantity in Microfarads
        /// </summary>
        public double Microfarads => 1000000 * this.farads;

        /// <summary>
        /// Gets the quantity in Millifarads
        /// </summary>
        public double Millifarads => 1000 * this.farads;

        /// <summary>
        /// Gets the quantity in Kilofarads
        /// </summary>
        public double Kilofarads => this.farads / 1000;

        /// <summary>
        /// Gets the quantity in Megafarads
        /// </summary>
        public double Megafarads => this.farads / 1000000;

        /// <summary>
        /// Gets the quantity in Gigafarads
        /// </summary>
        public double Gigafarads => this.farads / 1000000000;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Capacitance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Capacitance"/></param>
        /// <returns>The <see cref="Gu.Units.Capacitance"/> parsed from <paramref name="text"/></returns>
        public static Capacitance Parse(string text)
        {
            return QuantityParser.Parse<CapacitanceUnit, Capacitance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Capacitance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Capacitance"/> parsed from <paramref name="text"/></returns>
        public static Capacitance Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<CapacitanceUnit, Capacitance>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Capacitance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Capacitance"/> parsed from <paramref name="text"/></returns>
        public static Capacitance Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<CapacitanceUnit, Capacitance>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Capacitance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Capacitance"/> parsed from <paramref name="text"/></returns>
        public static Capacitance Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<CapacitanceUnit, Capacitance>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Capacitance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="result">The parsed <see cref="Capacitance"/></param>
        /// <returns>True if an instance of <see cref="Capacitance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Capacitance result)
        {
            return QuantityParser.TryParse<CapacitanceUnit, Capacitance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Capacitance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Capacitance"/></param>
        /// <returns>True if an instance of <see cref="Capacitance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Capacitance result)
        {
            return QuantityParser.TryParse<CapacitanceUnit, Capacitance>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Capacitance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Capacitance"/></param>
        /// <returns>True if an instance of <see cref="Capacitance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Capacitance result)
        {
            return QuantityParser.TryParse<CapacitanceUnit, Capacitance>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Capacitance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Capacitance"/></param>
        /// <returns>True if an instance of <see cref="Capacitance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Capacitance result)
        {
            return QuantityParser.TryParse<CapacitanceUnit, Capacitance>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Capacitance"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Capacitance"/></returns>
        public static Capacitance ReadFrom(XmlReader reader)
        {
            var v = default(Capacitance);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Capacitance"/></returns>
        public static Capacitance From(double value, CapacitanceUnit unit)
        {
            return new Capacitance(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="farads">The value in <see cref="Gu.Units.CapacitanceUnit.Farads"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Capacitance"/></returns>
        public static Capacitance FromFarads(double farads)
        {
            return new Capacitance(farads);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="nanofarads">The value in nF</param>
        /// <returns>An instance of <see cref="Gu.Units.Capacitance"/></returns>
        public static Capacitance FromNanofarads(double nanofarads)
        {
            return new Capacitance(nanofarads / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="microfarads">The value in µF</param>
        /// <returns>An instance of <see cref="Gu.Units.Capacitance"/></returns>
        public static Capacitance FromMicrofarads(double microfarads)
        {
            return new Capacitance(microfarads / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="millifarads">The value in mF</param>
        /// <returns>An instance of <see cref="Gu.Units.Capacitance"/></returns>
        public static Capacitance FromMillifarads(double millifarads)
        {
            return new Capacitance(millifarads / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="kilofarads">The value in kF</param>
        /// <returns>An instance of <see cref="Gu.Units.Capacitance"/></returns>
        public static Capacitance FromKilofarads(double kilofarads)
        {
            return new Capacitance(1000 * kilofarads);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="megafarads">The value in MF</param>
        /// <returns>An instance of <see cref="Gu.Units.Capacitance"/></returns>
        public static Capacitance FromMegafarads(double megafarads)
        {
            return new Capacitance(1000000 * megafarads);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <param name="gigafarads">The value in GF</param>
        /// <returns>An instance of <see cref="Gu.Units.Capacitance"/></returns>
        public static Capacitance FromGigafarads(double gigafarads)
        {
            return new Capacitance(1000000000 * gigafarads);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricalConductance"/> that is the result from the division.</returns>
        public static ElectricalConductance operator /(Capacitance left, Time right)
        {
            return ElectricalConductance.FromSiemens(left.farads / right.seconds);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricalConductance"/> that is the result from the multiplication.</returns>
        public static ElectricalConductance operator *(Capacitance left, Frequency right)
        {
            return ElectricalConductance.FromSiemens(left.farads * right.hertz);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricCharge"/> that is the result from the multiplication.</returns>
        public static ElectricCharge operator *(Capacitance left, Voltage right)
        {
            return ElectricCharge.FromCoulombs(left.farads * right.volts);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the multiplication.</returns>
        public static Time operator *(Capacitance left, Resistance right)
        {
            return Time.FromSeconds(left.farads * right.ohms);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(Capacitance left, ElectricalConductance right)
        {
            return Time.FromSeconds(left.farads / right.siemens);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Capacitance left, Capacitance right)
        {
            return left.farads / right.farads;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Capacitance"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        public static bool operator ==(Capacitance left, Capacitance right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Capacitance"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        public static bool operator !=(Capacitance left, Capacitance right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Capacitance"/> is less than another specified <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        public static bool operator <(Capacitance left, Capacitance right)
        {
            return left.farads < right.farads;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Capacitance"/> is greater than another specified <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        public static bool operator >(Capacitance left, Capacitance right)
        {
            return left.farads > right.farads;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Capacitance"/> is less than or equal to another specified <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        public static bool operator <=(Capacitance left, Capacitance right)
        {
            return left.farads <= right.farads;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Capacitance"/> is greater than or equal to another specified <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        public static bool operator >=(Capacitance left, Capacitance right)
        {
            return left.farads >= right.farads;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Capacitance"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="left">An instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Capacitance"/> with <paramref name="left"/> and returns the result.</returns>
        public static Capacitance operator *(double left, Capacitance right)
        {
            return new Capacitance(left * right.farads);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Capacitance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="right">An instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Capacitance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Capacitance operator *(Capacitance left, double right)
        {
            return new Capacitance(left.farads * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Capacitance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/></param>
        /// <param name="right">An instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Capacitance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Capacitance operator /(Capacitance left, double right)
        {
            return new Capacitance(left.farads / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Capacitance"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Capacitance"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Capacitance"/>.</param>
        public static Capacitance operator +(Capacitance left, Capacitance right)
        {
            return new Capacitance(left.farads + right.farads);
        }

        /// <summary>
        /// Subtracts an Capacitance from another Capacitance and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Capacitance"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Capacitance"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Capacitance"/> (the subtrahend).</param>
        public static Capacitance operator -(Capacitance left, Capacitance right)
        {
            return new Capacitance(left.farads - right.farads);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Capacitance"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Capacitance"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="capacitance">An instance of <see cref="Gu.Units.Capacitance"/></param>
        public static Capacitance operator -(Capacitance capacitance)
        {
            return new Capacitance(-1 * capacitance.farads);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Capacitance"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="capacitance"/>.
        /// </returns>
        /// <param name="capacitance">An instance of <see cref="Gu.Units.Capacitance"/></param>
        public static Capacitance operator +(Capacitance capacitance)
        {
            return capacitance;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(CapacitanceUnit unit)
        {
            return unit.FromSiUnit(this.farads);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Capacitance"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Capacitance"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 F\"</param>
        /// <returns>The string representation of the <see cref="Capacitance"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 F\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Capacitance"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex F</param>
        /// <returns>The string representation of the <see cref="Capacitance"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex F</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Capacitance"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(CapacitanceUnit unit)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(CapacitanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(CapacitanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(CapacitanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, CapacitanceUnit unit)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, CapacitanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, CapacitanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creating the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, CapacitanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CapacitanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<CapacitanceUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Capacitance"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Capacitance"/> object.
        /// </summary>
        /// <returns>
        /// A signed number indicating the relative quantitys of this instance and <paramref name="quantity"/>.
        /// Value
        /// Description
        /// A negative integer
        /// This instance is smaller than <paramref name="quantity"/>.
        /// Zero
        /// This instance is equal to <paramref name="quantity"/>.
        /// A positive integer
        /// This instance is larger than <paramref name="quantity"/>.
        /// </returns>
        /// <param name="quantity">An instance of <see cref="Gu.Units.Capacitance"/> object to compare to this instance.</param>
        public int CompareTo(Capacitance quantity)
        {
            return this.farads.CompareTo(quantity.farads);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Capacitance"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Capacitance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Capacitance"/> object to compare with this instance.</param>
        public bool Equals(Capacitance other)
        {
            return this.farads.Equals(other.farads);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Capacitance"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Capacitance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Capacitance"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Capacitance other, Capacitance tolerance)
        {
            Ensure.GreaterThan(tolerance.farads, 0, nameof(tolerance));
            return Math.Abs(this.farads - other.farads) < tolerance.farads;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Capacitance"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Capacitance"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Capacitance && this.Equals((Capacitance)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.farads.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "farads", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.farads);
        }
    }
}