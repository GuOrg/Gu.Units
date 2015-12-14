namespace Gu.Units.Tests.Sources
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Threading;
    using Internals.Parsing;

    public class ConversionProvider : List<ConversionProvider.IConversion<IQuantity>>
    {
        public ConversionProvider()
        {
            Add("1.2 g", "0.0012 kg", Mass.Parse);
            Add("1.2 mg", "0.0000012 kg", Mass.Parse);
            Add("1.2cm", "0.012 m", Length.Parse);
            Add("1.2 cm", "12 mm", Length.Parse);
            Add("1.2 mm^2", "1.2E-6 m^2", Area.Parse);
            Add("90°", "1.5707963267948966rad", Angle.Parse);
            Add("1°", "0.017453292519943295rad", Angle.Parse);
            Add("0°C", "32°F", Temperature.Parse);
            Add("100°C", "211.99999999999994°F", Temperature.Parse);
            Add("100°F", "37.777777777777828°C", Temperature.Parse);
            Add("0K", "-273.15°C", Temperature.Parse);
            Add("0K", "-459.67°F", Temperature.Parse);
            Add("100K", "-173.14999999999998°C", Temperature.Parse);
            Add("100K", "-279.67°F", Temperature.Parse);
            Add("1ul", "100%", Unitless.Parse);
            Add("1%", "0.01ul", Unitless.Parse);
            Add("1%", "10‰", Unitless.Parse);
            Add("100N", "0.1kN", Force.Parse);
            Add("1.2 Pa", "0.000012 bar", Pressure.Parse);
            Add("0.12 MPa", "1.2 bar", Pressure.Parse);
            Add("1.2 Pa", "0.012 mbar", Pressure.Parse);
            Add("1.2 mm/s^2", "0.0012 m/s^2", Acceleration.Parse);
            Add("1.2 mm/s^2", "0.0012 m/s^2", Acceleration.Parse);
            Add("1.2 L", "0.0012 m^3", Volume.Parse);
            Add("1.2 ml", "0.0000012 m^3", Volume.Parse);
        }

        public void Add<TQuantity>(string @from,
            string to,
            Func<string, TQuantity> parser) where TQuantity : IQuantity
        {
            Add(new Conversion<TQuantity>(@from, to, parser));
        }

        public interface IConversion<out T>
        {
            string From { get; }
            T FromQuantity { get; }
            string To { get; }
            T ToQuantity { get; }
        }

        public class Conversion<T> : IConversion<IQuantity>
            where T : IQuantity
        {
            private readonly Func<string, T> parser;

            public Conversion(string from, string to, Func<string, T> parser)
            {
                using (Thread.CurrentThread.UsingTempCulture(CultureInfo.InvariantCulture))
                {
                    this.parser = parser;
                    this.From = @from;
                    FromQuantity = Parse(from);
                    this.To = to;
                    ToQuantity = Parse(to);
                }
            }

            public Conversion(IQuantity from, IQuantity to)
            {
                From = @from.ToString(null, CultureInfo.InvariantCulture);
                FromQuantity = @from;
                To = to.ToString(null, CultureInfo.InvariantCulture);
                ToQuantity = to;
            }

            public T Parse(string s)
            {
                return this.parser(s);
            }

            public string From { get; }

            public IQuantity FromQuantity { get; }

            public string To { get; }

            public IQuantity ToQuantity { get; }

            public override string ToString()
            {
                return $"{From} -> {To}";
            }
        }
    }
}
