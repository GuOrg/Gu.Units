namespace Gu.Units.Generator.Tests
{
    using System.Runtime.Remoting.Metadata.W3cXsd2001;
    using WpfStuff;

    public class MockSettings : Settings
    {
        public readonly string Namespace = "Gu.Units";
        public readonly SiUnit Metres;
        public readonly Quantity Length;

        public readonly SiUnit Kilograms;

        public readonly SiUnit Seconds;
        public readonly Quantity Time;

        public readonly DerivedUnit MetresPerSecond;
        public readonly Quantity Speed;

        public readonly DerivedUnit SquareMetres;
        public readonly Quantity Area;

        public readonly DerivedUnit CubicMetres;
        public readonly Quantity Volume;
        public readonly Quantity Mass;


        public MockSettings()
        {
            Metres = new SiUnit(Namespace, "Metres", "m") { QuantityName = "Length" };
            SiUnits.Add(Metres);
            Length = Metres.Quantity;

            Seconds = new SiUnit(Namespace, "Seconds", "s") { QuantityName = "Time" };
            SiUnits.Add(Seconds);
            Time = Seconds.Quantity;

            Kilograms = new SiUnit("", "Kilograms", "kg") { QuantityName = "Mass" };
            SiUnits.Add(Kilograms);
            Mass = Kilograms.Quantity;

            MetresPerSecond = new DerivedUnit(Namespace,
                "MetresPerSecond",
                "m/s",
                new UnitAndPower(Metres, 1),
                new UnitAndPower(Seconds, -1)) { QuantityName = "Speed" };
            DerivedUnits.Add(MetresPerSecond);
            Speed = MetresPerSecond.Quantity;

            SquareMetres = new DerivedUnit(Namespace, "SquareMetres", "m^2", new UnitAndPower(Metres, 2))
            {
                QuantityName = "Area"
            };
            DerivedUnits.Add(SquareMetres);
            Area = SquareMetres.Quantity;

            CubicMetres = new DerivedUnit(Namespace, "CubicMetres", "m^3", new UnitAndPower(Metres, 3))
            {
                QuantityName = "Volume"
            };
            DerivedUnits.Add(CubicMetres);
            Volume = CubicMetres.Quantity;
        }
    }
}
