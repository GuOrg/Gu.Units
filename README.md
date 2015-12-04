# Gu.Units

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/JohanLarsson/Gu.Units?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Types for units and quantities.
#### Sample arithmetic:

    private static LengthUnit m = LengthUnit.m;
    private static TimeUnit s = TimeUnit.s;

    [Test]
    public void ArithmeticSample()
    {
        Length length = 1*m;
        Time time = 2*s;
        Speed speed = length/time;
        Assert.AreEqual(0.5, speed.MetresPerSecond);
    }

#### Sample conversion:

    [Test]
    public void ConversionSample()
    {
        var l = Length.FromCentimetres(1.2);
        Assert.AreEqual(0.012, l.Metres);
    }

#### Sample formatting:

    [Test]
    public void FormatSpeed()
    {
        var speed = Speed.FromMetresPerSecond(1.2);
        using (Thread.CurrentThread.UsingTempCulture(CultureInfo.InvariantCulture))
        {
            Assert.AreEqual("1.2\u00A0m/s", speed.ToString());
            Assert.AreEqual("1.20 m/s", speed.ToString("F2 m/s"));
            Assert.AreEqual(UnknownFormat, 1.2.ToString(UnknownFormat)); // for comparison
            Assert.AreEqual(UnknownFormat, speed.ToString(UnknownFormat));
            Assert.AreEqual("F1\u00A0{unit: invalid}", speed.ToString("F1 invalid"));
            Assert.AreEqual("1.20 m⋅s⁻¹", speed.ToString("F2 m⋅s⁻¹"));
            Assert.AreEqual("1.2\u00A0m⋅s⁻¹", speed.ToString("f1", "m⋅s⁻¹"));
            Assert.AreEqual("1.2 m⋅s⁻¹", speed.ToString("f1 ", "m⋅s⁻¹"));
            Assert.AreEqual("1.2 m⋅s⁻¹", speed.ToString("f1", " m⋅s⁻¹"));
            Assert.AreEqual("1.2  m⋅s⁻¹", speed.ToString("f1 ", " m⋅s⁻¹"));
            Assert.AreEqual("{value: null} mm⋅s⁻¹", speed.ToString("mm⋅s⁻¹"));
            Assert.AreEqual("1200\u00A0s⁻¹⋅mm", speed.ToString("F0", "s⁻¹⋅mm"));
            Assert.AreEqual("1200\u00A0s⁻¹⋅mm¹", speed.ToString("F0", "s⁻¹⋅mm¹"));
            Assert.AreEqual("1.2\u00A0m*s^-1", speed.ToString("F1", "m*s^-1"));
            Assert.AreEqual("1.2\u00A0s^-1*m", speed.ToString("F1", "s^-1*m"));
            Assert.AreEqual("1.2\u00A0s^-1*m^1", speed.ToString("F1", "s^-1*m^1"));
            Assert.AreEqual("4.32\u00A0km/h", speed.ToString(SpeedUnit.KilometresPerHour));
            Assert.AreEqual("1.2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.Default));
            Assert.AreEqual("1.2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers));
            Assert.AreEqual("1.2\u00A0m*s^-1", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers));
            Assert.AreEqual("1.2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript));
            Assert.AreEqual("1.2\u00A0m⋅s⁻¹", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript));
            Assert.AreEqual("4.3\u00A0km/h", speed.ToString("F1", SpeedUnit.KilometresPerHour));
            Assert.AreEqual("1.2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.Default));
            Assert.AreEqual("1.2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers));
            Assert.AreEqual("1.2\u00A0m*s^-1", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers));
            Assert.AreEqual("1.2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript));
            Assert.AreEqual("1.2\u00A0m⋅s⁻¹", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript));
            Assert.AreEqual("1,200.00 mm⋅s⁻¹", speed.ToString("N mm⋅s⁻¹"));
        }

        var sv = CultureInfo.GetCultureInfo("sv-SE");

        Assert.AreEqual("1,2\u00A0m/s", speed.ToString(sv));
        Assert.AreEqual("1,20 m/s", speed.ToString("F2 m/s", sv));
        Assert.AreEqual(UnknownFormat, 1.2.ToString(UnknownFormat, sv)); // for comparison
        Assert.AreEqual(UnknownFormat, speed.ToString(UnknownFormat, sv));
        Assert.AreEqual("F1\u00A0{unit: invalid}", speed.ToString("F1 invalid", sv));
        Assert.AreEqual("1,20 m⋅s⁻¹", speed.ToString("F2 m⋅s⁻¹", sv));
        Assert.AreEqual("1,2\u00A0m⋅s⁻¹", speed.ToString("f1", "m⋅s⁻¹", sv));
        Assert.AreEqual("1,2 m⋅s⁻¹", speed.ToString("f1 ", "m⋅s⁻¹", sv));
        Assert.AreEqual("1,2 m⋅s⁻¹", speed.ToString("f1", " m⋅s⁻¹", sv));
        Assert.AreEqual("1,2  m⋅s⁻¹", speed.ToString("f1 ", " m⋅s⁻¹", sv));
        Assert.AreEqual("{value: null} mm⋅s⁻¹", speed.ToString("mm⋅s⁻¹", sv));
        Assert.AreEqual("1200\u00A0s⁻¹⋅mm", speed.ToString("F0", "s⁻¹⋅mm", sv));
        Assert.AreEqual("1200\u00A0s⁻¹⋅mm¹", speed.ToString("F0", "s⁻¹⋅mm¹", sv));
        Assert.AreEqual("1,2\u00A0m*s^-1", speed.ToString("F1", "m*s^-1", sv));
        Assert.AreEqual("1,2\u00A0s^-1*m", speed.ToString("F1", "s^-1*m", sv));
        Assert.AreEqual("1,2\u00A0s^-1*m^1", speed.ToString("F1", "s^-1*m^1", sv));
        Assert.AreEqual("4,32\u00A0km/h", speed.ToString(SpeedUnit.KilometresPerHour, sv));
        Assert.AreEqual("1,2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.Default, sv));
        Assert.AreEqual("1,2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers, sv));
        Assert.AreEqual("1,2\u00A0m*s^-1", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers, sv));
        Assert.AreEqual("1,2\u00A0m/s", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript, sv));
        Assert.AreEqual("1,2\u00A0m⋅s⁻¹", speed.ToString(SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript, sv));
        Assert.AreEqual("4,3\u00A0km/h", speed.ToString("F1", SpeedUnit.KilometresPerHour, sv));
        Assert.AreEqual("1,2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.Default, sv));
        Assert.AreEqual("1,2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionHatPowers, sv));
        Assert.AreEqual("1,2\u00A0m*s^-1", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedHatPowers, sv));
        Assert.AreEqual("1,2\u00A0m/s", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.FractionSuperScript, sv));
        Assert.AreEqual("1,2\u00A0m⋅s⁻¹", speed.ToString("F1", SpeedUnit.MetresPerSecond, SymbolFormat.SignedSuperScript, sv));
        Assert.AreEqual("1\u00A0200,00 mm⋅s⁻¹", speed.ToString("N mm⋅s⁻¹", sv));
    }

#### Sample parsing:

    [TestCase("1.2m/s")]
    [TestCase("1.2m^1/s^1")]
    [TestCase("1.2m^1*s^-1")]
    [TestCase("1.2m^1*s^-1")]
    [TestCase("1.2m⋅s⁻¹")]
    [TestCase("1.2m¹/s¹")]
    [TestCase("1.2m^1/s¹")]
    public void ParsingSample(string text)
    {
        var speed = Speed.Parse(text, CultureInfo.InvariantCulture);
        Assert.AreEqual(Speed.FromMetresPerSecond(1.2), Speed.Parse(text));
        Assert.IsTrue(Speed.TryParse(text, CultureInfo.InvariantCulture, out speed));
        Assert.AreEqual(Speed.FromMetresPerSecond(1.2), Speed.Parse(text));
    }

For generating packages using paket read [this](https://github.com/JohanLarsson/Gu.Units/blob/master/.paket/Readme.paket.md)

For adding new units and quantities read [this](https://github.com/JohanLarsson/Gu.Units/blob/master/Gu.Units.Generator/Templates/Readme.md)

[nuget package](https://www.nuget.org/packages/Gu.Units/)
