namespace Gu.Units.Generator.Tests.Scripts
{
    using System;
    using System.Linq;
    using NUnit.Framework;

    public class DumpOperatorTestCases
    {
        [Test]
        public void Multiplications()
        {
            var settings = Settings.Instance;
            foreach (var quantity in settings.Quantities)
            {
                foreach (var overload in quantity.OperatorOverloads.Where(o => o.Operator == "*"))
                {
                    Console.WriteLine($"{overload.Left.Name}.From{overload.Left.Unit.Name}(1.2) * {overload.Right.Name}.From{overload.Right.Unit.Name}(3.4) == {overload.Result.Name}.From{overload.Result.Unit.Name}(4.08);");
                }
            }
        }

        [Test]
        public void Divisions()
        {
            var settings = Settings.Instance;
            foreach (var quantity in settings.Quantities)
            {
                foreach (var overload in quantity.OperatorOverloads.Where(o => o.Operator == "/"))
                {
                    Console.WriteLine($"{overload.Left.Name}.From{overload.Left.Unit.Name}(1.2) / {overload.Right.Name}.From{overload.Right.Unit.Name}(3.4) == {overload.Result.Name}.From{overload.Result.Unit.Name}(0.3529411764705882);");
                }
            }
        }
    }
}
