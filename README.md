# Gu.Units

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/JohanLarsson/Gu.Units?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

Types for units and quantities, sample:

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

    [Test]
    public void ConversionSample()
    {
        var l = Length.FromCentimetres(1.2);
        Assert.AreEqual(0.012, l.Metres);
    }
    
    [TestCase("1.2m/s")]
    [TestCase("1.2m^1/s^1")]
    [TestCase("1.2m^1*s^-1")]
    [TestCase("1.2m^1*s^-1")]
    [TestCase("1.2m⋅s⁻¹")]
    [TestCase("1.2m¹/s¹")]
    [TestCase("1.2m^1/s¹")]
    public void ParsingSample(string s)
    {
        var speed = Speed.Parse(s,CultureInfo.InvariantCulture);
        Assert.AreEqual(Speed.FromMetresPerSecond(1.2), Speed.Parse(s));
        Assert.IsTrue(Speed.TryParse(s, CultureInfo.InvariantCulture, out speed));
        Assert.AreEqual(Speed.FromMetresPerSecond(1.2), Speed.Parse(s));
    }

- Only the Gu.Units dll is meant for use. The other projects are for generating the code.
- The code is generated from GeneratorSettings.xml, the wpf project is an editor for it. Should probably clean it up and make a wiki about how to use it. Started as a hack to avoid writing xml by hand, never got unhacked.

[nuget package](https://www.nuget.org/packages/Gu.Units/)
