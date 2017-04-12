namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Current"/>.
    /// </summary>
    [TypeConverter(typeof(CurrentTypeConverter))]
    [Serializable]
    public partial struct Current : IQuantity<CurrentUnit>, IComparable<Current>, IEquatable<Current>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.CurrentUnit.Amperes"/>
        /// </summary>
        public static readonly Current Zero = default(Current);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.CurrentUnit.Amperes"/>.
        /// </summary>
        internal readonly double amperes;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Current"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.CurrentUnit"/>.</param>
        public Current(double value, CurrentUnit unit)
        {
            this.amperes = unit.ToSiUnit(value);
        }

        private Current(double amperes)
        {
            this.amperes = amperes;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.CurrentUnit.Amperes"/>
        /// </summary>
        public double SiValue => this.amperes;

        /// <summary>
        /// Gets the <see cref="Gu.Units.CurrentUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public CurrentUnit SiUnit => CurrentUnit.Amperes;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => CurrentUnit.Amperes;

        /// <summary>
        /// Gets the quantity in amperes".
        /// </summary>
        public double Amperes => this.amperes;

        /// <summary>
        /// Gets the quantity in Milliamperes
        /// </summary>
        public double Milliamperes => 1000 * this.amperes;

        /// <summary>
        /// Gets the quantity in Kiloamperes
        /// </summary>
        public double Kiloamperes => this.amperes / 1000;

        /// <summary>
        /// Gets the quantity in Megaamperes
        /// </summary>
        public double Megaamperes => this.amperes / 1000000;

        /// <summary>
        /// Gets the quantity in Microamperes
        /// </summary>
        public double Microamperes => 1000000 * this.amperes;

        /// <summary>
        /// Gets the quantity in Nanoamperes
        /// </summary>
        public double Nanoamperes => 1000000000 * this.amperes;

        /// <summary>
        /// Gets the quantity in Gigaamperes
        /// </summary>
        public double Gigaamperes => this.amperes / 1000000000;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricCharge"/> that is the result from the multiplication.</returns>
        public static ElectricCharge operator *(Current left, Time right)
        {
            return ElectricCharge.FromCoulombs(left.amperes * right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricCharge"/> that is the result from the division.</returns>
        public static ElectricCharge operator /(Current left, Frequency right)
        {
            return ElectricCharge.FromCoulombs(left.amperes / right.hertz);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(Current left, Voltage right)
        {
            return Power.FromWatts(left.amperes * right.volts);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricalConductance"/> that is the result from the division.</returns>
        public static ElectricalConductance operator /(Current left, Voltage right)
        {
            return ElectricalConductance.FromSiemens(left.amperes / right.volts);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the multiplication.</returns>
        public static Voltage operator *(Current left, Resistance right)
        {
            return Voltage.FromVolts(left.amperes * right.ohms);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(Current left, ElectricCharge right)
        {
            return Frequency.FromHertz(left.amperes / right.coulombs);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MagneticFlux"/> that is the result from the multiplication.</returns>
        public static MagneticFlux operator *(Current left, Inductance right)
        {
            return MagneticFlux.FromWebers(left.amperes * right.henrys);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Current left, MagneticFlux right)
        {
            return Energy.FromJoules(left.amperes * right.webers);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the division.</returns>
        public static Voltage operator /(Current left, ElectricalConductance right)
        {
            return Voltage.FromVolts(left.amperes / right.siemens);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the multiplication.</returns>
        public static Stiffness operator *(Current left, MagneticFieldStrength right)
        {
            return Stiffness.FromNewtonsPerMetre(left.amperes * right.teslas);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Current left, Current right)
        {
            return left.amperes / right.amperes;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Current"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator ==(Current left, Current right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Current"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator !=(Current left, Current right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Current"/> is less than another specified <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator <(Current left, Current right)
        {
            return left.amperes < right.amperes;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Current"/> is greater than another specified <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator >(Current left, Current right)
        {
            return left.amperes > right.amperes;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Current"/> is less than or equal to another specified <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator <=(Current left, Current right)
        {
            return left.amperes <= right.amperes;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Current"/> is greater than or equal to another specified <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Current"/>.</param>
        public static bool operator >=(Current left, Current right)
        {
            return left.amperes >= right.amperes;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Current"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Current"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Current"/> and returns the result.</returns>
        public static Current operator *(double left, Current right)
        {
            return new Current(left * right.amperes);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Current"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Current"/> with <paramref name="right"/> and returns the result.</returns>
        public static Current operator *(Current left, double right)
        {
            return new Current(left.amperes * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Current"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Current"/> by <paramref name="right"/> and returns the result.</returns>
        public static Current operator /(Current left, double right)
        {
            return new Current(left.amperes / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Current"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Current"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Current"/>.</param>
        public static Current operator +(Current left, Current right)
        {
            return new Current(left.amperes + right.amperes);
        }

        /// <summary>
        /// Subtracts an Current from another Current and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Current"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Current"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Current"/> (the subtrahend).</param>
        public static Current operator -(Current left, Current right)
        {
            return new Current(left.amperes - right.amperes);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Current"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Current"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="current">An instance of <see cref="Gu.Units.Current"/></param>
        public static Current operator -(Current current)
        {
            return new Current(-1 * current.amperes);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="current"/>.
        /// </returns>
        /// <param name="current">An instance of <see cref="Gu.Units.Current"/></param>
        public static Current operator +(Current current)
        {
            return current;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Current"/></param>
        /// <returns>The <see cref="Gu.Units.Current"/> parsed from <paramref name="text"/></returns>
        public static Current Parse(string text)
        {
            return QuantityParser.Parse<CurrentUnit, Current>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Current"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Current"/> parsed from <paramref name="text"/></returns>
        public static Current Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<CurrentUnit, Current>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Current"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Current"/> parsed from <paramref name="text"/></returns>
        public static Current Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<CurrentUnit, Current>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Current"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Current"/> parsed from <paramref name="text"/></returns>
        public static Current Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<CurrentUnit, Current>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Current"/></param>
        /// <param name="result">The parsed <see cref="Current"/></param>
        /// <returns>True if an instance of <see cref="Current"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Current result)
        {
            return QuantityParser.TryParse<CurrentUnit, Current>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Current"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Current"/></param>
        /// <returns>True if an instance of <see cref="Current"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Current result)
        {
            return QuantityParser.TryParse<CurrentUnit, Current>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Current"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Current"/></param>
        /// <returns>True if an instance of <see cref="Current"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Current result)
        {
            return QuantityParser.TryParse<CurrentUnit, Current>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Current"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Current"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Current"/></param>
        /// <returns>True if an instance of <see cref="Current"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Current result)
        {
            return QuantityParser.TryParse<CurrentUnit, Current>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Current"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Current"/></returns>
        public static Current ReadFrom(XmlReader reader)
        {
            var v = default(Current);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Current"/></returns>
        public static Current From(double value, CurrentUnit unit)
        {
            return new Current(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="amperes">The value in <see cref="Gu.Units.CurrentUnit.Amperes"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Current"/></returns>
        public static Current FromAmperes(double amperes)
        {
            return new Current(amperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="milliamperes">The value in mA.</param>
        /// <returns>An instance of <see cref="Gu.Units.Current"/></returns>
        public static Current FromMilliamperes(double milliamperes)
        {
            return new Current(milliamperes / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="kiloamperes">The value in kA.</param>
        /// <returns>An instance of <see cref="Gu.Units.Current"/></returns>
        public static Current FromKiloamperes(double kiloamperes)
        {
            return new Current(1000 * kiloamperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="megaamperes">The value in MA.</param>
        /// <returns>An instance of <see cref="Gu.Units.Current"/></returns>
        public static Current FromMegaamperes(double megaamperes)
        {
            return new Current(1000000 * megaamperes);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="microamperes">The value in µA.</param>
        /// <returns>An instance of <see cref="Gu.Units.Current"/></returns>
        public static Current FromMicroamperes(double microamperes)
        {
            return new Current(microamperes / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="nanoamperes">The value in nA.</param>
        /// <returns>An instance of <see cref="Gu.Units.Current"/></returns>
        public static Current FromNanoamperes(double nanoamperes)
        {
            return new Current(nanoamperes / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Current"/>.
        /// </summary>
        /// <param name="gigaamperes">The value in GA.</param>
        /// <returns>An instance of <see cref="Gu.Units.Current"/></returns>
        public static Current FromGigaamperes(double gigaamperes)
        {
            return new Current(1000000000 * gigaamperes);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(CurrentUnit unit)
        {
            return unit.FromSiUnit(this.amperes);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 A\"</param>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 A\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex A</param>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex A</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="Current"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(CurrentUnit unit)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(CurrentUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(CurrentUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(CurrentUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, CurrentUnit unit)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, CurrentUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, CurrentUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, CurrentUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<CurrentUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Current"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Current"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Current"/> object to compare to this instance.</param>
        public int CompareTo(Current quantity)
        {
            return this.amperes.CompareTo(quantity.amperes);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Current"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Current as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Current"/> object to compare with this instance.</param>
        public bool Equals(Current other)
        {
            return this.amperes.Equals(other.amperes);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Current"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Current as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Current"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Current other, Current tolerance)
        {
            Ensure.GreaterThan(tolerance.amperes, 0, nameof(tolerance));
            return Math.Abs(this.amperes - other.amperes) < tolerance.amperes;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Current"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Current"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Current && this.Equals((Current)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.amperes.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "amperes", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.amperes);
        }

        internal string ToString(QuantityFormat<CurrentUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}