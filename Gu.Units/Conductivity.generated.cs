namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Conductivity"/>.
    /// </summary>
    [TypeConverter(typeof(ConductivityTypeConverter))]
    [Serializable]
    public partial struct Conductivity : IQuantity<ConductivityUnit>, IComparable<Conductivity>, IEquatable<Conductivity>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.ConductivityUnit.SiemensPerMetre"/>
        /// </summary>
        public static readonly Conductivity Zero = default(Conductivity);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.ConductivityUnit.SiemensPerMetre"/>.
        /// </summary>
        internal readonly double siemensPerMetre;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Conductivity"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.ConductivityUnit"/>.</param>
        public Conductivity(double value, ConductivityUnit unit)
        {
            this.siemensPerMetre = unit.ToSiUnit(value);
        }

        private Conductivity(double siemensPerMetre)
        {
            this.siemensPerMetre = siemensPerMetre;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.ConductivityUnit.SiemensPerMetre"/>
        /// </summary>
        public double SiValue => this.siemensPerMetre;

        /// <summary>
        /// Gets the <see cref="Gu.Units.ConductivityUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public ConductivityUnit SiUnit => ConductivityUnit.SiemensPerMetre;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => ConductivityUnit.SiemensPerMetre;

        /// <summary>
        /// Gets the quantity in siemensPerMetre".
        /// </summary>
        public double SiemensPerMetre => this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in SiemensPerCentimetre
        /// </summary>
        public double SiemensPerCentimetre => this.siemensPerMetre / 100;

        /// <summary>
        /// Gets the quantity in SiemensPerMillimetre
        /// </summary>
        public double SiemensPerMillimetre => this.siemensPerMetre / 1000;

        /// <summary>
        /// Gets the quantity in NanosiemensPerMetre
        /// </summary>
        public double NanosiemensPerMetre => 1000000000 * this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in NanosiemensPerMicrometre
        /// </summary>
        public double NanosiemensPerMicrometre => 1000 * this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in NanosiemensPerMillimetre
        /// </summary>
        public double NanosiemensPerMillimetre => 1000000 * this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in NanosiemensPerCentimetre
        /// </summary>
        public double NanosiemensPerCentimetre => 10000000 * this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in MicrosiemensPerMetre
        /// </summary>
        public double MicrosiemensPerMetre => 1000000 * this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in MicrosiemensPerMillimetre
        /// </summary>
        public double MicrosiemensPerMillimetre => 1000 * this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in MicrosiemensPerCentimetre
        /// </summary>
        public double MicrosiemensPerCentimetre => 10000 * this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in MillisiemensPerMetre
        /// </summary>
        public double MillisiemensPerMetre => 1000 * this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in MillisiemensPerMillimetre
        /// </summary>
        public double MillisiemensPerMillimetre => this.siemensPerMetre;

        /// <summary>
        /// Gets the quantity in MillisiemensPerCentimetre
        /// </summary>
        public double MillisiemensPerCentimetre => 10 * this.siemensPerMetre;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricalConductance"/> that is the result from the multiplication.</returns>
        public static ElectricalConductance operator *(Conductivity left, Length right)
        {
            return ElectricalConductance.FromSiemens(left.siemensPerMetre * right.metres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the multiplication.</returns>
        public static Wavenumber operator *(Conductivity left, Resistance right)
        {
            return Wavenumber.FromReciprocalMetres(left.siemensPerMetre * right.ohms);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the division.</returns>
        public static Wavenumber operator /(Conductivity left, ElectricalConductance right)
        {
            return Wavenumber.FromReciprocalMetres(left.siemensPerMetre / right.siemens);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ElectricalConductance"/> that is the result from the division.</returns>
        public static ElectricalConductance operator /(Conductivity left, Wavenumber right)
        {
            return ElectricalConductance.FromSiemens(left.siemensPerMetre / right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Conductivity left, Conductivity right)
        {
            return left.siemensPerMetre / right.siemensPerMetre;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Conductivity"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Conductivity"/>.</param>
        public static bool operator ==(Conductivity left, Conductivity right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Conductivity"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Conductivity"/>.</param>
        public static bool operator !=(Conductivity left, Conductivity right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Conductivity"/> is less than another specified <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Conductivity"/>.</param>
        public static bool operator <(Conductivity left, Conductivity right)
        {
            return left.siemensPerMetre < right.siemensPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Conductivity"/> is greater than another specified <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Conductivity"/>.</param>
        public static bool operator >(Conductivity left, Conductivity right)
        {
            return left.siemensPerMetre > right.siemensPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Conductivity"/> is less than or equal to another specified <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Conductivity"/>.</param>
        public static bool operator <=(Conductivity left, Conductivity right)
        {
            return left.siemensPerMetre <= right.siemensPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Conductivity"/> is greater than or equal to another specified <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Conductivity"/>.</param>
        public static bool operator >=(Conductivity left, Conductivity right)
        {
            return left.siemensPerMetre >= right.siemensPerMetre;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Conductivity"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Conductivity"/> and returns the result.</returns>
        public static Conductivity operator *(double left, Conductivity right)
        {
            return new Conductivity(left * right.siemensPerMetre);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Conductivity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Conductivity"/> with <paramref name="right"/> and returns the result.</returns>
        public static Conductivity operator *(Conductivity left, double right)
        {
            return new Conductivity(left.siemensPerMetre * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Conductivity"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Conductivity"/> by <paramref name="right"/> and returns the result.</returns>
        public static Conductivity operator /(Conductivity left, double right)
        {
            return new Conductivity(left.siemensPerMetre / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Conductivity"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Conductivity"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Conductivity"/>.</param>
        public static Conductivity operator +(Conductivity left, Conductivity right)
        {
            return new Conductivity(left.siemensPerMetre + right.siemensPerMetre);
        }

        /// <summary>
        /// Subtracts an Conductivity from another Conductivity and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Conductivity"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Conductivity"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Conductivity"/> (the subtrahend).</param>
        public static Conductivity operator -(Conductivity left, Conductivity right)
        {
            return new Conductivity(left.siemensPerMetre - right.siemensPerMetre);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Conductivity"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Conductivity"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="conductivity">An instance of <see cref="Gu.Units.Conductivity"/></param>
        public static Conductivity operator -(Conductivity conductivity)
        {
            return new Conductivity(-1 * conductivity.siemensPerMetre);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="conductivity"/>.
        /// </returns>
        /// <param name="conductivity">An instance of <see cref="Gu.Units.Conductivity"/></param>
        public static Conductivity operator +(Conductivity conductivity)
        {
            return conductivity;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Conductivity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Conductivity"/></param>
        /// <returns>The <see cref="Gu.Units.Conductivity"/> parsed from <paramref name="text"/></returns>
        public static Conductivity Parse(string text)
        {
            return QuantityParser.Parse<ConductivityUnit, Conductivity>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Conductivity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Conductivity"/> parsed from <paramref name="text"/></returns>
        public static Conductivity Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<ConductivityUnit, Conductivity>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Conductivity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Conductivity"/> parsed from <paramref name="text"/></returns>
        public static Conductivity Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<ConductivityUnit, Conductivity>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Conductivity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Conductivity"/> parsed from <paramref name="text"/></returns>
        public static Conductivity Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<ConductivityUnit, Conductivity>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Conductivity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="result">The parsed <see cref="Conductivity"/></param>
        /// <returns>True if an instance of <see cref="Conductivity"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Conductivity result)
        {
            return QuantityParser.TryParse<ConductivityUnit, Conductivity>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Conductivity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Conductivity"/></param>
        /// <returns>True if an instance of <see cref="Conductivity"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Conductivity result)
        {
            return QuantityParser.TryParse<ConductivityUnit, Conductivity>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Conductivity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Conductivity"/></param>
        /// <returns>True if an instance of <see cref="Conductivity"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Conductivity result)
        {
            return QuantityParser.TryParse<ConductivityUnit, Conductivity>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Conductivity"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Conductivity"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Conductivity"/></param>
        /// <returns>True if an instance of <see cref="Conductivity"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Conductivity result)
        {
            return QuantityParser.TryParse<ConductivityUnit, Conductivity>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Conductivity"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity ReadFrom(XmlReader reader)
        {
            var v = default(Conductivity);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity From(double value, ConductivityUnit unit)
        {
            return new Conductivity(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="siemensPerMetre">The value in <see cref="Gu.Units.ConductivityUnit.SiemensPerMetre"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromSiemensPerMetre(double siemensPerMetre)
        {
            return new Conductivity(siemensPerMetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="siemensPerCentimetre">The value in S/cm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromSiemensPerCentimetre(double siemensPerCentimetre)
        {
            return new Conductivity(100 * siemensPerCentimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="siemensPerMillimetre">The value in S/mm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromSiemensPerMillimetre(double siemensPerMillimetre)
        {
            return new Conductivity(1000 * siemensPerMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="nanosiemensPerMetre">The value in nS/m.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromNanosiemensPerMetre(double nanosiemensPerMetre)
        {
            return new Conductivity(nanosiemensPerMetre / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="nanosiemensPerMicrometre">The value in nS/μm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromNanosiemensPerMicrometre(double nanosiemensPerMicrometre)
        {
            return new Conductivity(nanosiemensPerMicrometre / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="nanosiemensPerMillimetre">The value in nS/mm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromNanosiemensPerMillimetre(double nanosiemensPerMillimetre)
        {
            return new Conductivity(nanosiemensPerMillimetre / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="nanosiemensPerCentimetre">The value in nS/cm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromNanosiemensPerCentimetre(double nanosiemensPerCentimetre)
        {
            return new Conductivity(nanosiemensPerCentimetre / 10000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="microsiemensPerMetre">The value in μS/m.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromMicrosiemensPerMetre(double microsiemensPerMetre)
        {
            return new Conductivity(microsiemensPerMetre / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="microsiemensPerMillimetre">The value in μS/mm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromMicrosiemensPerMillimetre(double microsiemensPerMillimetre)
        {
            return new Conductivity(microsiemensPerMillimetre / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="microsiemensPerCentimetre">The value in μS/cm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromMicrosiemensPerCentimetre(double microsiemensPerCentimetre)
        {
            return new Conductivity(microsiemensPerCentimetre / 10000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="millisiemensPerMetre">The value in mS/m.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromMillisiemensPerMetre(double millisiemensPerMetre)
        {
            return new Conductivity(millisiemensPerMetre / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="millisiemensPerMillimetre">The value in mS/mm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromMillisiemensPerMillimetre(double millisiemensPerMillimetre)
        {
            return new Conductivity(millisiemensPerMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Conductivity"/>.
        /// </summary>
        /// <param name="millisiemensPerCentimetre">The value in mS/cm.</param>
        /// <returns>An instance of <see cref="Gu.Units.Conductivity"/></returns>
        public static Conductivity FromMillisiemensPerCentimetre(double millisiemensPerCentimetre)
        {
            return new Conductivity(millisiemensPerCentimetre / 10);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(ConductivityUnit unit)
        {
            return unit.FromSiUnit(this.siemensPerMetre);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Conductivity"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Conductivity"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 S/m\"</param>
        /// <returns>The string representation of the <see cref="Conductivity"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 S/m\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Conductivity"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex S/m</param>
        /// <returns>The string representation of the <see cref="Conductivity"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex S/m</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="Conductivity"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ConductivityUnit unit)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ConductivityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ConductivityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ConductivityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ConductivityUnit unit)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ConductivityUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ConductivityUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, ConductivityUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ConductivityUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Conductivity"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Conductivity"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Conductivity"/> object to compare to this instance.</param>
        public int CompareTo(Conductivity quantity)
        {
            return this.siemensPerMetre.CompareTo(quantity.siemensPerMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Conductivity"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Conductivity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Conductivity"/> object to compare with this instance.</param>
        public bool Equals(Conductivity other)
        {
            return this.siemensPerMetre.Equals(other.siemensPerMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Conductivity"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Conductivity as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Conductivity"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Conductivity other, Conductivity tolerance)
        {
            Ensure.GreaterThan(tolerance.siemensPerMetre, 0, nameof(tolerance));
            return Math.Abs(this.siemensPerMetre - other.siemensPerMetre) < tolerance.siemensPerMetre;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Conductivity"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Conductivity"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Conductivity && this.Equals((Conductivity)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.siemensPerMetre.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "siemensPerMetre", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.siemensPerMetre);
        }

        internal string ToString(QuantityFormat<ConductivityUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}