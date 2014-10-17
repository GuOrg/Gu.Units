namespace Gu.Units.Generator.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using Gu.Units.Generator.WpfStuff;
    using NUnit.Framework;

    public class UnitPartsConverterTests
    {
        [TestCaseSource(typeof(UnitPartsConverterSource))]
        public void ConvertFrom(UnitPartsConverterSource.Data data)
        {
            var converter = new UnitPartsConverter();
            Assert.IsTrue(converter.CanConvertFrom(null, typeof(string)));
            var parts = (UnitParts)converter.ConvertFrom(null, null, data.Value);
            CollectionAssert.AreEquivalent(data.Units, parts);
            var convertTo = converter.ConvertTo(null, null, parts, typeof(string));
            Assert.AreEqual(data.Formatted, convertTo);
            
            var uiName = parts.Expression;
            Assert.AreEqual(data.Value.Replace(" ", ""), uiName.Replace('⋅', '*').Replace(" ", ""));
        }
    }

    public class UnitPartsConverterSource : IEnumerable
    {
        public static readonly SiUnit Metres = new SiUnit("", "Metres", "m");

        public static readonly SiUnit Kilograms = new SiUnit("", "Kilograms", "kg");

        public static readonly SiUnit Seconds = new SiUnit("", "Seconds", "s");

        //public static readonly DerivedUnit Joules = new DerivedUnit("", "Joules", "J", new UnitAndPower(Kilograms, 1), new UnitAndPower(Metres, 2), new UnitAndPower(Seconds, -2));

        private readonly List<Data> _datas = new List<Data>
                                        {
                                            new Data("m^2","m²", new UnitAndPower(Metres, 2)),
                                            new Data("m²","m²", new UnitAndPower(Metres, 2)),
                                            new Data("kg⋅m/s²","kg⋅m⋅s⁻²",new UnitAndPower(Kilograms, 1),new UnitAndPower(Metres, 1),new UnitAndPower(Seconds, -2)),
                                            new Data("kg⋅m⋅s⁻²","kg⋅m⋅s⁻²",new UnitAndPower(Kilograms, 1),new UnitAndPower(Metres, 1),new UnitAndPower(Seconds, -2)),
                                            new Data("kg*m/s²","kg⋅m⋅s⁻²",new UnitAndPower(Kilograms, 1),new UnitAndPower(Metres, 1),new UnitAndPower(Seconds, -2)),
                                            new Data("m/s","m⋅s⁻¹", new UnitAndPower(Metres,1), new UnitAndPower(Seconds,-1)),
                                            new Data("m/s","m⋅s⁻¹", new UnitAndPower(Metres,1), new UnitAndPower(Seconds,-1)),
                                            new Data("m¹⋅s^-1","m⋅s⁻¹", new UnitAndPower(Metres,1), new UnitAndPower(Seconds,-1)),
                                            new Data("m^1⋅s^-1","m⋅s⁻¹", new UnitAndPower(Metres,1), new UnitAndPower(Seconds,-1)),
                                            new Data("m⋅s⁻¹","m⋅s⁻¹", new UnitAndPower(Metres,1), new UnitAndPower(Seconds,-1)),
                                            new Data("1/s","s⁻¹", new UnitAndPower(Seconds,-1)),
                                            new Data("s^-1","s⁻¹", new UnitAndPower(Seconds,-1))
                                            //new Data("J/s",new UnitAndPower(Joules, 1),new UnitAndPower(Seconds, -1)),
                                        };
        public IEnumerator GetEnumerator()
        {
            return _datas.GetEnumerator();
        }

        public class Data
        {
            public Data(string value, string formatted, params UnitAndPower[] units)
            {
                this.Value = value;
                this.Formatted = formatted;
                this.Units = units;
            }

            public string Value { get; private set; }

            public string Formatted { get; private set; }

            public IEnumerable<UnitAndPower> Units { get; private set; }

            public override string ToString()
            {
                var units = string.Join(", ", this.Units.Select(x => string.Format("{0}^{1}", x.Unit.Symbol, x.Power)));
                return string.Format("{0} Formatted: {1} Units: {{{2}}}", Value, Formatted, units);
            }
        }
    }
}
