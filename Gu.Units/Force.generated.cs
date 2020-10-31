namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Force"/>.
    /// </summary>
    [TypeConverter(typeof(ForceTypeConverter))]
    [Serializable]
    public partial struct Force : IQuantity<ForceUnit>, IComparable<Force>, IEquatable<Force>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.ForceUnit.Newtons"/>
        /// </summary>
        public static readonly Force Zero = default(Force);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.ForceUnit.Newtons"/>.
        /// </summary>
        internal readonly double newtons;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Force"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.ForceUnit"/>.</param>
        public Force(double value, ForceUnit unit)
        {
            this.newtons = unit.ToSiUnit(value);
        }

        private Force(double newtons)
        {
            this.newtons = newtons;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.ForceUnit.Newtons"/>
        /// </summary>
        public double SiValue => this.newtons;

        /// <summary>
        /// Gets the <see cref="Gu.Units.ForceUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public ForceUnit SiUnit => ForceUnit.Newtons;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => ForceUnit.Newtons;

        /// <summary>
        /// Gets the quantity in newtons".
        /// </summary>
        public double Newtons => this.newtons;

        /// <summary>
        /// Gets the quantity in Nanonewtons
        /// </summary>
        public double Nanonewtons => 1000000000 * this.newtons;

        /// <summary>
        /// Gets the quantity in Micronewtons
        /// </summary>
        public double Micronewtons => 1000000 * this.newtons;

        /// <summary>
        /// Gets the quantity in Millinewtons
        /// </summary>
        public double Millinewtons => 1000 * this.newtons;

        /// <summary>
        /// Gets the quantity in Kilonewtons
        /// </summary>
        public double Kilonewtons => this.newtons / 1000;

        /// <summary>
        /// Gets the quantity in Meganewtons
        /// </summary>
        public double Meganewtons => this.newtons / 1000000;

        /// <summary>
        /// Gets the quantity in Giganewtons
        /// </summary>
        public double Giganewtons => this.newtons / 1000000000;

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Acceleration"/> that is the result from the division.</returns>
        public static Acceleration operator /(Force left, Mass right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.newtons / right.kilograms);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Force left, Length right)
        {
            return Energy.FromJoules(left.newtons * right.metres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the division.</returns>
        public static Stiffness operator /(Force left, Length right)
        {
            return Stiffness.FromNewtonsPerMetre(left.newtons / right.metres);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the multiplication.</returns>
        public static Momentum operator *(Force left, Time right)
        {
            return Momentum.FromNewtonSecond(left.newtons * right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="ForcePerUnitless"/> that is the result from the division.</returns>
        public static ForcePerUnitless operator /(Force left, Unitless right)
        {
            return ForcePerUnitless.FromNewtonsPerUnitless(left.newtons / right.scalar);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Pressure"/> that is the result from the division.</returns>
        public static Pressure operator /(Force left, Area right)
        {
            return Pressure.FromPascals(left.newtons / right.squareMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Area"/> that is the result from the division.</returns>
        public static Area operator /(Force left, Pressure right)
        {
            return Area.FromSquareMetres(left.newtons / right.pascals);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Wavenumber"/> that is the result from the division.</returns>
        public static Wavenumber operator /(Force left, Energy right)
        {
            return Wavenumber.FromReciprocalMetres(left.newtons / right.joules);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Power"/> that is the result from the multiplication.</returns>
        public static Power operator *(Force left, Speed right)
        {
            return Power.FromWatts(left.newtons * right.metresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the division.</returns>
        public static MassFlow operator /(Force left, Speed right)
        {
            return MassFlow.FromKilogramsPerSecond(left.newtons / right.metresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the division.</returns>
        public static Momentum operator /(Force left, Frequency right)
        {
            return Momentum.FromNewtonSecond(left.newtons / right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Mass"/> that is the result from the division.</returns>
        public static Mass operator /(Force left, Acceleration right)
        {
            return Mass.FromKilograms(left.newtons / right.metresPerSecondSquared);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the division.</returns>
        public static Length operator /(Force left, Stiffness right)
        {
            return Length.FromMetres(left.newtons / right.newtonsPerMetre);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Length"/> that is the result from the multiplication.</returns>
        public static Length operator *(Force left, Flexibility right)
        {
            return Length.FromMetres(left.newtons * right.metresPerNewton);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Unitless"/> that is the result from the division.</returns>
        public static Unitless operator /(Force left, ForcePerUnitless right)
        {
            return Unitless.FromScalar(left.newtons / right.newtonsPerUnitless);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(Force left, Momentum right)
        {
            return Frequency.FromHertz(left.newtons / right.newtonSecond);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the multiplication.</returns>
        public static Stiffness operator *(Force left, Wavenumber right)
        {
            return Stiffness.FromNewtonsPerMetre(left.newtons * right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the division.</returns>
        public static Energy operator /(Force left, Wavenumber right)
        {
            return Energy.FromJoules(left.newtons / right.reciprocalMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the division.</returns>
        public static Speed operator /(Force left, MassFlow right)
        {
            return Speed.FromMetresPerSecond(left.newtons / right.kilogramsPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Force left, Force right)
        {
            return left.newtons / right.newtons;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Force"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator ==(Force left, Force right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Force"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator !=(Force left, Force right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Force"/> is less than another specified <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator <(Force left, Force right)
        {
            return left.newtons < right.newtons;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Force"/> is greater than another specified <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator >(Force left, Force right)
        {
            return left.newtons > right.newtons;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Force"/> is less than or equal to another specified <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator <=(Force left, Force right)
        {
            return left.newtons <= right.newtons;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Force"/> is greater than or equal to another specified <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Force"/>.</param>
        public static bool operator >=(Force left, Force right)
        {
            return left.newtons >= right.newtons;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Force"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Force"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Force"/> and returns the result.</returns>
        public static Force operator *(double left, Force right)
        {
            return new Force(left * right.newtons);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Force"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Force"/> with <paramref name="right"/> and returns the result.</returns>
        public static Force operator *(Force left, double right)
        {
            return new Force(left.newtons * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Force"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Force"/> by <paramref name="right"/> and returns the result.</returns>
        public static Force operator /(Force left, double right)
        {
            return new Force(left.newtons / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Force"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Force"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Force"/>.</param>
        public static Force operator +(Force left, Force right)
        {
            return new Force(left.newtons + right.newtons);
        }

        /// <summary>
        /// Subtracts an Force from another Force and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Force"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Force"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Force"/> (the subtrahend).</param>
        public static Force operator -(Force left, Force right)
        {
            return new Force(left.newtons - right.newtons);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Force"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Force"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="force">An instance of <see cref="Gu.Units.Force"/></param>
        public static Force operator -(Force force)
        {
            return new Force(-1 * force.newtons);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="force"/>.
        /// </returns>
        /// <param name="force">An instance of <see cref="Gu.Units.Force"/></param>
        public static Force operator +(Force force)
        {
            return force;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Force"/></param>
        /// <returns>The <see cref="Gu.Units.Force"/> parsed from <paramref name="text"/></returns>
        public static Force Parse(string text)
        {
            return QuantityParser.Parse<ForceUnit, Force>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Force"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Force"/> parsed from <paramref name="text"/></returns>
        public static Force Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<ForceUnit, Force>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Force"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Force"/> parsed from <paramref name="text"/></returns>
        public static Force Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<ForceUnit, Force>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Force"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Force"/> parsed from <paramref name="text"/></returns>
        public static Force Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<ForceUnit, Force>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Force"/></param>
        /// <param name="result">The parsed <see cref="Force"/></param>
        /// <returns>True if an instance of <see cref="Force"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Force result)
        {
            return QuantityParser.TryParse<ForceUnit, Force>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Force"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Force"/></param>
        /// <returns>True if an instance of <see cref="Force"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Force result)
        {
            return QuantityParser.TryParse<ForceUnit, Force>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Force"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Force"/></param>
        /// <returns>True if an instance of <see cref="Force"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Force result)
        {
            return QuantityParser.TryParse<ForceUnit, Force>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Force"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Force"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Force"/></param>
        /// <returns>True if an instance of <see cref="Force"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Force result)
        {
            return QuantityParser.TryParse<ForceUnit, Force>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Force"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Force"/></returns>
        public static Force ReadFrom(XmlReader reader)
        {
            var v = default(Force);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Force"/></returns>
        public static Force From(double value, ForceUnit unit)
        {
            return new Force(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="newtons">The value in <see cref="Gu.Units.ForceUnit.Newtons"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Force"/></returns>
        public static Force FromNewtons(double newtons)
        {
            return new Force(newtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="nanonewtons">The value in nN.</param>
        /// <returns>An instance of <see cref="Gu.Units.Force"/></returns>
        public static Force FromNanonewtons(double nanonewtons)
        {
            return new Force(nanonewtons / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="micronewtons">The value in μN.</param>
        /// <returns>An instance of <see cref="Gu.Units.Force"/></returns>
        public static Force FromMicronewtons(double micronewtons)
        {
            return new Force(micronewtons / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="millinewtons">The value in mN.</param>
        /// <returns>An instance of <see cref="Gu.Units.Force"/></returns>
        public static Force FromMillinewtons(double millinewtons)
        {
            return new Force(millinewtons / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="kilonewtons">The value in kN.</param>
        /// <returns>An instance of <see cref="Gu.Units.Force"/></returns>
        public static Force FromKilonewtons(double kilonewtons)
        {
            return new Force(1000 * kilonewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="meganewtons">The value in MN.</param>
        /// <returns>An instance of <see cref="Gu.Units.Force"/></returns>
        public static Force FromMeganewtons(double meganewtons)
        {
            return new Force(1000000 * meganewtons);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Force"/>.
        /// </summary>
        /// <param name="giganewtons">The value in GN.</param>
        /// <returns>An instance of <see cref="Gu.Units.Force"/></returns>
        public static Force FromGiganewtons(double giganewtons)
        {
            return new Force(1000000000 * giganewtons);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(ForceUnit unit)
        {
            return unit.FromSiUnit(this.newtons);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N\"</param>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 N\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex N</param>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex N</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="Force"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ForceUnit unit)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ForceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ForceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(ForceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ForceUnit unit)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ForceUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, ForceUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, ForceUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<ForceUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Force"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Force"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Force"/> object to compare to this instance.</param>
        public int CompareTo(Force quantity)
        {
            return this.newtons.CompareTo(quantity.newtons);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Force"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Force as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Force"/> object to compare with this instance.</param>
        public bool Equals(Force other)
        {
            return this.newtons.Equals(other.newtons);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Force"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Force as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Force"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Force other, Force tolerance)
        {
            Ensure.GreaterThan(tolerance.newtons, 0, nameof(tolerance));
            return Math.Abs(this.newtons - other.newtons) < tolerance.newtons;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Force"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Force"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Force && this.Equals((Force)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.newtons.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "newtons", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.newtons);
        }

        internal string ToString(QuantityFormat<ForceUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}
