namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Resistance"/>.
    /// </summary>
    [TypeConverter(typeof(ResistanceTypeConverter))]
    [Serializable]
    public partial struct Resistance : IQuantity<ResistanceUnit>, IComparable<Resistance>, IEquatable<Resistance>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.ResistanceUnit.Ohms"/>
        /// </summary>
        public static readonly Resistance Zero = default(Resistance);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.ResistanceUnit.Ohms"/>.
        /// </summary>
        internal readonly double ohms;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Resistance"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.ResistanceUnit"/>.</param>
        public Resistance(double value, ResistanceUnit unit)
        {
            this.ohms = unit.ToSiUnit(value);
        }

        private Resistance(double ohms)
        {
            this.ohms = ohms;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.ResistanceUnit.Ohms"/>
        /// </summary>
        public double SiValue => this.ohms;

        /// <summary>
        /// Gets the <see cref="Gu.Units.ResistanceUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public ResistanceUnit SiUnit => ResistanceUnit.Ohms;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => ResistanceUnit.Ohms;

        /// <summary>
        /// Gets the quantity in ohms".
        /// </summary>
        public double Ohms => this.ohms;

        /// <summary>
        /// Gets the quantity in Microohms
        /// </summary>
        public double Microohms => 1000000 * this.ohms;

        /// <summary>
        /// Gets the quantity in Milliohms
        /// </summary>
        public double Milliohms => 1000 * this.ohms;

        /// <summary>
        /// Gets the quantity in Kiloohms
        /// </summary>
        public double Kiloohms => this.ohms / 1000;

        /// <summary>
        /// Gets the quantity in Megaohms
        /// </summary>
        public double Megaohms => this.ohms / 1000000;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Inductance"/> that is the result from the multiplication.</returns>
        public static Inductance operator *(Resistance left, Time right)
        {
            return Inductance.FromHenrys(left.ohms * right.seconds);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the multiplication.</returns>
        public static Voltage operator *(Resistance left, Current right)
        {
            return Voltage.FromVolts(left.ohms * right.amperes);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Inductance"/> that is the result from the division.</returns>
        public static Inductance operator /(Resistance left, Frequency right)
        {
            return Inductance.FromHenrys(left.ohms / right.hertz);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFlux"/> that is the result from the multiplication.</returns>
        public static MagneticFlux operator *(Resistance left, ElectricCharge right)
        {
            return MagneticFlux.FromWebers(left.ohms * right.coulombs);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(Resistance left, Inductance right)
        {
            return Frequency.FromHertz(left.ohms / right.henrys);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the multiplication.</returns>
        public static Time operator *(Resistance left, Capacitance right)
        {
            return Time.FromSeconds(left.ohms * right.farads);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the multiplication.</returns>
        public static Wavenumber operator *(Resistance left, Conductivity right)
        {
            return Wavenumber.FromReciprocalMetres(left.ohms * right.siemensPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The ElectricalConductance that is the result from the division.</returns>
        public static ElectricalConductance operator /(double left, Resistance right)
        {
            return ElectricalConductance.FromSiemens(left / right.ohms);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Resistance left, Resistance right)
        {
            return left.ohms / right.ohms;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Resistance"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Resistance"/>.</param>
        public static bool operator ==(Resistance left, Resistance right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Resistance"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Resistance"/>.</param>
        public static bool operator !=(Resistance left, Resistance right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Resistance"/> is less than another specified <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Resistance"/>.</param>
        public static bool operator <(Resistance left, Resistance right)
        {
            return left.ohms < right.ohms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Resistance"/> is greater than another specified <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Resistance"/>.</param>
        public static bool operator >(Resistance left, Resistance right)
        {
            return left.ohms > right.ohms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Resistance"/> is less than or equal to another specified <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Resistance"/>.</param>
        public static bool operator <=(Resistance left, Resistance right)
        {
            return left.ohms <= right.ohms;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Resistance"/> is greater than or equal to another specified <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Resistance"/>.</param>
        public static bool operator >=(Resistance left, Resistance right)
        {
            return left.ohms >= right.ohms;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Resistance"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Resistance"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Resistance"/> and returns the result.</returns>
        public static Resistance operator *(double left, Resistance right)
        {
            return new Resistance(left * right.ohms);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Resistance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Resistance"/> with <paramref name="right"/> and returns the result.</returns>
        public static Resistance operator *(Resistance left, double right)
        {
            return new Resistance(left.ohms * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Resistance"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Resistance"/> by <paramref name="right"/> and returns the result.</returns>
        public static Resistance operator /(Resistance left, double right)
        {
            return new Resistance(left.ohms / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Resistance"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Resistance"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Resistance"/>.</param>
        public static Resistance operator +(Resistance left, Resistance right)
        {
            return new Resistance(left.ohms + right.ohms);
        }

        /// <summary>
        /// Subtracts an Resistance from another Resistance and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Resistance"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Resistance"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Resistance"/> (the subtrahend).</param>
        public static Resistance operator -(Resistance left, Resistance right)
        {
            return new Resistance(left.ohms - right.ohms);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Resistance"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Resistance"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="resistance">An instance of <see cref="Gu.Units.Resistance"/></param>
        public static Resistance operator -(Resistance resistance)
        {
            return new Resistance(-1 * resistance.ohms);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="resistance"/>.
        /// </returns>
        /// <param name="resistance">An instance of <see cref="Gu.Units.Resistance"/></param>
        public static Resistance operator +(Resistance resistance)
        {
            return resistance;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Resistance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Resistance"/></param>
        /// <returns>The <see cref="Gu.Units.Resistance"/> parsed from <paramref name="text"/></returns>
        public static Resistance Parse(string text)
        {
            return QuantityParser.Parse<ResistanceUnit, Resistance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Resistance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Resistance"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Resistance"/> parsed from <paramref name="text"/></returns>
        public static Resistance Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<ResistanceUnit, Resistance>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Resistance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Resistance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Resistance"/> parsed from <paramref name="text"/></returns>
        public static Resistance Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<ResistanceUnit, Resistance>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Resistance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Resistance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Resistance"/> parsed from <paramref name="text"/></returns>
        public static Resistance Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<ResistanceUnit, Resistance>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Resistance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Resistance"/></param>
        /// <param name="result">The parsed <see cref="Resistance"/></param>
        /// <returns>True if an instance of <see cref="Resistance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Resistance result)
        {
            return QuantityParser.TryParse<ResistanceUnit, Resistance>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Resistance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Resistance"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Resistance"/></param>
        /// <returns>True if an instance of <see cref="Resistance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Resistance result)
        {
            return QuantityParser.TryParse<ResistanceUnit, Resistance>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Resistance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Resistance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Resistance"/></param>
        /// <returns>True if an instance of <see cref="Resistance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Resistance result)
        {
            return QuantityParser.TryParse<ResistanceUnit, Resistance>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Resistance"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Resistance"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Resistance"/></param>
        /// <returns>True if an instance of <see cref="Resistance"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Resistance result)
        {
            return QuantityParser.TryParse<ResistanceUnit, Resistance>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Resistance"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Resistance"/></returns>
        public static Resistance ReadFrom(XmlReader reader)
        {
            var v = default(Resistance);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Resistance"/></returns>
        public static Resistance From(double value, ResistanceUnit unit)
        {
            return new Resistance(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="ohms">The value in <see cref="Gu.Units.ResistanceUnit.Ohms"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Resistance"/></returns>
        public static Resistance FromOhms(double ohms)
        {
            return new Resistance(ohms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="microohms">The value in \u00B5Ω.</param>
        /// <returns>An instance of <see cref="Gu.Units.Resistance"/></returns>
        public static Resistance FromMicroohms(double microohms)
        {
            return new Resistance(microohms / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="milliohms">The value in mΩ.</param>
        /// <returns>An instance of <see cref="Gu.Units.Resistance"/></returns>
        public static Resistance FromMilliohms(double milliohms)
        {
            return new Resistance(milliohms / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="kiloohms">The value in kΩ.</param>
        /// <returns>An instance of <see cref="Gu.Units.Resistance"/></returns>
        public static Resistance FromKiloohms(double kiloohms)
        {
            return new Resistance(1000 * kiloohms);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Resistance"/>.
        /// </summary>
        /// <param name="megaohms">The value in MΩ.</param>
        /// <returns>An instance of <see cref="Gu.Units.Resistance"/></returns>
        public static Resistance FromMegaohms(double megaohms)
        {
            return new Resistance(1000000 * megaohms);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(ResistanceUnit unit)
        {
            return unit.FromSiUnit(this.ohms);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Resistance"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Resistance"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 Ω\"</param>
        /// <returns>The string representation of the <see cref="Resistance"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 Ω\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Resistance"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex Ω</param>
        /// <returns>The string representation of the <see cref="Resistance"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex Ω</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="Resistance"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ResistanceUnit unit)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ResistanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ResistanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ResistanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ResistanceUnit unit)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ResistanceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ResistanceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, ResistanceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ResistanceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Resistance"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Resistance"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Resistance"/> object to compare to this instance.</param>
        public int CompareTo(Resistance quantity)
        {
            return this.ohms.CompareTo(quantity.ohms);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Resistance"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Resistance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Resistance"/> object to compare with this instance.</param>
        public bool Equals(Resistance other)
        {
            return this.ohms.Equals(other.ohms);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Resistance"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Resistance as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Resistance"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Resistance other, Resistance tolerance)
        {
            Ensure.GreaterThan(tolerance.ohms, 0, nameof(tolerance));
            return Math.Abs(this.ohms - other.ohms) < tolerance.ohms;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Resistance"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Resistance"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Resistance && this.Equals((Resistance)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.ohms.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "ohms", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.ohms);
        }

        internal string ToString(QuantityFormat<ResistanceUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}