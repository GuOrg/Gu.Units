namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Linq;

    public class OperatorOverload
    {
        public static string Divide = "/";
        public static string Multiply = "*";
        public OperatorOverload(Quantity left, Quantity result)
        {
            Left = left;
            Result = result;
            var derivedUnit = result.Unit as DerivedUnit;
            if (derivedUnit != null)
            {
                var right =  Subtract(derivedUnit.Parts.Flattened, left).ToArray();
                if (right.Length == 1)
                {
                    Right = UnitBase.AllUnitsStatic.Single(u => u.ClassName == right.Single().Unit.ClassName).Quantity;
                    Operator = right.Single().Power > 0 ? Multiply : Divide;
                }
            }
            else
            {
                var unit = Left.Unit as DerivedUnit;
                var right = Subtract(unit.Parts.Flattened, result);
                Right = UnitBase.AllUnitsStatic.Single(u => u.ClassName == right.Single().Unit.ClassName).Quantity;
                Operator = right.Single().Power < 0 ? Multiply : Divide;
            }
        }

        public Quantity Left { get; private set; }

        public Quantity Right { get; private set; }

        public Quantity Result { get; private set; }

        public string Operator { get; private set; }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} = {3}", Left.ClassName, Operator, Right.ClassName, Result.ClassName);
        }

        private static IEnumerable<UnitAndPower> Subtract(IEnumerable<UnitAndPower> parts, Quantity minuend)
        {
            var result = parts.ToList();
            var unitAndPower = result.Single(x => x.Unit == minuend.Unit);
            if (unitAndPower.Power == 1)
            {
                result.Remove(unitAndPower);
            }
            else
            {
                unitAndPower.Power--;
            }
            return result;
        }
    }
}