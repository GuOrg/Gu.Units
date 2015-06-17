namespace Gu.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public static partial class EnumerableUnits
    {
        public static Mass Sum(this IEnumerable<Mass> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.kilograms;
                }
            }
            return Mass.FromKilograms(sum);
        }

        public static Length Sum(this IEnumerable<Length> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metres;
                }
            }
            return Length.FromMetres(sum);
        }

        public static Time Sum(this IEnumerable<Time> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.seconds;
                }
            }
            return Time.FromSeconds(sum);
        }

        public static Temperature Sum(this IEnumerable<Temperature> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.kelvin;
                }
            }
            return Temperature.FromKelvin(sum);
        }

        public static Angle Sum(this IEnumerable<Angle> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.radians;
                }
            }
            return Angle.FromRadians(sum);
        }

        public static Unitless Sum(this IEnumerable<Unitless> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.scalar;
                }
            }
            return Unitless.FromScalar(sum);
        }

        public static Current Sum(this IEnumerable<Current> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.amperes;
                }
            }
            return Current.FromAmperes(sum);
        }

        public static LuminousIntensity Sum(this IEnumerable<LuminousIntensity> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.candelas;
                }
            }
            return LuminousIntensity.FromCandelas(sum);
        }

        public static Area Sum(this IEnumerable<Area> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.squareMetres;
                }
            }
            return Area.FromSquareMetres(sum);
        }

        public static Volume Sum(this IEnumerable<Volume> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.cubicMetres;
                }
            }
            return Volume.FromCubicMetres(sum);
        }

        public static Force Sum(this IEnumerable<Force> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.newtons;
                }
            }
            return Force.FromNewtons(sum);
        }

        public static Pressure Sum(this IEnumerable<Pressure> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.pascals;
                }
            }
            return Pressure.FromPascals(sum);
        }

        public static Density Sum(this IEnumerable<Density> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.kilogramsPerCubicMetre;
                }
            }
            return Density.FromKilogramsPerCubicMetre(sum);
        }

        public static Energy Sum(this IEnumerable<Energy> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.joules;
                }
            }
            return Energy.FromJoules(sum);
        }

        public static Power Sum(this IEnumerable<Power> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.watts;
                }
            }
            return Power.FromWatts(sum);
        }

        public static Speed Sum(this IEnumerable<Speed> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metresPerSecond;
                }
            }
            return Speed.FromMetresPerSecond(sum);
        }

        public static AngularSpeed Sum(this IEnumerable<AngularSpeed> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.radiansPerSecond;
                }
            }
            return AngularSpeed.FromRadiansPerSecond(sum);
        }

        public static Frequency Sum(this IEnumerable<Frequency> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.hertz;
                }
            }
            return Frequency.FromHertz(sum);
        }

        public static Acceleration Sum(this IEnumerable<Acceleration> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metresPerSecondSquared;
                }
            }
            return Acceleration.FromMetresPerSecondSquared(sum);
        }

        public static Torque Sum(this IEnumerable<Torque> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.newtonMetres;
                }
            }
            return Torque.FromNewtonMetres(sum);
        }

        public static Stiffness Sum(this IEnumerable<Stiffness> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.newtonsPerMetre;
                }
            }
            return Stiffness.FromNewtonsPerMetre(sum);
        }

        public static VolumetricFlow Sum(this IEnumerable<VolumetricFlow> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.cubicMetresPerSecond;
                }
            }
            return VolumetricFlow.FromCubicMetresPerSecond(sum);
        }

        public static Voltage Sum(this IEnumerable<Voltage> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.volts;
                }
            }
            return Voltage.FromVolts(sum);
        }

        public static Resistance Sum(this IEnumerable<Resistance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.ohm;
                }
            }
            return Resistance.FromOhm(sum);
        }

        public static SpecificEnergy Sum(this IEnumerable<SpecificEnergy> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.joulesPerKilogram;
                }
            }
            return SpecificEnergy.FromJoulesPerKilogram(sum);
        }

        public static ElectricCharge Sum(this IEnumerable<ElectricCharge> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.coulombs;
                }
            }
            return ElectricCharge.FromCoulombs(sum);
        }

        public static Inductance Sum(this IEnumerable<Inductance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.henrys;
                }
            }
            return Inductance.FromHenrys(sum);
        }

        public static Capacitance Sum(this IEnumerable<Capacitance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.farads;
                }
            }
            return Capacitance.FromFarads(sum);
        }

        public static Flexibility Sum(this IEnumerable<Flexibility> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metresPerNewton;
                }
            }
            return Flexibility.FromMetresPerNewton(sum);
        }

        public static AngularAcceleration Sum(this IEnumerable<AngularAcceleration> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.radiansPerSecondSquared;
                }
            }
            return AngularAcceleration.FromRadiansPerSecondSquared(sum);
        }

        public static AngularJerk Sum(this IEnumerable<AngularJerk> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.radiansPerSecondCubed;
                }
            }
            return AngularJerk.FromRadiansPerSecondCubed(sum);
        }

        public static Jerk Sum(this IEnumerable<Jerk> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metresPerSecondCubed;
                }
            }
            return Jerk.FromMetresPerSecondCubed(sum);
        }

        public static Mass? Sum(this IEnumerable<Mass?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.kilograms;
                    }
                }
            }
            return Mass.FromKilograms(sum);
        }

        public static Length? Sum(this IEnumerable<Length?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metres;
                    }
                }
            }
            return Length.FromMetres(sum);
        }

        public static Time? Sum(this IEnumerable<Time?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.seconds;
                    }
                }
            }
            return Time.FromSeconds(sum);
        }

        public static Temperature? Sum(this IEnumerable<Temperature?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.kelvin;
                    }
                }
            }
            return Temperature.FromKelvin(sum);
        }

        public static Angle? Sum(this IEnumerable<Angle?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.radians;
                    }
                }
            }
            return Angle.FromRadians(sum);
        }

        public static Unitless? Sum(this IEnumerable<Unitless?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.scalar;
                    }
                }
            }
            return Unitless.FromScalar(sum);
        }

        public static Current? Sum(this IEnumerable<Current?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.amperes;
                    }
                }
            }
            return Current.FromAmperes(sum);
        }

        public static LuminousIntensity? Sum(this IEnumerable<LuminousIntensity?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.candelas;
                    }
                }
            }
            return LuminousIntensity.FromCandelas(sum);
        }

        public static Area? Sum(this IEnumerable<Area?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.squareMetres;
                    }
                }
            }
            return Area.FromSquareMetres(sum);
        }

        public static Volume? Sum(this IEnumerable<Volume?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.cubicMetres;
                    }
                }
            }
            return Volume.FromCubicMetres(sum);
        }

        public static Force? Sum(this IEnumerable<Force?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.newtons;
                    }
                }
            }
            return Force.FromNewtons(sum);
        }

        public static Pressure? Sum(this IEnumerable<Pressure?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.pascals;
                    }
                }
            }
            return Pressure.FromPascals(sum);
        }

        public static Density? Sum(this IEnumerable<Density?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.kilogramsPerCubicMetre;
                    }
                }
            }
            return Density.FromKilogramsPerCubicMetre(sum);
        }

        public static Energy? Sum(this IEnumerable<Energy?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.joules;
                    }
                }
            }
            return Energy.FromJoules(sum);
        }

        public static Power? Sum(this IEnumerable<Power?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.watts;
                    }
                }
            }
            return Power.FromWatts(sum);
        }

        public static Speed? Sum(this IEnumerable<Speed?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metresPerSecond;
                    }
                }
            }
            return Speed.FromMetresPerSecond(sum);
        }

        public static AngularSpeed? Sum(this IEnumerable<AngularSpeed?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.radiansPerSecond;
                    }
                }
            }
            return AngularSpeed.FromRadiansPerSecond(sum);
        }

        public static Frequency? Sum(this IEnumerable<Frequency?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.hertz;
                    }
                }
            }
            return Frequency.FromHertz(sum);
        }

        public static Acceleration? Sum(this IEnumerable<Acceleration?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metresPerSecondSquared;
                    }
                }
            }
            return Acceleration.FromMetresPerSecondSquared(sum);
        }

        public static Torque? Sum(this IEnumerable<Torque?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.newtonMetres;
                    }
                }
            }
            return Torque.FromNewtonMetres(sum);
        }

        public static Stiffness? Sum(this IEnumerable<Stiffness?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.newtonsPerMetre;
                    }
                }
            }
            return Stiffness.FromNewtonsPerMetre(sum);
        }

        public static VolumetricFlow? Sum(this IEnumerable<VolumetricFlow?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.cubicMetresPerSecond;
                    }
                }
            }
            return VolumetricFlow.FromCubicMetresPerSecond(sum);
        }

        public static Voltage? Sum(this IEnumerable<Voltage?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.volts;
                    }
                }
            }
            return Voltage.FromVolts(sum);
        }

        public static Resistance? Sum(this IEnumerable<Resistance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.ohm;
                    }
                }
            }
            return Resistance.FromOhm(sum);
        }

        public static SpecificEnergy? Sum(this IEnumerable<SpecificEnergy?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.joulesPerKilogram;
                    }
                }
            }
            return SpecificEnergy.FromJoulesPerKilogram(sum);
        }

        public static ElectricCharge? Sum(this IEnumerable<ElectricCharge?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.coulombs;
                    }
                }
            }
            return ElectricCharge.FromCoulombs(sum);
        }

        public static Inductance? Sum(this IEnumerable<Inductance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.henrys;
                    }
                }
            }
            return Inductance.FromHenrys(sum);
        }

        public static Capacitance? Sum(this IEnumerable<Capacitance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.farads;
                    }
                }
            }
            return Capacitance.FromFarads(sum);
        }

        public static Flexibility? Sum(this IEnumerable<Flexibility?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metresPerNewton;
                    }
                }
            }
            return Flexibility.FromMetresPerNewton(sum);
        }

        public static AngularAcceleration? Sum(this IEnumerable<AngularAcceleration?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.radiansPerSecondSquared;
                    }
                }
            }
            return AngularAcceleration.FromRadiansPerSecondSquared(sum);
        }

        public static AngularJerk? Sum(this IEnumerable<AngularJerk?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.radiansPerSecondCubed;
                    }
                }
            }
            return AngularJerk.FromRadiansPerSecondCubed(sum);
        }

        public static Jerk? Sum(this IEnumerable<Jerk?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metresPerSecondCubed;
                    }
                }
            }
            return Jerk.FromMetresPerSecondCubed(sum);
        }

        public static Mass Min(this IEnumerable<Mass> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Mass);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.kilograms))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.kilograms < value.kilograms)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Length Min(this IEnumerable<Length> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Length);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.metres))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metres < value.metres)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Time Min(this IEnumerable<Time> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Time);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.seconds))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.seconds < value.seconds)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Temperature Min(this IEnumerable<Temperature> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Temperature);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.kelvin))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.kelvin < value.kelvin)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Angle Min(this IEnumerable<Angle> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Angle);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.radians))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.radians < value.radians)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Unitless Min(this IEnumerable<Unitless> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Unitless);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.scalar))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.scalar < value.scalar)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Current Min(this IEnumerable<Current> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Current);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.amperes))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.amperes < value.amperes)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static LuminousIntensity Min(this IEnumerable<LuminousIntensity> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(LuminousIntensity);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.candelas))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.candelas < value.candelas)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Area Min(this IEnumerable<Area> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Area);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.squareMetres))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.squareMetres < value.squareMetres)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Volume Min(this IEnumerable<Volume> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Volume);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.cubicMetres))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.cubicMetres < value.cubicMetres)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Force Min(this IEnumerable<Force> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Force);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.newtons))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.newtons < value.newtons)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Pressure Min(this IEnumerable<Pressure> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Pressure);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.pascals))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.pascals < value.pascals)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Density Min(this IEnumerable<Density> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Density);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.kilogramsPerCubicMetre))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.kilogramsPerCubicMetre < value.kilogramsPerCubicMetre)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Energy Min(this IEnumerable<Energy> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Energy);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.joules))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.joules < value.joules)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Power Min(this IEnumerable<Power> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Power);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.watts))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.watts < value.watts)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Speed Min(this IEnumerable<Speed> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Speed);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.metresPerSecond))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metresPerSecond < value.metresPerSecond)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static AngularSpeed Min(this IEnumerable<AngularSpeed> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(AngularSpeed);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.radiansPerSecond))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.radiansPerSecond < value.radiansPerSecond)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Frequency Min(this IEnumerable<Frequency> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Frequency);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.hertz))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.hertz < value.hertz)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Acceleration Min(this IEnumerable<Acceleration> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Acceleration);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.metresPerSecondSquared))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metresPerSecondSquared < value.metresPerSecondSquared)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Torque Min(this IEnumerable<Torque> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Torque);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.newtonMetres))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.newtonMetres < value.newtonMetres)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Stiffness Min(this IEnumerable<Stiffness> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Stiffness);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.newtonsPerMetre))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.newtonsPerMetre < value.newtonsPerMetre)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static VolumetricFlow Min(this IEnumerable<VolumetricFlow> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(VolumetricFlow);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.cubicMetresPerSecond))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.cubicMetresPerSecond < value.cubicMetresPerSecond)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Voltage Min(this IEnumerable<Voltage> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Voltage);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.volts))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.volts < value.volts)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Resistance Min(this IEnumerable<Resistance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Resistance);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.ohm))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.ohm < value.ohm)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static SpecificEnergy Min(this IEnumerable<SpecificEnergy> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(SpecificEnergy);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.joulesPerKilogram))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.joulesPerKilogram < value.joulesPerKilogram)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static ElectricCharge Min(this IEnumerable<ElectricCharge> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(ElectricCharge);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.coulombs))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.coulombs < value.coulombs)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Inductance Min(this IEnumerable<Inductance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Inductance);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.henrys))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.henrys < value.henrys)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Capacitance Min(this IEnumerable<Capacitance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Capacitance);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.farads))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.farads < value.farads)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Flexibility Min(this IEnumerable<Flexibility> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Flexibility);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.metresPerNewton))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metresPerNewton < value.metresPerNewton)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static AngularAcceleration Min(this IEnumerable<AngularAcceleration> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(AngularAcceleration);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.radiansPerSecondSquared))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.radiansPerSecondSquared < value.radiansPerSecondSquared)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static AngularJerk Min(this IEnumerable<AngularJerk> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(AngularJerk);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.radiansPerSecondCubed))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.radiansPerSecondCubed < value.radiansPerSecondCubed)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Jerk Min(this IEnumerable<Jerk> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            var value = default(Jerk);
            bool hasValue = false;
            foreach (var x in source)
            {
                if (System.Double.IsNaN(x.metresPerSecondCubed))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metresPerSecondCubed < value.metresPerSecondCubed)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Mass? Min(this IEnumerable<Mass?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Mass? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.kilograms))
                {
                    return x;
                }
                if (value == null || x.Value.kilograms < value.Value.kilograms)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Length? Min(this IEnumerable<Length?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Length? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metres))
                {
                    return x;
                }
                if (value == null || x.Value.metres < value.Value.metres)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Time? Min(this IEnumerable<Time?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Time? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.seconds))
                {
                    return x;
                }
                if (value == null || x.Value.seconds < value.Value.seconds)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Temperature? Min(this IEnumerable<Temperature?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Temperature? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.kelvin))
                {
                    return x;
                }
                if (value == null || x.Value.kelvin < value.Value.kelvin)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Angle? Min(this IEnumerable<Angle?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Angle? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.radians))
                {
                    return x;
                }
                if (value == null || x.Value.radians < value.Value.radians)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Unitless? Min(this IEnumerable<Unitless?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Unitless? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.scalar))
                {
                    return x;
                }
                if (value == null || x.Value.scalar < value.Value.scalar)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Current? Min(this IEnumerable<Current?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Current? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.amperes))
                {
                    return x;
                }
                if (value == null || x.Value.amperes < value.Value.amperes)
                {
                    value = x;
                }
            }
            return value;
        }

        public static LuminousIntensity? Min(this IEnumerable<LuminousIntensity?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            LuminousIntensity? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.candelas))
                {
                    return x;
                }
                if (value == null || x.Value.candelas < value.Value.candelas)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Area? Min(this IEnumerable<Area?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Area? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.squareMetres))
                {
                    return x;
                }
                if (value == null || x.Value.squareMetres < value.Value.squareMetres)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Volume? Min(this IEnumerable<Volume?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Volume? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.cubicMetres))
                {
                    return x;
                }
                if (value == null || x.Value.cubicMetres < value.Value.cubicMetres)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Force? Min(this IEnumerable<Force?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Force? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.newtons))
                {
                    return x;
                }
                if (value == null || x.Value.newtons < value.Value.newtons)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Pressure? Min(this IEnumerable<Pressure?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Pressure? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.pascals))
                {
                    return x;
                }
                if (value == null || x.Value.pascals < value.Value.pascals)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Density? Min(this IEnumerable<Density?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Density? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.kilogramsPerCubicMetre))
                {
                    return x;
                }
                if (value == null || x.Value.kilogramsPerCubicMetre < value.Value.kilogramsPerCubicMetre)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Energy? Min(this IEnumerable<Energy?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Energy? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.joules))
                {
                    return x;
                }
                if (value == null || x.Value.joules < value.Value.joules)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Power? Min(this IEnumerable<Power?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Power? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.watts))
                {
                    return x;
                }
                if (value == null || x.Value.watts < value.Value.watts)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Speed? Min(this IEnumerable<Speed?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Speed? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metresPerSecond))
                {
                    return x;
                }
                if (value == null || x.Value.metresPerSecond < value.Value.metresPerSecond)
                {
                    value = x;
                }
            }
            return value;
        }

        public static AngularSpeed? Min(this IEnumerable<AngularSpeed?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            AngularSpeed? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.radiansPerSecond))
                {
                    return x;
                }
                if (value == null || x.Value.radiansPerSecond < value.Value.radiansPerSecond)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Frequency? Min(this IEnumerable<Frequency?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Frequency? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.hertz))
                {
                    return x;
                }
                if (value == null || x.Value.hertz < value.Value.hertz)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Acceleration? Min(this IEnumerable<Acceleration?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Acceleration? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metresPerSecondSquared))
                {
                    return x;
                }
                if (value == null || x.Value.metresPerSecondSquared < value.Value.metresPerSecondSquared)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Torque? Min(this IEnumerable<Torque?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Torque? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.newtonMetres))
                {
                    return x;
                }
                if (value == null || x.Value.newtonMetres < value.Value.newtonMetres)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Stiffness? Min(this IEnumerable<Stiffness?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Stiffness? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.newtonsPerMetre))
                {
                    return x;
                }
                if (value == null || x.Value.newtonsPerMetre < value.Value.newtonsPerMetre)
                {
                    value = x;
                }
            }
            return value;
        }

        public static VolumetricFlow? Min(this IEnumerable<VolumetricFlow?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            VolumetricFlow? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.cubicMetresPerSecond))
                {
                    return x;
                }
                if (value == null || x.Value.cubicMetresPerSecond < value.Value.cubicMetresPerSecond)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Voltage? Min(this IEnumerable<Voltage?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Voltage? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.volts))
                {
                    return x;
                }
                if (value == null || x.Value.volts < value.Value.volts)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Resistance? Min(this IEnumerable<Resistance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Resistance? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.ohm))
                {
                    return x;
                }
                if (value == null || x.Value.ohm < value.Value.ohm)
                {
                    value = x;
                }
            }
            return value;
        }

        public static SpecificEnergy? Min(this IEnumerable<SpecificEnergy?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            SpecificEnergy? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.joulesPerKilogram))
                {
                    return x;
                }
                if (value == null || x.Value.joulesPerKilogram < value.Value.joulesPerKilogram)
                {
                    value = x;
                }
            }
            return value;
        }

        public static ElectricCharge? Min(this IEnumerable<ElectricCharge?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            ElectricCharge? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.coulombs))
                {
                    return x;
                }
                if (value == null || x.Value.coulombs < value.Value.coulombs)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Inductance? Min(this IEnumerable<Inductance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Inductance? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.henrys))
                {
                    return x;
                }
                if (value == null || x.Value.henrys < value.Value.henrys)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Capacitance? Min(this IEnumerable<Capacitance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Capacitance? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.farads))
                {
                    return x;
                }
                if (value == null || x.Value.farads < value.Value.farads)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Flexibility? Min(this IEnumerable<Flexibility?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Flexibility? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metresPerNewton))
                {
                    return x;
                }
                if (value == null || x.Value.metresPerNewton < value.Value.metresPerNewton)
                {
                    value = x;
                }
            }
            return value;
        }

        public static AngularAcceleration? Min(this IEnumerable<AngularAcceleration?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            AngularAcceleration? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.radiansPerSecondSquared))
                {
                    return x;
                }
                if (value == null || x.Value.radiansPerSecondSquared < value.Value.radiansPerSecondSquared)
                {
                    value = x;
                }
            }
            return value;
        }

        public static AngularJerk? Min(this IEnumerable<AngularJerk?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            AngularJerk? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.radiansPerSecondCubed))
                {
                    return x;
                }
                if (value == null || x.Value.radiansPerSecondCubed < value.Value.radiansPerSecondCubed)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Jerk? Min(this IEnumerable<Jerk?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Jerk? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metresPerSecondCubed))
                {
                    return x;
                }
                if (value == null || x.Value.metresPerSecondCubed < value.Value.metresPerSecondCubed)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Mass Max(this IEnumerable<Mass> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Mass value = default(Mass);
            bool hasValue = false;
            foreach (Mass x in source)
            {
                if (System.Double.IsNaN(x.kilograms))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.kilograms > value.kilograms)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Length Max(this IEnumerable<Length> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Length value = default(Length);
            bool hasValue = false;
            foreach (Length x in source)
            {
                if (System.Double.IsNaN(x.metres))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metres > value.metres)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Time Max(this IEnumerable<Time> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Time value = default(Time);
            bool hasValue = false;
            foreach (Time x in source)
            {
                if (System.Double.IsNaN(x.seconds))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.seconds > value.seconds)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Temperature Max(this IEnumerable<Temperature> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Temperature value = default(Temperature);
            bool hasValue = false;
            foreach (Temperature x in source)
            {
                if (System.Double.IsNaN(x.kelvin))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.kelvin > value.kelvin)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Angle Max(this IEnumerable<Angle> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Angle value = default(Angle);
            bool hasValue = false;
            foreach (Angle x in source)
            {
                if (System.Double.IsNaN(x.radians))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.radians > value.radians)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Unitless Max(this IEnumerable<Unitless> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Unitless value = default(Unitless);
            bool hasValue = false;
            foreach (Unitless x in source)
            {
                if (System.Double.IsNaN(x.scalar))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.scalar > value.scalar)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Current Max(this IEnumerable<Current> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Current value = default(Current);
            bool hasValue = false;
            foreach (Current x in source)
            {
                if (System.Double.IsNaN(x.amperes))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.amperes > value.amperes)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static LuminousIntensity Max(this IEnumerable<LuminousIntensity> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            LuminousIntensity value = default(LuminousIntensity);
            bool hasValue = false;
            foreach (LuminousIntensity x in source)
            {
                if (System.Double.IsNaN(x.candelas))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.candelas > value.candelas)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Area Max(this IEnumerable<Area> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Area value = default(Area);
            bool hasValue = false;
            foreach (Area x in source)
            {
                if (System.Double.IsNaN(x.squareMetres))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.squareMetres > value.squareMetres)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Volume Max(this IEnumerable<Volume> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Volume value = default(Volume);
            bool hasValue = false;
            foreach (Volume x in source)
            {
                if (System.Double.IsNaN(x.cubicMetres))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.cubicMetres > value.cubicMetres)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Force Max(this IEnumerable<Force> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Force value = default(Force);
            bool hasValue = false;
            foreach (Force x in source)
            {
                if (System.Double.IsNaN(x.newtons))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.newtons > value.newtons)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Pressure Max(this IEnumerable<Pressure> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Pressure value = default(Pressure);
            bool hasValue = false;
            foreach (Pressure x in source)
            {
                if (System.Double.IsNaN(x.pascals))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.pascals > value.pascals)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Density Max(this IEnumerable<Density> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Density value = default(Density);
            bool hasValue = false;
            foreach (Density x in source)
            {
                if (System.Double.IsNaN(x.kilogramsPerCubicMetre))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.kilogramsPerCubicMetre > value.kilogramsPerCubicMetre)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Energy Max(this IEnumerable<Energy> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Energy value = default(Energy);
            bool hasValue = false;
            foreach (Energy x in source)
            {
                if (System.Double.IsNaN(x.joules))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.joules > value.joules)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Power Max(this IEnumerable<Power> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Power value = default(Power);
            bool hasValue = false;
            foreach (Power x in source)
            {
                if (System.Double.IsNaN(x.watts))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.watts > value.watts)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Speed Max(this IEnumerable<Speed> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Speed value = default(Speed);
            bool hasValue = false;
            foreach (Speed x in source)
            {
                if (System.Double.IsNaN(x.metresPerSecond))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metresPerSecond > value.metresPerSecond)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static AngularSpeed Max(this IEnumerable<AngularSpeed> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            AngularSpeed value = default(AngularSpeed);
            bool hasValue = false;
            foreach (AngularSpeed x in source)
            {
                if (System.Double.IsNaN(x.radiansPerSecond))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.radiansPerSecond > value.radiansPerSecond)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Frequency Max(this IEnumerable<Frequency> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Frequency value = default(Frequency);
            bool hasValue = false;
            foreach (Frequency x in source)
            {
                if (System.Double.IsNaN(x.hertz))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.hertz > value.hertz)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Acceleration Max(this IEnumerable<Acceleration> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Acceleration value = default(Acceleration);
            bool hasValue = false;
            foreach (Acceleration x in source)
            {
                if (System.Double.IsNaN(x.metresPerSecondSquared))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metresPerSecondSquared > value.metresPerSecondSquared)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Torque Max(this IEnumerable<Torque> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Torque value = default(Torque);
            bool hasValue = false;
            foreach (Torque x in source)
            {
                if (System.Double.IsNaN(x.newtonMetres))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.newtonMetres > value.newtonMetres)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Stiffness Max(this IEnumerable<Stiffness> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Stiffness value = default(Stiffness);
            bool hasValue = false;
            foreach (Stiffness x in source)
            {
                if (System.Double.IsNaN(x.newtonsPerMetre))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.newtonsPerMetre > value.newtonsPerMetre)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static VolumetricFlow Max(this IEnumerable<VolumetricFlow> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            VolumetricFlow value = default(VolumetricFlow);
            bool hasValue = false;
            foreach (VolumetricFlow x in source)
            {
                if (System.Double.IsNaN(x.cubicMetresPerSecond))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.cubicMetresPerSecond > value.cubicMetresPerSecond)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Voltage Max(this IEnumerable<Voltage> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Voltage value = default(Voltage);
            bool hasValue = false;
            foreach (Voltage x in source)
            {
                if (System.Double.IsNaN(x.volts))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.volts > value.volts)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Resistance Max(this IEnumerable<Resistance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Resistance value = default(Resistance);
            bool hasValue = false;
            foreach (Resistance x in source)
            {
                if (System.Double.IsNaN(x.ohm))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.ohm > value.ohm)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static SpecificEnergy Max(this IEnumerable<SpecificEnergy> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            SpecificEnergy value = default(SpecificEnergy);
            bool hasValue = false;
            foreach (SpecificEnergy x in source)
            {
                if (System.Double.IsNaN(x.joulesPerKilogram))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.joulesPerKilogram > value.joulesPerKilogram)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static ElectricCharge Max(this IEnumerable<ElectricCharge> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            ElectricCharge value = default(ElectricCharge);
            bool hasValue = false;
            foreach (ElectricCharge x in source)
            {
                if (System.Double.IsNaN(x.coulombs))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.coulombs > value.coulombs)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Inductance Max(this IEnumerable<Inductance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Inductance value = default(Inductance);
            bool hasValue = false;
            foreach (Inductance x in source)
            {
                if (System.Double.IsNaN(x.henrys))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.henrys > value.henrys)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Capacitance Max(this IEnumerable<Capacitance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Capacitance value = default(Capacitance);
            bool hasValue = false;
            foreach (Capacitance x in source)
            {
                if (System.Double.IsNaN(x.farads))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.farads > value.farads)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Flexibility Max(this IEnumerable<Flexibility> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Flexibility value = default(Flexibility);
            bool hasValue = false;
            foreach (Flexibility x in source)
            {
                if (System.Double.IsNaN(x.metresPerNewton))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metresPerNewton > value.metresPerNewton)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static AngularAcceleration Max(this IEnumerable<AngularAcceleration> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            AngularAcceleration value = default(AngularAcceleration);
            bool hasValue = false;
            foreach (AngularAcceleration x in source)
            {
                if (System.Double.IsNaN(x.radiansPerSecondSquared))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.radiansPerSecondSquared > value.radiansPerSecondSquared)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static AngularJerk Max(this IEnumerable<AngularJerk> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            AngularJerk value = default(AngularJerk);
            bool hasValue = false;
            foreach (AngularJerk x in source)
            {
                if (System.Double.IsNaN(x.radiansPerSecondCubed))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.radiansPerSecondCubed > value.radiansPerSecondCubed)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Jerk Max(this IEnumerable<Jerk> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Jerk value = default(Jerk);
            bool hasValue = false;
            foreach (Jerk x in source)
            {
                if (System.Double.IsNaN(x.metresPerSecondCubed))
                {
                    return x;
                }
                if (hasValue)
                {
                    if (x.metresPerSecondCubed > value.metresPerSecondCubed)
                    {
                        value = x;
                    }
                }
                else
                {
                    value = x;
                    hasValue = true;
                }
            }
            if (hasValue) return value;
            throw new ArgumentException("No elements", "source");
        }

        public static Mass? Max(this IEnumerable<Mass?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Mass? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.kilograms))
                {
                    return x;
                }
                if (value == null || x.Value.kilograms > value.Value.kilograms)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Length? Max(this IEnumerable<Length?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Length? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metres))
                {
                    return x;
                }
                if (value == null || x.Value.metres > value.Value.metres)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Time? Max(this IEnumerable<Time?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Time? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.seconds))
                {
                    return x;
                }
                if (value == null || x.Value.seconds > value.Value.seconds)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Temperature? Max(this IEnumerable<Temperature?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Temperature? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.kelvin))
                {
                    return x;
                }
                if (value == null || x.Value.kelvin > value.Value.kelvin)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Angle? Max(this IEnumerable<Angle?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Angle? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.radians))
                {
                    return x;
                }
                if (value == null || x.Value.radians > value.Value.radians)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Unitless? Max(this IEnumerable<Unitless?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Unitless? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.scalar))
                {
                    return x;
                }
                if (value == null || x.Value.scalar > value.Value.scalar)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Current? Max(this IEnumerable<Current?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Current? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.amperes))
                {
                    return x;
                }
                if (value == null || x.Value.amperes > value.Value.amperes)
                {
                    value = x;
                }
            }
            return value;
        }

        public static LuminousIntensity? Max(this IEnumerable<LuminousIntensity?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            LuminousIntensity? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.candelas))
                {
                    return x;
                }
                if (value == null || x.Value.candelas > value.Value.candelas)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Area? Max(this IEnumerable<Area?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Area? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.squareMetres))
                {
                    return x;
                }
                if (value == null || x.Value.squareMetres > value.Value.squareMetres)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Volume? Max(this IEnumerable<Volume?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Volume? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.cubicMetres))
                {
                    return x;
                }
                if (value == null || x.Value.cubicMetres > value.Value.cubicMetres)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Force? Max(this IEnumerable<Force?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Force? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.newtons))
                {
                    return x;
                }
                if (value == null || x.Value.newtons > value.Value.newtons)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Pressure? Max(this IEnumerable<Pressure?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Pressure? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.pascals))
                {
                    return x;
                }
                if (value == null || x.Value.pascals > value.Value.pascals)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Density? Max(this IEnumerable<Density?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Density? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.kilogramsPerCubicMetre))
                {
                    return x;
                }
                if (value == null || x.Value.kilogramsPerCubicMetre > value.Value.kilogramsPerCubicMetre)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Energy? Max(this IEnumerable<Energy?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Energy? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.joules))
                {
                    return x;
                }
                if (value == null || x.Value.joules > value.Value.joules)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Power? Max(this IEnumerable<Power?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Power? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.watts))
                {
                    return x;
                }
                if (value == null || x.Value.watts > value.Value.watts)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Speed? Max(this IEnumerable<Speed?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Speed? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metresPerSecond))
                {
                    return x;
                }
                if (value == null || x.Value.metresPerSecond > value.Value.metresPerSecond)
                {
                    value = x;
                }
            }
            return value;
        }

        public static AngularSpeed? Max(this IEnumerable<AngularSpeed?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            AngularSpeed? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.radiansPerSecond))
                {
                    return x;
                }
                if (value == null || x.Value.radiansPerSecond > value.Value.radiansPerSecond)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Frequency? Max(this IEnumerable<Frequency?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Frequency? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.hertz))
                {
                    return x;
                }
                if (value == null || x.Value.hertz > value.Value.hertz)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Acceleration? Max(this IEnumerable<Acceleration?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Acceleration? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metresPerSecondSquared))
                {
                    return x;
                }
                if (value == null || x.Value.metresPerSecondSquared > value.Value.metresPerSecondSquared)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Torque? Max(this IEnumerable<Torque?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Torque? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.newtonMetres))
                {
                    return x;
                }
                if (value == null || x.Value.newtonMetres > value.Value.newtonMetres)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Stiffness? Max(this IEnumerable<Stiffness?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Stiffness? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.newtonsPerMetre))
                {
                    return x;
                }
                if (value == null || x.Value.newtonsPerMetre > value.Value.newtonsPerMetre)
                {
                    value = x;
                }
            }
            return value;
        }

        public static VolumetricFlow? Max(this IEnumerable<VolumetricFlow?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            VolumetricFlow? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.cubicMetresPerSecond))
                {
                    return x;
                }
                if (value == null || x.Value.cubicMetresPerSecond > value.Value.cubicMetresPerSecond)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Voltage? Max(this IEnumerable<Voltage?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Voltage? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.volts))
                {
                    return x;
                }
                if (value == null || x.Value.volts > value.Value.volts)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Resistance? Max(this IEnumerable<Resistance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Resistance? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.ohm))
                {
                    return x;
                }
                if (value == null || x.Value.ohm > value.Value.ohm)
                {
                    value = x;
                }
            }
            return value;
        }

        public static SpecificEnergy? Max(this IEnumerable<SpecificEnergy?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            SpecificEnergy? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.joulesPerKilogram))
                {
                    return x;
                }
                if (value == null || x.Value.joulesPerKilogram > value.Value.joulesPerKilogram)
                {
                    value = x;
                }
            }
            return value;
        }

        public static ElectricCharge? Max(this IEnumerable<ElectricCharge?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            ElectricCharge? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.coulombs))
                {
                    return x;
                }
                if (value == null || x.Value.coulombs > value.Value.coulombs)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Inductance? Max(this IEnumerable<Inductance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Inductance? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.henrys))
                {
                    return x;
                }
                if (value == null || x.Value.henrys > value.Value.henrys)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Capacitance? Max(this IEnumerable<Capacitance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Capacitance? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.farads))
                {
                    return x;
                }
                if (value == null || x.Value.farads > value.Value.farads)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Flexibility? Max(this IEnumerable<Flexibility?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Flexibility? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metresPerNewton))
                {
                    return x;
                }
                if (value == null || x.Value.metresPerNewton > value.Value.metresPerNewton)
                {
                    value = x;
                }
            }
            return value;
        }

        public static AngularAcceleration? Max(this IEnumerable<AngularAcceleration?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            AngularAcceleration? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.radiansPerSecondSquared))
                {
                    return x;
                }
                if (value == null || x.Value.radiansPerSecondSquared > value.Value.radiansPerSecondSquared)
                {
                    value = x;
                }
            }
            return value;
        }

        public static AngularJerk? Max(this IEnumerable<AngularJerk?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            AngularJerk? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.radiansPerSecondCubed))
                {
                    return x;
                }
                if (value == null || x.Value.radiansPerSecondCubed > value.Value.radiansPerSecondCubed)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Jerk? Max(this IEnumerable<Jerk?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            Jerk? value = null;
            foreach (var x in source)
            {
                if (x == null)
                {
                    continue;
                }
                if (System.Double.IsNaN(x.Value.metresPerSecondCubed))
                {
                    return x;
                }
                if (value == null || x.Value.metresPerSecondCubed > value.Value.metresPerSecondCubed)
                {
                    value = x;
                }
            }
            return value;
        }

        public static Mass Average(this IEnumerable<Mass> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.kilograms;
                    count++;
                }
            }
            if (count > 0)
            {
                return Mass.FromKilograms(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Length Average(this IEnumerable<Length> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metres;
                    count++;
                }
            }
            if (count > 0)
            {
                return Length.FromMetres(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Time Average(this IEnumerable<Time> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.seconds;
                    count++;
                }
            }
            if (count > 0)
            {
                return Time.FromSeconds(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Temperature Average(this IEnumerable<Temperature> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.kelvin;
                    count++;
                }
            }
            if (count > 0)
            {
                return Temperature.FromKelvin(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Angle Average(this IEnumerable<Angle> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.radians;
                    count++;
                }
            }
            if (count > 0)
            {
                return Angle.FromRadians(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Unitless Average(this IEnumerable<Unitless> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.scalar;
                    count++;
                }
            }
            if (count > 0)
            {
                return Unitless.FromScalar(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Current Average(this IEnumerable<Current> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.amperes;
                    count++;
                }
            }
            if (count > 0)
            {
                return Current.FromAmperes(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static LuminousIntensity Average(this IEnumerable<LuminousIntensity> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.candelas;
                    count++;
                }
            }
            if (count > 0)
            {
                return LuminousIntensity.FromCandelas(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Area Average(this IEnumerable<Area> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.squareMetres;
                    count++;
                }
            }
            if (count > 0)
            {
                return Area.FromSquareMetres(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Volume Average(this IEnumerable<Volume> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.cubicMetres;
                    count++;
                }
            }
            if (count > 0)
            {
                return Volume.FromCubicMetres(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Force Average(this IEnumerable<Force> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.newtons;
                    count++;
                }
            }
            if (count > 0)
            {
                return Force.FromNewtons(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Pressure Average(this IEnumerable<Pressure> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.pascals;
                    count++;
                }
            }
            if (count > 0)
            {
                return Pressure.FromPascals(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Density Average(this IEnumerable<Density> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.kilogramsPerCubicMetre;
                    count++;
                }
            }
            if (count > 0)
            {
                return Density.FromKilogramsPerCubicMetre(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Energy Average(this IEnumerable<Energy> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.joules;
                    count++;
                }
            }
            if (count > 0)
            {
                return Energy.FromJoules(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Power Average(this IEnumerable<Power> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.watts;
                    count++;
                }
            }
            if (count > 0)
            {
                return Power.FromWatts(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Speed Average(this IEnumerable<Speed> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metresPerSecond;
                    count++;
                }
            }
            if (count > 0)
            {
                return Speed.FromMetresPerSecond(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static AngularSpeed Average(this IEnumerable<AngularSpeed> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.radiansPerSecond;
                    count++;
                }
            }
            if (count > 0)
            {
                return AngularSpeed.FromRadiansPerSecond(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Frequency Average(this IEnumerable<Frequency> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.hertz;
                    count++;
                }
            }
            if (count > 0)
            {
                return Frequency.FromHertz(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Acceleration Average(this IEnumerable<Acceleration> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metresPerSecondSquared;
                    count++;
                }
            }
            if (count > 0)
            {
                return Acceleration.FromMetresPerSecondSquared(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Torque Average(this IEnumerable<Torque> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.newtonMetres;
                    count++;
                }
            }
            if (count > 0)
            {
                return Torque.FromNewtonMetres(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Stiffness Average(this IEnumerable<Stiffness> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.newtonsPerMetre;
                    count++;
                }
            }
            if (count > 0)
            {
                return Stiffness.FromNewtonsPerMetre(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static VolumetricFlow Average(this IEnumerable<VolumetricFlow> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.cubicMetresPerSecond;
                    count++;
                }
            }
            if (count > 0)
            {
                return VolumetricFlow.FromCubicMetresPerSecond(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Voltage Average(this IEnumerable<Voltage> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.volts;
                    count++;
                }
            }
            if (count > 0)
            {
                return Voltage.FromVolts(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Resistance Average(this IEnumerable<Resistance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.ohm;
                    count++;
                }
            }
            if (count > 0)
            {
                return Resistance.FromOhm(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static SpecificEnergy Average(this IEnumerable<SpecificEnergy> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.joulesPerKilogram;
                    count++;
                }
            }
            if (count > 0)
            {
                return SpecificEnergy.FromJoulesPerKilogram(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static ElectricCharge Average(this IEnumerable<ElectricCharge> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.coulombs;
                    count++;
                }
            }
            if (count > 0)
            {
                return ElectricCharge.FromCoulombs(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Inductance Average(this IEnumerable<Inductance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.henrys;
                    count++;
                }
            }
            if (count > 0)
            {
                return Inductance.FromHenrys(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Capacitance Average(this IEnumerable<Capacitance> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.farads;
                    count++;
                }
            }
            if (count > 0)
            {
                return Capacitance.FromFarads(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Flexibility Average(this IEnumerable<Flexibility> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metresPerNewton;
                    count++;
                }
            }
            if (count > 0)
            {
                return Flexibility.FromMetresPerNewton(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static AngularAcceleration Average(this IEnumerable<AngularAcceleration> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.radiansPerSecondSquared;
                    count++;
                }
            }
            if (count > 0)
            {
                return AngularAcceleration.FromRadiansPerSecondSquared(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static AngularJerk Average(this IEnumerable<AngularJerk> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.radiansPerSecondCubed;
                    count++;
                }
            }
            if (count > 0)
            {
                return AngularJerk.FromRadiansPerSecondCubed(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }

        public static Jerk Average(this IEnumerable<Jerk> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    sum += v.metresPerSecondCubed;
                    count++;
                }
            }
            if (count > 0)
            {
                return Jerk.FromMetresPerSecondCubed(sum / count);
            }
            throw new ArgumentException("No elements", "source");
        }


        public static Mass? Average(this IEnumerable<Mass?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.kilograms;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Mass.FromKilograms(sum / count);
            }
            return null;
        }

        public static Length? Average(this IEnumerable<Length?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metres;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Length.FromMetres(sum / count);
            }
            return null;
        }

        public static Time? Average(this IEnumerable<Time?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.seconds;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Time.FromSeconds(sum / count);
            }
            return null;
        }

        public static Temperature? Average(this IEnumerable<Temperature?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.kelvin;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Temperature.FromKelvin(sum / count);
            }
            return null;
        }

        public static Angle? Average(this IEnumerable<Angle?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.radians;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Angle.FromRadians(sum / count);
            }
            return null;
        }

        public static Unitless? Average(this IEnumerable<Unitless?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.scalar;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Unitless.FromScalar(sum / count);
            }
            return null;
        }

        public static Current? Average(this IEnumerable<Current?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.amperes;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Current.FromAmperes(sum / count);
            }
            return null;
        }

        public static LuminousIntensity? Average(this IEnumerable<LuminousIntensity?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.candelas;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return LuminousIntensity.FromCandelas(sum / count);
            }
            return null;
        }

        public static Area? Average(this IEnumerable<Area?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.squareMetres;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Area.FromSquareMetres(sum / count);
            }
            return null;
        }

        public static Volume? Average(this IEnumerable<Volume?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.cubicMetres;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Volume.FromCubicMetres(sum / count);
            }
            return null;
        }

        public static Force? Average(this IEnumerable<Force?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.newtons;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Force.FromNewtons(sum / count);
            }
            return null;
        }

        public static Pressure? Average(this IEnumerable<Pressure?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.pascals;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Pressure.FromPascals(sum / count);
            }
            return null;
        }

        public static Density? Average(this IEnumerable<Density?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.kilogramsPerCubicMetre;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Density.FromKilogramsPerCubicMetre(sum / count);
            }
            return null;
        }

        public static Energy? Average(this IEnumerable<Energy?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.joules;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Energy.FromJoules(sum / count);
            }
            return null;
        }

        public static Power? Average(this IEnumerable<Power?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.watts;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Power.FromWatts(sum / count);
            }
            return null;
        }

        public static Speed? Average(this IEnumerable<Speed?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metresPerSecond;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Speed.FromMetresPerSecond(sum / count);
            }
            return null;
        }

        public static AngularSpeed? Average(this IEnumerable<AngularSpeed?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.radiansPerSecond;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return AngularSpeed.FromRadiansPerSecond(sum / count);
            }
            return null;
        }

        public static Frequency? Average(this IEnumerable<Frequency?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.hertz;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Frequency.FromHertz(sum / count);
            }
            return null;
        }

        public static Acceleration? Average(this IEnumerable<Acceleration?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metresPerSecondSquared;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Acceleration.FromMetresPerSecondSquared(sum / count);
            }
            return null;
        }

        public static Torque? Average(this IEnumerable<Torque?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.newtonMetres;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Torque.FromNewtonMetres(sum / count);
            }
            return null;
        }

        public static Stiffness? Average(this IEnumerable<Stiffness?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.newtonsPerMetre;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Stiffness.FromNewtonsPerMetre(sum / count);
            }
            return null;
        }

        public static VolumetricFlow? Average(this IEnumerable<VolumetricFlow?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.cubicMetresPerSecond;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return VolumetricFlow.FromCubicMetresPerSecond(sum / count);
            }
            return null;
        }

        public static Voltage? Average(this IEnumerable<Voltage?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.volts;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Voltage.FromVolts(sum / count);
            }
            return null;
        }

        public static Resistance? Average(this IEnumerable<Resistance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.ohm;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Resistance.FromOhm(sum / count);
            }
            return null;
        }

        public static SpecificEnergy? Average(this IEnumerable<SpecificEnergy?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.joulesPerKilogram;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return SpecificEnergy.FromJoulesPerKilogram(sum / count);
            }
            return null;
        }

        public static ElectricCharge? Average(this IEnumerable<ElectricCharge?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.coulombs;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return ElectricCharge.FromCoulombs(sum / count);
            }
            return null;
        }

        public static Inductance? Average(this IEnumerable<Inductance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.henrys;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Inductance.FromHenrys(sum / count);
            }
            return null;
        }

        public static Capacitance? Average(this IEnumerable<Capacitance?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.farads;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Capacitance.FromFarads(sum / count);
            }
            return null;
        }

        public static Flexibility? Average(this IEnumerable<Flexibility?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metresPerNewton;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Flexibility.FromMetresPerNewton(sum / count);
            }
            return null;
        }

        public static AngularAcceleration? Average(this IEnumerable<AngularAcceleration?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.radiansPerSecondSquared;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return AngularAcceleration.FromRadiansPerSecondSquared(sum / count);
            }
            return null;
        }

        public static AngularJerk? Average(this IEnumerable<AngularJerk?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.radiansPerSecondCubed;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return AngularJerk.FromRadiansPerSecondCubed(sum / count);
            }
            return null;
        }

        public static Jerk? Average(this IEnumerable<Jerk?> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }
            double sum = 0;
            long count = 0;
            checked
            {
                foreach (var v in source)
                {
                    if (v != null)
                    {
                        sum += v.Value.metresPerSecondCubed;
                        count++;
                    }
                }
            }
            if (count > 0)
            {
                return Jerk.FromMetresPerSecondCubed(sum / count);
            }
            return null;
        }
    }
}
