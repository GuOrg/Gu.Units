namespace Gu.Units.Fsharp.Tests
open NUnit.Framework;
open Gu.Units;
[<Measure>] type sec
[<Measure>] type kg
[<Measure>] type m
[<Measure>] type cm
[<Measure>] type inch

module Tests=
    [<Explicit("Dunno how to use UOM to convert")>]
    [<Test>]
    let ``Centimetres to metres``() =
        let cmValue = Length.FromCentimetres(1.2);
        Assert.AreEqual(1.2<cm>, cmValue.Metres)