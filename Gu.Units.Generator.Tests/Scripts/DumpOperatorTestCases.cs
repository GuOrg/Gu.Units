namespace Gu.Units.Generator.Tests.Scripts
{
    using System;
    using System.Linq;
    using System.Text;
    using NUnit.Framework;

    public class DumpOperatorTestCases
    {
        [Test]
        public void Multiplications()
        {
            Settings.InnerInstance = null;
            var settings = Settings.FromResource;
            var builder = new StringBuilder();
            foreach (var quantity in settings.Quantities)
            {
                foreach (var overload in quantity.OperatorOverloads.Where(o => o.Operator == "*"))
                {
                    builder.AppendLine($"[TestCase(\"return {overload.Left.Name}.From{overload.Left.Unit.Name}(1.2) * {overload.Right.Name}.From{overload.Right.Unit.Name}(3.4) == {overload.Result.Name}.From{overload.Result.Unit.Name}(4.08);\")]");
                }
            }

            var text = builder.ToString();
            Console.WriteLine(text);
        }

        [Test]
        public void Divisions()
        {
            Settings.InnerInstance = null;
            var settings = Settings.FromResource;
            var builder = new StringBuilder();
            foreach (var quantity in settings.Quantities)
            {
                foreach (var overload in quantity.OperatorOverloads.Where(o => o.Operator == "/"))
                {
                    builder.AppendLine($"[TestCase(\"return {overload.Left.Name}.From{overload.Left.Unit.Name}(1.2) / {overload.Right.Name}.From{overload.Right.Unit.Name}(3.4) == {overload.Result.Name}.From{overload.Result.Unit.Name}(0.35294117647058826);\")]");
                }
            }

            var text = builder.ToString();
            Console.WriteLine(text);
        }
    }
}
