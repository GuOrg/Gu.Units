namespace Gu.Units
{
    using System;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Stiffness"/>.
    /// </summary>
    // [TypeConverter(typeof(StiffnessTypeConverter))]
    [Serializable]
    public partial struct Stiffness : IQuantity<StiffnessUnit>, IComparable<Stiffness>, IEquatable<Stiffness>
    {
        public static readonly Stiffness Zero = new Stiffness();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.StiffnessUnit.NewtonsPerMetre"/>.
        /// </summary>
        internal readonly double newtonsPerMetre;

        private Stiffness(double newtonsPerMetre)
        {
            this.newtonsPerMetre = newtonsPerMetre;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.StiffnessUnit"/>.</param>
        public Stiffness(double value, StiffnessUnit unit)
        {
            this.newtonsPerMetre = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.StiffnessUnit.NewtonsPerMetre"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.newtonsPerMetre;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.StiffnessUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public StiffnessUnit SiUnit => StiffnessUnit.NewtonsPerMetre;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => StiffnessUnit.NewtonsPerMetre;

        /// <summary>
        /// The quantity in newtonsPerMetre".
        /// </summary>
        public double NewtonsPerMetre
        {
            get
            {
                return this.newtonsPerMetre;
            }
        }

        /// <summary>
        /// The quantity in NewtonsPerNanometre
        /// </summary>
        public double NewtonsPerNanometre => this.newtonsPerMetre / 1000000000;

        /// <summary>
        /// The quantity in NewtonsPerMicrometre
        /// </summary>
        public double NewtonsPerMicrometre => this.newtonsPerMetre / 1000000;

        /// <summary>
        /// The quantity in NewtonsPerMillimetre
        /// </summary>
        public double NewtonsPerMillimetre => this.newtonsPerMetre / 1000;

        /// <summary>
        /// The quantity in KilonewtonsPerNanometre
        /// </summary>
        public double KilonewtonsPerNanometre => this.newtonsPerMetre / 1000000000000;

        /// <summary>
        /// The quantity in KilonewtonsPerMicrometre
        /// </summary>
        public double KilonewtonsPerMicrometre => this.newtonsPerMetre / 1000000000;

        /// <summary>
        /// The quantity in KilonewtonsPerMillimetre
        /// </summary>
        public double KilonewtonsPerMillimetre => this.newtonsPerMetre / 1000000;

        /// <summary>
        /// The quantity in MeganewtonsPerNanometre
        /// </summary>
        public double MeganewtonsPerNanometre => this.newtonsPerMetre / 1000000000000000;

        /// <summary>
        /// The quantity in MeganewtonsPerMicrometre
        /// </summary>
        public double MeganewtonsPerMicrometre => this.newtonsPerMetre / 1000000000000;

        /// <summary>
        /// The quantity in MeganewtonsPerMillimetre
        /// </summary>
        public double MeganewtonsPerMillimetre => this.newtonsPerMetre / 1000000000;

        /// <summary>
        /// The quantity in GiganewtonsPerMicrometre
        /// </summary>
        public double GiganewtonsPerMicrometre => this.newtonsPerMetre / 1000000000000000;

        /// <summary>
        /// The quantity in GiganewtonsPerMillimetre
        /// </summary>
        public double GiganewtonsPerMillimetre => this.newtonsPerMetre / 1000000000000;

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <returns></returns>
		public static Stiffness Parse(string text)
        {
            return QuantityParser.Parse<StiffnessUnit, Stiffness>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <returns></returns>
        public static Stiffness Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<StiffnessUnit, Stiffness>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <returns></returns>
        public static Stiffness Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<StiffnessUnit, Stiffness>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <returns></returns>
        public static Stiffness Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<StiffnessUnit, Stiffness>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out Stiffness result)
        {
            return QuantityParser.TryParse<StiffnessUnit, Stiffness>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out Stiffness result)
        {
            return QuantityParser.TryParse<StiffnessUnit, Stiffness>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out Stiffness result)
        {
            return QuantityParser.TryParse<StiffnessUnit, Stiffness>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Stiffness"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Stiffness"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Stiffness result)
        {
            return QuantityParser.TryParse<StiffnessUnit, Stiffness>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Stiffness"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.Stiffness"/></returns>
        public static Stiffness ReadFrom(XmlReader reader)
        {
            var v = new Stiffness();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static Stiffness From(double value, StiffnessUnit unit)
        {
            return new Stiffness(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="newtonsPerMetre">The value in <see cref="Gu.Units.StiffnessUnit.NewtonsPerMetre"/></param>
        public static Stiffness FromNewtonsPerMetre(double newtonsPerMetre)
        {
            return new Stiffness(newtonsPerMetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="newtonsPerNanometre">The value in N/nm</param>
        public static Stiffness FromNewtonsPerNanometre(double newtonsPerNanometre)
        {
            return new Stiffness(1000000000 * newtonsPerNanometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="newtonsPerMicrometre">The value in N/µm</param>
        public static Stiffness FromNewtonsPerMicrometre(double newtonsPerMicrometre)
        {
            return new Stiffness(1000000 * newtonsPerMicrometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="newtonsPerMillimetre">The value in N/mm</param>
        public static Stiffness FromNewtonsPerMillimetre(double newtonsPerMillimetre)
        {
            return new Stiffness(1000 * newtonsPerMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="kilonewtonsPerNanometre">The value in kN/nm</param>
        public static Stiffness FromKilonewtonsPerNanometre(double kilonewtonsPerNanometre)
        {
            return new Stiffness(1000000000000 * kilonewtonsPerNanometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="kilonewtonsPerMicrometre">The value in kN/µm</param>
        public static Stiffness FromKilonewtonsPerMicrometre(double kilonewtonsPerMicrometre)
        {
            return new Stiffness(1000000000 * kilonewtonsPerMicrometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="kilonewtonsPerMillimetre">The value in kN/mm</param>
        public static Stiffness FromKilonewtonsPerMillimetre(double kilonewtonsPerMillimetre)
        {
            return new Stiffness(1000000 * kilonewtonsPerMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="meganewtonsPerNanometre">The value in MN/nm</param>
        public static Stiffness FromMeganewtonsPerNanometre(double meganewtonsPerNanometre)
        {
            return new Stiffness(1000000000000000 * meganewtonsPerNanometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="meganewtonsPerMicrometre">The value in MN/µm</param>
        public static Stiffness FromMeganewtonsPerMicrometre(double meganewtonsPerMicrometre)
        {
            return new Stiffness(1000000000000 * meganewtonsPerMicrometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="meganewtonsPerMillimetre">The value in MN/mm</param>
        public static Stiffness FromMeganewtonsPerMillimetre(double meganewtonsPerMillimetre)
        {
            return new Stiffness(1000000000 * meganewtonsPerMillimetre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="giganewtonsPerMicrometre">The value in GN/µm</param>
        public static Stiffness FromGiganewtonsPerMicrometre(double giganewtonsPerMicrometre)
        {
            return new Stiffness(1000000000000000 * giganewtonsPerMicrometre);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <param name="giganewtonsPerMillimetre">The value in GN/mm</param>
        public static Stiffness FromGiganewtonsPerMillimetre(double giganewtonsPerMillimetre)
        {
            return new Stiffness(1000000000000 * giganewtonsPerMillimetre);
        }

        public static Force operator *(Stiffness left, Length right)
        {
            return Force.FromNewtons(left.newtonsPerMetre * right.metres);
        }

        public static Pressure operator /(Stiffness left, Length right)
        {
            return Pressure.FromPascals(left.newtonsPerMetre / right.metres);
        }

        public static MassFlow operator *(Stiffness left, Time right)
        {
            return MassFlow.FromKilogramsPerSecond(left.newtonsPerMetre * right.seconds);
        }

        public static MagneticFieldStrength operator /(Stiffness left, Current right)
        {
            return MagneticFieldStrength.FromTeslas(left.newtonsPerMetre / right.amperes);
        }

        public static Energy operator *(Stiffness left, Area right)
        {
            return Energy.FromJoules(left.newtonsPerMetre * right.squareMetres);
        }

        public static Wavenumber operator /(Stiffness left, Force right)
        {
            return Wavenumber.FromReciprocalMetres(left.newtonsPerMetre / right.newtons);
        }

        public static Length operator /(Stiffness left, Pressure right)
        {
            return Length.FromMetres(left.newtonsPerMetre / right.pascals);
        }

        public static MassFlow operator /(Stiffness left, Frequency right)
        {
            return MassFlow.FromKilogramsPerSecond(left.newtonsPerMetre / right.hertz);
        }

        public static AreaDensity operator /(Stiffness left, SpecificEnergy right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.newtonsPerMetre / right.joulesPerKilogram);
        }

        public static ForcePerUnitless operator *(Stiffness left, LengthPerUnitless right)
        {
            return ForcePerUnitless.FromNewtonsPerUnitless(left.newtonsPerMetre * right.metresPerUnitless);
        }

        public static Current operator /(Stiffness left, MagneticFieldStrength right)
        {
            return Current.FromAmperes(left.newtonsPerMetre / right.teslas);
        }

        public static Pressure operator *(Stiffness left, Wavenumber right)
        {
            return Pressure.FromPascals(left.newtonsPerMetre * right.reciprocalMetres);
        }

        public static Force operator /(Stiffness left, Wavenumber right)
        {
            return Force.FromNewtons(left.newtonsPerMetre / right.reciprocalMetres);
        }

        public static SpecificEnergy operator /(Stiffness left, AreaDensity right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.newtonsPerMetre / right.kilogramsPerSquareMetre);
        }

        public static Frequency operator /(Stiffness left, MassFlow right)
        {
            return Frequency.FromHertz(left.newtonsPerMetre / right.kilogramsPerSecond);
        }

        public static Power operator *(Stiffness left, KinematicViscosity right)
        {
            return Power.FromWatts(left.newtonsPerMetre * right.squareMetresPerSecond);
        }

        public static Flexibility operator /(double left, Stiffness right)
        {
            return Flexibility.FromMetresPerNewton(left / right.newtonsPerMetre);
        }

        public static double operator /(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre / right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Stiffness"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator ==(Stiffness left, Stiffness right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Stiffness"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator !=(Stiffness left, Stiffness right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Stiffness"/> is less than another specified <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator <(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre < right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Stiffness"/> is greater than another specified <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator >(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre > right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Stiffness"/> is less than or equal to another specified <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator <=(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre <= right.newtonsPerMetre;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Stiffness"/> is greater than or equal to another specified <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static bool operator >=(Stiffness left, Stiffness right)
        {
            return left.newtonsPerMetre >= right.newtonsPerMetre;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Stiffness"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Stiffness"/> with <paramref name="left"/> and returns the result.</returns>
        public static Stiffness operator *(double left, Stiffness right)
        {
            return new Stiffness(left * right.newtonsPerMetre);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.</returns>
        public static Stiffness operator *(Stiffness left, double right)
        {
            return new Stiffness(left.newtonsPerMetre * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Stiffness"/> with <paramref name="right"/> and returns the result.</returns>
        public static Stiffness operator /(Stiffness left, double right)
        {
            return new Stiffness(left.newtonsPerMetre / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Stiffness"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Stiffness"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Stiffness"/>.</param>
        public static Stiffness operator +(Stiffness left, Stiffness right)
        {
            return new Stiffness(left.newtonsPerMetre + right.newtonsPerMetre);
        }

        /// <summary>
        /// Subtracts an Stiffness from another Stiffness and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Stiffness"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.Stiffness"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.Stiffness"/> (the subtrahend).</param>
        public static Stiffness operator -(Stiffness left, Stiffness right)
        {
            return new Stiffness(left.newtonsPerMetre - right.newtonsPerMetre);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Stiffness"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Stiffness"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="stiffness">An instance of <see cref="Gu.Units.Stiffness"/></param>
        public static Stiffness operator -(Stiffness stiffness)
        {
            return new Stiffness(-1 * stiffness.newtonsPerMetre);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Stiffness"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="stiffness"/>.
        /// </returns>
        /// <param name="stiffness">An instance of <see cref="Gu.Units.Stiffness"/></param>
        public static Stiffness operator +(Stiffness stiffness)
        {
            return stiffness;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(StiffnessUnit unit)
        {
            return unit.FromSiUnit(this.newtonsPerMetre);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N/m\"</param>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N/m\"</param>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex N/m</param>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex N/m</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="Stiffness"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(StiffnessUnit unit)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(StiffnessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(StiffnessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(StiffnessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, StiffnessUnit unit)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, StiffnessUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, StiffnessUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, StiffnessUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<StiffnessUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<StiffnessUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Stiffness"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Stiffness"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Stiffness"/> object to compare to this instance.</param>
        public int CompareTo(Stiffness quantity)
        {
            return this.newtonsPerMetre.CompareTo(quantity.newtonsPerMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Stiffness"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Stiffness as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Stiffness"/> object to compare with this instance.</param>
        public bool Equals(Stiffness other)
        {
            return this.newtonsPerMetre.Equals(other.newtonsPerMetre);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Stiffness"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Stiffness as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Stiffness"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Stiffness other, Stiffness tolerance)
        {
            Ensure.GreaterThan(tolerance.newtonsPerMetre, 0, nameof(tolerance));
            return Math.Abs(this.newtonsPerMetre - other.newtonsPerMetre) < tolerance.newtonsPerMetre;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Stiffness && this.Equals((Stiffness)obj);
        }

        public override int GetHashCode()
        {
            return this.newtonsPerMetre.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "newtonsPerMetre", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.newtonsPerMetre);
        }
    }
}