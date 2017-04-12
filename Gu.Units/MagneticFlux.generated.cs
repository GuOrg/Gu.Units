namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.MagneticFlux"/>.
    /// </summary>
    [TypeConverter(typeof(MagneticFluxTypeConverter))]
    [Serializable]
    public partial struct MagneticFlux : IQuantity<MagneticFluxUnit>, IComparable<MagneticFlux>, IEquatable<MagneticFlux>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.MagneticFluxUnit.Webers"/>
        /// </summary>
        public static readonly MagneticFlux Zero = default(MagneticFlux);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.MagneticFluxUnit.Webers"/>.
        /// </summary>
        internal readonly double webers;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.MagneticFlux"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.MagneticFluxUnit"/>.</param>
        public MagneticFlux(double value, MagneticFluxUnit unit)
        {
            this.webers = unit.ToSiUnit(value);
        }

        private MagneticFlux(double webers)
        {
            this.webers = webers;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.MagneticFluxUnit.Webers"/>
        /// </summary>
        public double SiValue => this.webers;

        /// <summary>
        /// Gets the <see cref="Gu.Units.MagneticFluxUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public MagneticFluxUnit SiUnit => MagneticFluxUnit.Webers;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => MagneticFluxUnit.Webers;

        /// <summary>
        /// Gets the quantity in webers".
        /// </summary>
        public double Webers => this.webers;

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the division.</returns>
        public static Voltage operator /(MagneticFlux left, Time right)
        {
            return Voltage.FromVolts(left.webers / right.seconds);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(MagneticFlux left, Current right)
        {
            return Energy.FromJoules(left.webers * right.amperes);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Inductance"/> that is the result from the division.</returns>
        public static Inductance operator /(MagneticFlux left, Current right)
        {
            return Inductance.FromHenrys(left.webers / right.amperes);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFieldStrength"/> that is the result from the division.</returns>
        public static MagneticFieldStrength operator /(MagneticFlux left, Area right)
        {
            return MagneticFieldStrength.FromTeslas(left.webers / right.squareMetres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the multiplication.</returns>
        public static Voltage operator *(MagneticFlux left, Frequency right)
        {
            return Voltage.FromVolts(left.webers * right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Time"/> that is the result from the division.</returns>
        public static Time operator /(MagneticFlux left, Voltage right)
        {
            return Time.FromSeconds(left.webers / right.volts);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricCharge"/> that is the result from the division.</returns>
        public static ElectricCharge operator /(MagneticFlux left, Resistance right)
        {
            return ElectricCharge.FromCoulombs(left.webers / right.ohms);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Resistance"/> that is the result from the division.</returns>
        public static Resistance operator /(MagneticFlux left, ElectricCharge right)
        {
            return Resistance.FromOhms(left.webers / right.coulombs);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Current"/> that is the result from the division.</returns>
        public static Current operator /(MagneticFlux left, Inductance right)
        {
            return Current.FromAmperes(left.webers / right.henrys);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricCharge"/> that is the result from the multiplication.</returns>
        public static ElectricCharge operator *(MagneticFlux left, ElectricalConductance right)
        {
            return ElectricCharge.FromCoulombs(left.webers * right.siemens);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the division.</returns>
        public static Area operator /(MagneticFlux left, MagneticFieldStrength right)
        {
            return Area.FromSquareMetres(left.webers / right.teslas);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(MagneticFlux left, MagneticFlux right)
        {
            return left.webers / right.webers;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MagneticFlux"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        public static bool operator ==(MagneticFlux left, MagneticFlux right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MagneticFlux"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        public static bool operator !=(MagneticFlux left, MagneticFlux right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MagneticFlux"/> is less than another specified <see cref="Gu.Units.MagneticFlux"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        public static bool operator <(MagneticFlux left, MagneticFlux right)
        {
            return left.webers < right.webers;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MagneticFlux"/> is greater than another specified <see cref="Gu.Units.MagneticFlux"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        public static bool operator >(MagneticFlux left, MagneticFlux right)
        {
            return left.webers > right.webers;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MagneticFlux"/> is less than or equal to another specified <see cref="Gu.Units.MagneticFlux"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        public static bool operator <=(MagneticFlux left, MagneticFlux right)
        {
            return left.webers <= right.webers;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MagneticFlux"/> is greater than or equal to another specified <see cref="Gu.Units.MagneticFlux"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        public static bool operator >=(MagneticFlux left, MagneticFlux right)
        {
            return left.webers >= right.webers;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MagneticFlux"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.MagneticFlux"/> and returns the result.</returns>
        public static MagneticFlux operator *(double left, MagneticFlux right)
        {
            return new MagneticFlux(left * right.webers);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MagneticFlux"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.MagneticFlux"/> with <paramref name="right"/> and returns the result.</returns>
        public static MagneticFlux operator *(MagneticFlux left, double right)
        {
            return new MagneticFlux(left.webers * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.MagneticFlux"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.MagneticFlux"/> by <paramref name="right"/> and returns the result.</returns>
        public static MagneticFlux operator /(MagneticFlux left, double right)
        {
            return new MagneticFlux(left.webers / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.MagneticFlux"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MagneticFlux"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFlux"/>.</param>
        public static MagneticFlux operator +(MagneticFlux left, MagneticFlux right)
        {
            return new MagneticFlux(left.webers + right.webers);
        }

        /// <summary>
        /// Subtracts an MagneticFlux from another MagneticFlux and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MagneticFlux"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.MagneticFlux"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.MagneticFlux"/> (the subtrahend).</param>
        public static MagneticFlux operator -(MagneticFlux left, MagneticFlux right)
        {
            return new MagneticFlux(left.webers - right.webers);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.MagneticFlux"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MagneticFlux"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="magneticFlux">An instance of <see cref="Gu.Units.MagneticFlux"/></param>
        public static MagneticFlux operator -(MagneticFlux magneticFlux)
        {
            return new MagneticFlux(-1 * magneticFlux.webers);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.MagneticFlux"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="magneticFlux"/>.
        /// </returns>
        /// <param name="magneticFlux">An instance of <see cref="Gu.Units.MagneticFlux"/></param>
        public static MagneticFlux operator +(MagneticFlux magneticFlux)
        {
            return magneticFlux;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFlux"/></param>
        /// <returns>The <see cref="Gu.Units.MagneticFlux"/> parsed from <paramref name="text"/></returns>
        public static MagneticFlux Parse(string text)
        {
            return QuantityParser.Parse<MagneticFluxUnit, MagneticFlux>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.MagneticFlux"/> parsed from <paramref name="text"/></returns>
        public static MagneticFlux Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<MagneticFluxUnit, MagneticFlux>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.MagneticFlux"/> parsed from <paramref name="text"/></returns>
        public static MagneticFlux Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<MagneticFluxUnit, MagneticFlux>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.MagneticFlux"/> parsed from <paramref name="text"/></returns>
        public static MagneticFlux Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<MagneticFluxUnit, MagneticFlux>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="result">The parsed <see cref="MagneticFlux"/></param>
        /// <returns>True if an instance of <see cref="MagneticFlux"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out MagneticFlux result)
        {
            return QuantityParser.TryParse<MagneticFluxUnit, MagneticFlux>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="MagneticFlux"/></param>
        /// <returns>True if an instance of <see cref="MagneticFlux"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out MagneticFlux result)
        {
            return QuantityParser.TryParse<MagneticFluxUnit, MagneticFlux>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="MagneticFlux"/></param>
        /// <returns>True if an instance of <see cref="MagneticFlux"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out MagneticFlux result)
        {
            return QuantityParser.TryParse<MagneticFluxUnit, MagneticFlux>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MagneticFlux"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MagneticFlux"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="MagneticFlux"/></param>
        /// <returns>True if an instance of <see cref="MagneticFlux"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out MagneticFlux result)
        {
            return QuantityParser.TryParse<MagneticFluxUnit, MagneticFlux>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.MagneticFlux"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.MagneticFlux"/></returns>
        public static MagneticFlux ReadFrom(XmlReader reader)
        {
            var v = default(MagneticFlux);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MagneticFlux"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.MagneticFlux"/></returns>
        public static MagneticFlux From(double value, MagneticFluxUnit unit)
        {
            return new MagneticFlux(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MagneticFlux"/>.
        /// </summary>
        /// <param name="webers">The value in <see cref="Gu.Units.MagneticFluxUnit.Webers"/></param>
        /// <returns>An instance of <see cref="Gu.Units.MagneticFlux"/></returns>
        public static MagneticFlux FromWebers(double webers)
        {
            return new MagneticFlux(webers);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MagneticFluxUnit unit)
        {
            return unit.FromSiUnit(this.webers);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="MagneticFlux"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="MagneticFlux"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 Wb\"</param>
        /// <returns>The string representation of the <see cref="MagneticFlux"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 Wb\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="MagneticFlux"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex Wb</param>
        /// <returns>The string representation of the <see cref="MagneticFlux"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex Wb</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="MagneticFlux"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MagneticFluxUnit unit)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MagneticFluxUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MagneticFluxUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(MagneticFluxUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MagneticFluxUnit unit)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MagneticFluxUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, MagneticFluxUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, MagneticFluxUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MagneticFluxUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.MagneticFlux"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.MagneticFlux"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.MagneticFlux"/> object to compare to this instance.</param>
        public int CompareTo(MagneticFlux quantity)
        {
            return this.webers.CompareTo(quantity.webers);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MagneticFlux"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MagneticFlux as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MagneticFlux"/> object to compare with this instance.</param>
        public bool Equals(MagneticFlux other)
        {
            return this.webers.Equals(other.webers);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MagneticFlux"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MagneticFlux as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MagneticFlux"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(MagneticFlux other, MagneticFlux tolerance)
        {
            Ensure.GreaterThan(tolerance.webers, 0, nameof(tolerance));
            return Math.Abs(this.webers - other.webers) < tolerance.webers;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MagneticFlux"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.MagneticFlux"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MagneticFlux && this.Equals((MagneticFlux)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.webers.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "webers", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.webers);
        }

        internal string ToString(QuantityFormat<MagneticFluxUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}