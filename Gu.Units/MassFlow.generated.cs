namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.MassFlow"/>.
    /// </summary>
    [TypeConverter(typeof(MassFlowTypeConverter))]
    [Serializable]
    public partial struct MassFlow : IQuantity<MassFlowUnit>, IComparable<MassFlow>, IEquatable<MassFlow>
    {
        public static readonly MassFlow Zero = new MassFlow();

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MassFlowUnit.KilogramsPerSecond"/>.
        /// </summary>
        internal readonly double kilogramsPerSecond;

        private MassFlow(double kilogramsPerSecond)
        {
            this.kilogramsPerSecond = kilogramsPerSecond;
        }

        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"><see cref="Gu.Units.MassFlowUnit"/>.</param>
        public MassFlow(double value, MassFlowUnit unit)
        {
            this.kilogramsPerSecond = unit.ToSiUnit(value);
        }

        /// <summary>
        /// The quantity in <see cref="Gu.Units.MassFlowUnit.KilogramsPerSecond"/>
        /// </summary>
        public double SiValue
        {
            get
            {
                return this.kilogramsPerSecond;
            }
        }

        /// <summary>
        /// The <see cref="Gu.Units.MassFlowUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public MassFlowUnit SiUnit => MassFlowUnit.KilogramsPerSecond;

        /// <summary>
        /// The <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => MassFlowUnit.KilogramsPerSecond;

        /// <summary>
        /// The quantity in kilogramsPerSecond".
        /// </summary>
        public double KilogramsPerSecond
        {
            get
            {
                return this.kilogramsPerSecond;
            }
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <returns></returns>
		public static MassFlow Parse(string text)
        {
            return QuantityParser.Parse<MassFlowUnit, MassFlow>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <returns></returns>
        public static MassFlow Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<MassFlowUnit, MassFlow>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <returns></returns>
        public static MassFlow Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<MassFlowUnit, MassFlow>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <returns></returns>
        public static MassFlow Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<MassFlowUnit, MassFlow>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, out MassFlow result)
        {
            return QuantityParser.TryParse<MassFlowUnit, MassFlow>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <returns></returns>		
        public static bool TryParse(string text, IFormatProvider provider, out MassFlow result)
        {
            return QuantityParser.TryParse<MassFlowUnit, MassFlow>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, out MassFlow result)
        {
            return QuantityParser.TryParse<MassFlowUnit, MassFlow>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.MassFlow"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.MassFlow"/></param>
        /// <returns></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out MassFlow result)
        {
            return QuantityParser.TryParse<MassFlowUnit, MassFlow>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.MassFlow"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>An instance of  <see cref="Gu.Units.MassFlow"/></returns>
        public static MassFlow ReadFrom(XmlReader reader)
        {
            var v = new MassFlow();
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="unit"></param>
        public static MassFlow From(double value, MassFlowUnit unit)
        {
            return new MassFlow(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <param name="kilogramsPerSecond">The value in <see cref="Gu.Units.MassFlowUnit.KilogramsPerSecond"/></param>
        public static MassFlow FromKilogramsPerSecond(double kilogramsPerSecond)
        {
            return new MassFlow(kilogramsPerSecond);
        }

        public static Frequency operator /(MassFlow left, Mass right)
        {
            return Frequency.FromHertz(left.kilogramsPerSecond / right.kilograms);
        }

        public static Momentum operator *(MassFlow left, Length right)
        {
            return Momentum.FromNewtonSecond(left.kilogramsPerSecond * right.metres);
        }

        public static Mass operator *(MassFlow left, Time right)
        {
            return Mass.FromKilograms(left.kilogramsPerSecond * right.seconds);
        }

        public static Stiffness operator /(MassFlow left, Time right)
        {
            return Stiffness.FromNewtonsPerMetre(left.kilogramsPerSecond / right.seconds);
        }

        public static VolumetricFlow operator /(MassFlow left, Density right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.kilogramsPerSecond / right.kilogramsPerCubicMetre);
        }

        public static Force operator *(MassFlow left, Speed right)
        {
            return Force.FromNewtons(left.kilogramsPerSecond * right.metresPerSecond);
        }

        public static Stiffness operator *(MassFlow left, Frequency right)
        {
            return Stiffness.FromNewtonsPerMetre(left.kilogramsPerSecond * right.hertz);
        }

        public static Mass operator /(MassFlow left, Frequency right)
        {
            return Mass.FromKilograms(left.kilogramsPerSecond / right.hertz);
        }

        public static Time operator /(MassFlow left, Stiffness right)
        {
            return Time.FromSeconds(left.kilogramsPerSecond / right.newtonsPerMetre);
        }

        public static Density operator /(MassFlow left, VolumetricFlow right)
        {
            return Density.FromKilogramsPerCubicMetre(left.kilogramsPerSecond / right.cubicMetresPerSecond);
        }

        public static Power operator *(MassFlow left, SpecificEnergy right)
        {
            return Power.FromWatts(left.kilogramsPerSecond * right.joulesPerKilogram);
        }

        public static MagneticFieldStrength operator /(MassFlow left, ElectricCharge right)
        {
            return MagneticFieldStrength.FromTeslas(left.kilogramsPerSecond / right.coulombs);
        }

        public static Time operator *(MassFlow left, Flexibility right)
        {
            return Time.FromSeconds(left.kilogramsPerSecond * right.metresPerNewton);
        }

        public static ElectricCharge operator /(MassFlow left, MagneticFieldStrength right)
        {
            return ElectricCharge.FromCoulombs(left.kilogramsPerSecond / right.teslas);
        }

        public static Wavenumber operator /(MassFlow left, Momentum right)
        {
            return Wavenumber.FromReciprocalMetres(left.kilogramsPerSecond / right.newtonSecond);
        }

        public static Momentum operator /(MassFlow left, Wavenumber right)
        {
            return Momentum.FromNewtonSecond(left.kilogramsPerSecond / right.reciprocalMetres);
        }

        public static KinematicViscosity operator /(MassFlow left, AreaDensity right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.kilogramsPerSecond / right.kilogramsPerSquareMetre);
        }

        public static VolumetricFlow operator *(MassFlow left, SpecificVolume right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.kilogramsPerSecond * right.cubicMetresPerKilogram);
        }

        public static Energy operator *(MassFlow left, KinematicViscosity right)
        {
            return Energy.FromJoules(left.kilogramsPerSecond * right.squareMetresPerSecond);
        }

        public static AreaDensity operator /(MassFlow left, KinematicViscosity right)
        {
            return AreaDensity.FromKilogramsPerSquareMetre(left.kilogramsPerSecond / right.squareMetresPerSecond);
        }

        public static double operator /(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond / right.kilogramsPerSecond;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MassFlow"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator ==(MassFlow left, MassFlow right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.MassFlow"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator !=(MassFlow left, MassFlow right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MassFlow"/> is less than another specified <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator <(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond < right.kilogramsPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MassFlow"/> is greater than another specified <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false. 
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator >(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond > right.kilogramsPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MassFlow"/> is less than or equal to another specified <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator <=(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond <= right.kilogramsPerSecond;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.MassFlow"/> is greater than or equal to another specified <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static bool operator >=(MassFlow left, MassFlow right)
        {
            return left.kilogramsPerSecond >= right.kilogramsPerSecond;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MassFlow"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">An instance of <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="left">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.MassFlow"/> with <paramref name="left"/> and returns the result.</returns>
        public static MassFlow operator *(double left, MassFlow right)
        {
            return new MassFlow(left * right.kilogramsPerSecond);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.MassFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Multiplies an instance of <see cref="Gu.Units.MassFlow"/> with <paramref name="right"/> and returns the result.</returns>
        public static MassFlow operator *(MassFlow left, double right)
        {
            return new MassFlow(left.kilogramsPerSecond * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.MassFlow"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/></param>
        /// <param name="right">An instance of <seealso cref="System.Double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.MassFlow"/> with <paramref name="right"/> and returns the result.</returns>
        public static MassFlow operator /(MassFlow left, double right)
        {
            return new MassFlow(left.kilogramsPerSecond / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.MassFlow"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MassFlow"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MassFlow"/>.</param>
        public static MassFlow operator +(MassFlow left, MassFlow right)
        {
            return new MassFlow(left.kilogramsPerSecond + right.kilogramsPerSecond);
        }

        /// <summary>
        /// Subtracts an MassFlow from another MassFlow and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MassFlow"/> that is the difference
        /// </returns>
        /// <param name="left">An instance of <see cref="Gu.Units.MassFlow"/> (the minuend).</param>
        /// <param name="right">An instance of <see cref="Gu.Units.MassFlow"/> (the subtrahend).</param>
        public static MassFlow operator -(MassFlow left, MassFlow right)
        {
            return new MassFlow(left.kilogramsPerSecond - right.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.MassFlow"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.MassFlow"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="massFlow">An instance of <see cref="Gu.Units.MassFlow"/></param>
        public static MassFlow operator -(MassFlow massFlow)
        {
            return new MassFlow(-1 * massFlow.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.MassFlow"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="massFlow"/>.
        /// </returns>
        /// <param name="massFlow">An instance of <see cref="Gu.Units.MassFlow"/></param>
        public static MassFlow operator +(MassFlow massFlow)
        {
            return massFlow;
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit"></param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(MassFlowUnit unit)
        {
            return unit.FromSiUnit(this.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(string.Empty, SiUnit);
            return ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/s\"</param>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(format);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 kg/s\"</param>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns> 
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(format);
            return ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex kg/s</param>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="System.Double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex kg/s</param>
        /// <param name="formatProvider"></param>
        /// <returns>The string representation of the <see cref="MassFlow"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(MassFlowUnit unit)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(MassFlowUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(MassFlowUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(MassFlowUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(null, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, MassFlowUnit unit)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, MassFlowUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, null);
        }

        public string ToString(string valueFormat, MassFlowUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, unit);
            return ToString(quantityFormat, formatProvider);
        }

        public string ToString(string valueFormat, MassFlowUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<MassFlowUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return ToString(quantityFormat, formatProvider);
        }

        internal string ToString(QuantityFormat<MassFlowUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.MassFlow"/> object and returns an integer that indicates whether this <see cref="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.MassFlow"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.MassFlow"/> object to compare to this instance.</param>
        public int CompareTo(MassFlow quantity)
        {
            return this.kilogramsPerSecond.CompareTo(quantity.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MassFlow"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MassFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MassFlow"/> object to compare with this instance.</param>
        public bool Equals(MassFlow other)
        {
            return this.kilogramsPerSecond.Equals(other.kilogramsPerSecond);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.MassFlow"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same MassFlow as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.MassFlow"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(MassFlow other, MassFlow tolerance)
        {
            Ensure.GreaterThan(tolerance.kilogramsPerSecond, 0, nameof(tolerance));
            return Math.Abs(this.kilogramsPerSecond - other.kilogramsPerSecond) < tolerance.kilogramsPerSecond;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is MassFlow && this.Equals((MassFlow)obj);
        }

        public override int GetHashCode()
        {
            return this.kilogramsPerSecond.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "kilogramsPerSecond", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.kilogramsPerSecond);
        }
    }
}