namespace Gu.Units
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// A type for the quantity <see cref="Gu.Units.Power"/>.
    /// </summary>
    [TypeConverter(typeof(PowerTypeConverter))]
    [Serializable]
    public partial struct Power : IQuantity<PowerUnit>, IComparable<Power>, IEquatable<Power>
    {
        /// <summary>
        /// Gets a value that is zero <see cref="Gu.Units.PowerUnit.Watts"/>
        /// </summary>
        public static readonly Power Zero = default(Power);

#pragma warning disable SA1307 // Accessible fields must begin with upper-case letter
#pragma warning disable SA1304 // Non-private readonly fields must begin with upper-case letter
        /// <summary>
        /// The quantity in <see cref="Gu.Units.PowerUnit.Watts"/>.
        /// </summary>
        internal readonly double watts;
#pragma warning restore SA1304 // Non-private readonly fields must begin with upper-case letter
#pragma warning restore SA1307 // Accessible fields must begin with upper-case letter

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Power"/> struct.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit"><see cref="Gu.Units.PowerUnit"/>.</param>
        public Power(double value, PowerUnit unit)
        {
            this.watts = unit.ToSiUnit(value);
        }

        private Power(double watts)
        {
            this.watts = watts;
        }

        /// <summary>
        /// Gets the quantity in <see cref="Gu.Units.PowerUnit.Watts"/>
        /// </summary>
        public double SiValue => this.watts;

        /// <summary>
        /// Gets the <see cref="Gu.Units.PowerUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        public PowerUnit SiUnit => PowerUnit.Watts;

        /// <summary>
        /// Gets the <see cref="Gu.Units.IUnit"/> for the <see cref="SiValue"/>
        /// </summary>
        IUnit IQuantity.SiUnit => PowerUnit.Watts;

        /// <summary>
        /// Gets the quantity in watts".
        /// </summary>
        public double Watts => this.watts;

        /// <summary>
        /// Gets the quantity in Nanowatts
        /// </summary>
        public double Nanowatts => 1000000000 * this.watts;

        /// <summary>
        /// Gets the quantity in Microwatts
        /// </summary>
        public double Microwatts => 1000000 * this.watts;

        /// <summary>
        /// Gets the quantity in Milliwatts
        /// </summary>
        public double Milliwatts => 1000 * this.watts;

        /// <summary>
        /// Gets the quantity in Kilowatts
        /// </summary>
        public double Kilowatts => this.watts / 1000;

        /// <summary>
        /// Gets the quantity in Megawatts
        /// </summary>
        public double Megawatts => this.watts / 1000000;

        /// <summary>
        /// Gets the quantity in Gigawatts
        /// </summary>
        public double Gigawatts => this.watts / 1000000000;

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the multiplication.</returns>
        public static Energy operator *(Power left, Time right)
        {
            return Energy.FromJoules(left.watts * right.seconds);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Voltage"/> that is the result from the division.</returns>
        public static Voltage operator /(Power left, Current right)
        {
            return Voltage.FromVolts(left.watts / right.amperes);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Speed"/> that is the result from the division.</returns>
        public static Speed operator /(Power left, Force right)
        {
            return Speed.FromMetresPerSecond(left.watts / right.newtons);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="VolumetricFlow"/> that is the result from the division.</returns>
        public static VolumetricFlow operator /(Power left, Pressure right)
        {
            return VolumetricFlow.FromCubicMetresPerSecond(left.watts / right.pascals);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Frequency"/> that is the result from the division.</returns>
        public static Frequency operator /(Power left, Energy right)
        {
            return Frequency.FromHertz(left.watts / right.joules);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Force"/> that is the result from the division.</returns>
        public static Force operator /(Power left, Speed right)
        {
            return Force.FromNewtons(left.watts / right.metresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Torque"/> that is the result from the division.</returns>
        public static Torque operator /(Power left, AngularSpeed right)
        {
            return Torque.FromNewtonMetres(left.watts / right.radiansPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Energy"/> that is the result from the division.</returns>
        public static Energy operator /(Power left, Frequency right)
        {
            return Energy.FromJoules(left.watts / right.hertz);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Momentum"/> that is the result from the division.</returns>
        public static Momentum operator /(Power left, Acceleration right)
        {
            return Momentum.FromNewtonSecond(left.watts / right.metresPerSecondSquared);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="AngularSpeed"/> that is the result from the division.</returns>
        public static AngularSpeed operator /(Power left, Torque right)
        {
            return AngularSpeed.FromRadiansPerSecond(left.watts / right.newtonMetres);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the division.</returns>
        public static KinematicViscosity operator /(Power left, Stiffness right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.watts / right.newtonsPerMetre);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Pressure"/> that is the result from the division.</returns>
        public static Pressure operator /(Power left, VolumetricFlow right)
        {
            return Pressure.FromPascals(left.watts / right.cubicMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Current"/> that is the result from the division.</returns>
        public static Current operator /(Power left, Voltage right)
        {
            return Current.FromAmperes(left.watts / right.volts);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="MassFlow"/> that is the result from the division.</returns>
        public static MassFlow operator /(Power left, SpecificEnergy right)
        {
            return MassFlow.FromKilogramsPerSecond(left.watts / right.joulesPerKilogram);
        }

        /// <summary>
        /// Multiplies <paramref name="left"/> with <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="KinematicViscosity"/> that is the result from the multiplication.</returns>
        public static KinematicViscosity operator *(Power left, Flexibility right)
        {
            return KinematicViscosity.FromSquareMetresPerSecond(left.watts * right.metresPerNewton);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Acceleration"/> that is the result from the division.</returns>
        public static Acceleration operator /(Power left, Momentum right)
        {
            return Acceleration.FromMetresPerSecondSquared(left.watts / right.newtonSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="SpecificEnergy"/> that is the result from the division.</returns>
        public static SpecificEnergy operator /(Power left, MassFlow right)
        {
            return SpecificEnergy.FromJoulesPerKilogram(left.watts / right.kilogramsPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="Stiffness"/> that is the result from the division.</returns>
        public static Stiffness operator /(Power left, KinematicViscosity right)
        {
            return Stiffness.FromNewtonsPerMetre(left.watts / right.squareMetresPerSecond);
        }

        /// <summary>
        /// Divides <paramref name="left"/> by <paramref name="right"/>
        /// </summary>
        /// <param name="left">The left value</param>
        /// <param name="right">The right value</param>
        /// <returns>The <see cref="double"/> that is the result from the division.</returns>
        public static double operator /(Power left, Power right)
        {
            return left.watts / right.watts;
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Power"/> instances are equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Power"/>.</param>
        public static bool operator ==(Power left, Power right)
        {
            return left.Equals(right);
        }

        /// <summary>
        /// Indicates whether two <see cref="Gu.Units.Power"/> instances are not equal.
        /// </summary>
        /// <returns>
        /// true if the quantitys of <paramref name="left"/> and <paramref name="right"/> are not equal; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Power"/>.</param>
        public static bool operator !=(Power left, Power right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Power"/> is less than another specified <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Power"/>.</param>
        public static bool operator <(Power left, Power right)
        {
            return left.watts < right.watts;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Power"/> is greater than another specified <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Power"/>.</param>
        public static bool operator >(Power left, Power right)
        {
            return left.watts > right.watts;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Power"/> is less than or equal to another specified <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is less than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Power"/>.</param>
        public static bool operator <=(Power left, Power right)
        {
            return left.watts <= right.watts;
        }

        /// <summary>
        /// Indicates whether a specified <see cref="Gu.Units.Power"/> is greater than or equal to another specified <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// true if the quantity of <paramref name="left"/> is greater than or equal to the quantity of <paramref name="right"/>; otherwise, false.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Power"/>.</param>
        public static bool operator >=(Power left, Power right)
        {
            return left.watts >= right.watts;
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Power"/> with <paramref name="left"/> and returns the result.
        /// </summary>
        /// <param name="right">The right instance of <see cref="Gu.Units.Power"/></param>
        /// <param name="left">The left instance of <seealso cref="double"/></param>
        /// <returns>Multiplies <paramref name="left"/> with <see cref="Gu.Units.Power"/> and returns the result.</returns>
        public static Power operator *(double left, Power right)
        {
            return new Power(left * right.watts);
        }

        /// <summary>
        /// Multiplies an instance of <see cref="Gu.Units.Power"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Multiplies an <see cref="Gu.Units.Power"/> with <paramref name="right"/> and returns the result.</returns>
        public static Power operator *(Power left, double right)
        {
            return new Power(left.watts * right);
        }

        /// <summary>
        /// Divides an instance of <see cref="Gu.Units.Power"/> with <paramref name="right"/> and returns the result.
        /// </summary>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/></param>
        /// <param name="right">The right instance of <seealso cref="double"/></param>
        /// <returns>Divides an instance of <see cref="Gu.Units.Power"/> by <paramref name="right"/> and returns the result.</returns>
        public static Power operator /(Power left, double right)
        {
            return new Power(left.watts / right);
        }

        /// <summary>
        /// Adds two specified <see cref="Gu.Units.Power"/> instances.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Power"/> whose quantity is the sum of the quantitys of <paramref name="left"/> and <paramref name="right"/>.
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/>.</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Power"/>.</param>
        public static Power operator +(Power left, Power right)
        {
            return new Power(left.watts + right.watts);
        }

        /// <summary>
        /// Subtracts an Power from another Power and returns the difference.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Power"/> that is the difference
        /// </returns>
        /// <param name="left">The left instance of <see cref="Gu.Units.Power"/> (the minuend).</param>
        /// <param name="right">The right instance of <see cref="Gu.Units.Power"/> (the subtrahend).</param>
        public static Power operator -(Power left, Power right)
        {
            return new Power(left.watts - right.watts);
        }

        /// <summary>
        /// Returns an <see cref="Gu.Units.Power"/> whose quantity is the negated quantity of the specified instance.
        /// </summary>
        /// <returns>
        /// An <see cref="Gu.Units.Power"/> with the same numeric quantity as this instance, but the opposite sign.
        /// </returns>
        /// <param name="power">An instance of <see cref="Gu.Units.Power"/></param>
        public static Power operator -(Power power)
        {
            return new Power(-1 * power.watts);
        }

        /// <summary>
        /// Returns the specified instance of <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <returns>
        /// Returns <paramref name="power"/>.
        /// </returns>
        /// <param name="power">An instance of <see cref="Gu.Units.Power"/></param>
        public static Power operator +(Power power)
        {
            return power;
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Power"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Power"/></param>
        /// <returns>The <see cref="Gu.Units.Power"/> parsed from <paramref name="text"/></returns>
        public static Power Parse(string text)
        {
            return QuantityParser.Parse<PowerUnit, Power>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Power"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Power"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Power"/> parsed from <paramref name="text"/></returns>
        public static Power Parse(string text, IFormatProvider provider)
        {
            return QuantityParser.Parse<PowerUnit, Power>(text, From, NumberStyles.Float, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Power"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Power"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <returns>The <see cref="Gu.Units.Power"/> parsed from <paramref name="text"/></returns>
        public static Power Parse(string text, NumberStyles styles)
        {
            return QuantityParser.Parse<PowerUnit, Power>(text, From, styles, CultureInfo.CurrentCulture);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Power"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Power"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The <see cref="Gu.Units.Power"/> parsed from <paramref name="text"/></returns>
        public static Power Parse(string text, NumberStyles styles, IFormatProvider provider)
        {
            return QuantityParser.Parse<PowerUnit, Power>(text, From, styles, provider);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Power"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Power"/></param>
        /// <param name="result">The parsed <see cref="Power"/></param>
        /// <returns>True if an instance of <see cref="Power"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, out Power result)
        {
            return QuantityParser.TryParse<PowerUnit, Power>(text, From, NumberStyles.Float, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Power"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Power"/></param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Power"/></param>
        /// <returns>True if an instance of <see cref="Power"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, IFormatProvider provider, out Power result)
        {
            return QuantityParser.TryParse<PowerUnit, Power>(text, From, NumberStyles.Float, provider, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Power"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Power"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="result">The parsed <see cref="Power"/></param>
        /// <returns>True if an instance of <see cref="Power"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, out Power result)
        {
            return QuantityParser.TryParse<PowerUnit, Power>(text, From, styles, CultureInfo.CurrentCulture, out result);
        }

        /// <summary>
        /// Creates an instance of <see cref="Gu.Units.Power"/> from its string representation
        /// </summary>
        /// <param name="text">The string representation of the <see cref="Gu.Units.Power"/></param>
        /// <param name="styles">Specifies the <see cref="NumberStyles"/> to be used.</param>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <param name="result">The parsed <see cref="Power"/></param>
        /// <returns>True if an instance of <see cref="Power"/> could be parsed from <paramref name="text"/></returns>
        public static bool TryParse(string text, NumberStyles styles, IFormatProvider provider, out Power result)
        {
            return QuantityParser.TryParse<PowerUnit, Power>(text, From, styles, provider, out result);
        }

        /// <summary>
        /// Reads an instance of <see cref="Gu.Units.Power"/> from the <paramref name="reader"/>
        /// </summary>
        /// <param name="reader">The xml reader positioned at the start of the unit value.</param>
        /// <returns>An instance of <see cref="Gu.Units.Power"/></returns>
        public static Power ReadFrom(XmlReader reader)
        {
            var v = default(Power);
            v.ReadXml(reader);
            return v;
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <param name="value">The scalar value.</param>
        /// <param name="unit">The unit.</param>
        /// <returns>An instance of <see cref="Gu.Units.Power"/></returns>
        public static Power From(double value, PowerUnit unit)
        {
            return new Power(unit.ToSiUnit(value));
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <param name="watts">The value in <see cref="Gu.Units.PowerUnit.Watts"/></param>
        /// <returns>An instance of <see cref="Gu.Units.Power"/></returns>
        public static Power FromWatts(double watts)
        {
            return new Power(watts);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <param name="nanowatts">The value in nW.</param>
        /// <returns>An instance of <see cref="Gu.Units.Power"/></returns>
        public static Power FromNanowatts(double nanowatts)
        {
            return new Power(nanowatts / 1000000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <param name="microwatts">The value in µW.</param>
        /// <returns>An instance of <see cref="Gu.Units.Power"/></returns>
        public static Power FromMicrowatts(double microwatts)
        {
            return new Power(microwatts / 1000000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <param name="milliwatts">The value in mW.</param>
        /// <returns>An instance of <see cref="Gu.Units.Power"/></returns>
        public static Power FromMilliwatts(double milliwatts)
        {
            return new Power(milliwatts / 1000);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <param name="kilowatts">The value in kW.</param>
        /// <returns>An instance of <see cref="Gu.Units.Power"/></returns>
        public static Power FromKilowatts(double kilowatts)
        {
            return new Power(1000 * kilowatts);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <param name="megawatts">The value in MW.</param>
        /// <returns>An instance of <see cref="Gu.Units.Power"/></returns>
        public static Power FromMegawatts(double megawatts)
        {
            return new Power(1000000 * megawatts);
        }

        /// <summary>
        /// Creates a new instance of <see cref="Gu.Units.Power"/>.
        /// </summary>
        /// <param name="gigawatts">The value in GW.</param>
        /// <returns>An instance of <see cref="Gu.Units.Power"/></returns>
        public static Power FromGigawatts(double gigawatts)
        {
            return new Power(1000000000 * gigawatts);
        }

        /// <summary>
        /// Get the scalar value
        /// </summary>
        /// <param name="unit">The unit to get the value in.</param>
        /// <returns>The scalar value of this in the specified unit</returns>
        public double GetValue(PowerUnit unit)
        {
            return unit.FromSiUnit(this.watts);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <returns>The string representation of the <see cref="Power"/></returns>
        public override string ToString()
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(null, this.SiUnit);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// Returns a string with the <see cref="SiValue"/> and <see cref="SiUnit"/>
        /// </summary>
        /// <param name="provider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Power"/></returns>
        public string ToString(IFormatProvider provider)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(string.Empty, this.SiUnit);
            return this.ToString(quantityFormat, provider);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 W\"</param>
        /// <returns>The string representation of the <see cref="Power"/></returns>
        public string ToString(string format)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        /// If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="format">Must be a composite format ex: \"F2 W\"</param>
        /// <param name="formatProvider">Specifies the formatProvider to be used.</param>
        /// <returns>The string representation of the <see cref="Power"/></returns>
        public string ToString(string format, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(format);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting of the unit ex W</param>
        /// <returns>The string representation of the <see cref="Power"/></returns>
        public string ToString(string valueFormat, string symbolFormat)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, (IFormatProvider)null);
        }

        /// <summary>
        ///  If an invalid format is provided the string will look like: {value: ??} {unit: ??}
        /// </summary>
        /// <param name="valueFormat">For formatting the scalar, format stings valid for <see cref="double"/> are valid
        ///  ex: F2</param>
        /// <param name="symbolFormat">For formatting the unit ex W</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the <see cref="Power"/></returns>
        public string ToString(string valueFormat, string symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(valueFormat, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(PowerUnit unit)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(PowerUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(PowerUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(null, unit);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(PowerUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(null, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, PowerUnit unit)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(valueFormat, unit);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="symbolFormat">Specifies the symbol format to use when creting the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, PowerUnit unit, SymbolFormat symbolFormat)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, null);
        }

        /// <summary>
        /// Converts the quantity value of this instance to its equivalent string representation.
        /// </summary>
        /// <param name="valueFormat">The format to use for the scalar value. Valid formats are formats valid for formatting <see cref="double"/></param>
        /// <param name="unit">The unit to use in the conversion</param>
        /// <param name="formatProvider">Specifies the <see cref="IFormatProvider"/> to use when creating the string representation.</param>
        /// <returns>The string representation of the value of this instance.</returns>
        public string ToString(string valueFormat, PowerUnit unit, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(valueFormat, unit);
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
        public string ToString(string valueFormat, PowerUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider)
        {
            var quantityFormat = FormatCache<PowerUnit>.GetOrCreate(valueFormat, unit, symbolFormat);
            return this.ToString(quantityFormat, formatProvider);
        }

        /// <summary>
        /// Compares this instance to a specified <see cref="Gu.Units.Power"/> object and returns an integer that indicates whether this <paramref name="quantity"/> is smaller than, equal to, or greater than the <see cref="Gu.Units.Power"/> object.
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
        /// <param name="quantity">An instance of <see cref="Gu.Units.Power"/> object to compare to this instance.</param>
        public int CompareTo(Power quantity)
        {
            return this.watts.CompareTo(quantity.watts);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Power"/> object.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Power as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Power"/> object to compare with this instance.</param>
        public bool Equals(Power other)
        {
            return this.watts.Equals(other.watts);
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Power"/> object within the given tolerance.
        /// </summary>
        /// <returns>
        /// true if <paramref name="other"/> represents the same Power as this instance; otherwise, false.
        /// </returns>
        /// <param name="other">An instance of <see cref="Gu.Units.Power"/> object to compare with this instance.</param>
        /// <param name="tolerance">The maximum difference for being considered equal. Must be greater than zero.</param>
        public bool Equals(Power other, Power tolerance)
        {
            Ensure.GreaterThan(tolerance.watts, 0, nameof(tolerance));
            return Math.Abs(this.watts - other.watts) < tolerance.watts;
        }

        /// <summary>
        /// Returns a quantity indicating whether this instance is equal to a specified <see cref="Gu.Units.Power"/> object.
        /// </summary>
        /// <param name="obj">An object to compare with this instance.</param>
        /// <returns>
        /// true if <paramref name="obj"/> represents the same <see cref="Gu.Units.Power"/> as this instance; otherwise, false.
        /// </returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            return obj is Power && this.Equals((Power)obj);
        }

        /// <summary>
        /// Returns the hash code for this instance.
        /// </summary>
        /// <returns>A 32-bit signed integer hash code.</returns>
        public override int GetHashCode()
        {
            return this.watts.GetHashCode();
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
            XmlExt.SetReadonlyField(ref this, "watts", reader, "Value");
        }

        /// <summary>
        /// Converts an object into its XML representation.
        /// </summary>
        /// <param name="writer">The <see cref="System.Xml.XmlWriter"/> stream to which the object is serialized. </param>
        public void WriteXml(XmlWriter writer)
        {
            XmlExt.WriteAttribute(writer, "Value", this.watts);
        }

        internal string ToString(QuantityFormat<PowerUnit> format, IFormatProvider formatProvider)
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(this, format, formatProvider);
                return builder.ToString();
            }
        }
    }
}