namespace Gu.Units.Generator.Tests
{
    public class MockSettings : Settings
    {
        public readonly SiUnit Metres;
        public readonly Quantity Length;

        public readonly SiUnit Kilograms;
        public readonly Quantity Mass;

        public readonly SiUnit Seconds;
        public readonly Quantity Time;

        public readonly DerivedUnit MetresPerSecond;
        public readonly Quantity Speed;

        public readonly DerivedUnit SquareMetres;
        public readonly Quantity Area;

        public readonly DerivedUnit CubicMetres;
        public readonly Quantity Volume;

        public readonly SiUnit Amperes;
        public readonly Quantity Current;

        public readonly DerivedUnit Newtons;
        public readonly Quantity Force;

        public readonly DerivedUnit Joules;
        public readonly Quantity Energy;

        public readonly DerivedUnit Watts;
        public readonly Quantity Power;

        public readonly DerivedUnit Volts;
        public readonly Quantity Voltage;

        public readonly DerivedUnit Coloumbs;
        public readonly Quantity ElectricCharge;

        public MockSettings()
        {
            Metres = new SiUnit("Metres", "m") { QuantityName = "Length" };
            SiUnits.Add(Metres);
            Length = Metres.Quantity;

            Seconds = new SiUnit("Seconds", "s") { QuantityName = "Time" };
            SiUnits.Add(Seconds);
            Time = Seconds.Quantity;

            Kilograms = new SiUnit("Kilograms", "kg") { QuantityName = "Mass" };
            SiUnits.Add(Kilograms);
            Mass = Kilograms.Quantity;

            Amperes = new SiUnit("Amperes", "A") { QuantityName = "ElectricalCurrent" };
            SiUnits.Add(Amperes);
            Current = Amperes.Quantity;

            MetresPerSecond = new DerivedUnit(
                "MetresPerSecond",
                "m/s",
                new UnitAndPower(Metres, 1),
                new UnitAndPower(Seconds, -1)) { QuantityName = "Speed" };
            DerivedUnits.Add(MetresPerSecond);
            Speed = MetresPerSecond.Quantity;

            Newtons = new DerivedUnit(
                "Newtons",
                "N",
                new UnitAndPower(Kilograms, 1),
                new UnitAndPower(Metres, 1),
                new UnitAndPower(Seconds, -2)) { QuantityName = "Force" };
            DerivedUnits.Add(Newtons);
            Force = Newtons.Quantity;

            Joules = new DerivedUnit(
                "Joules",
                "J",
                new UnitAndPower(Newtons, 1),
                new UnitAndPower(Metres, 1)) { QuantityName = "Energy" };
            DerivedUnits.Add(Joules);
            Energy = Joules.Quantity;

            Watts = new DerivedUnit(
                "Watts",
                "W",
                new UnitAndPower(Joules, 1),
                new UnitAndPower(Seconds, -1)) { QuantityName = "Power" };
            DerivedUnits.Add(Watts);
            Power = Watts.Quantity;

            Volts = new DerivedUnit(
                "Volts",
                "V",
                new UnitAndPower(Watts, 1),
                new UnitAndPower(Amperes, -1)) { QuantityName = "Voltage" };
            DerivedUnits.Add(Volts);
            Voltage = Volts.Quantity;

            Coloumbs = new DerivedUnit(
                "Coloumbs",
                "C",
                new UnitAndPower(Seconds, 1),
                new UnitAndPower(Amperes, 1)) { QuantityName = "ElectricCharge" };
            DerivedUnits.Add(Coloumbs);
            ElectricCharge = Coloumbs.Quantity;

            SquareMetres = new DerivedUnit("SquareMetres", "m^2", new UnitAndPower(Metres, 2))
            {
                QuantityName = "Area"
            };
            DerivedUnits.Add(SquareMetres);
            Area = SquareMetres.Quantity;

            CubicMetres = new DerivedUnit("CubicMetres", "m^3", new UnitAndPower(Metres, 3))
            {
                QuantityName = "Volume"
            };
            DerivedUnits.Add(CubicMetres);
            Volume = CubicMetres.Quantity;
        }
    }
}
