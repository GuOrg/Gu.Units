namespace Gu.Units.Generator
{
    using System;
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
                var right = Subtract(derivedUnit.Parts.Flattened, left).ToArray();
                Right = Find(right.ToArray());
                Operator = right.Single().Power > 0 ? Multiply : Divide;
            }
            else
            {
                var unit = Left.Unit as DerivedUnit;
                var right = Subtract(unit.Parts.Flattened, result).ToArray();
                Right = Find(right);
                Operator = right.Single().Power < 0 ? Multiply : Divide;
            }
            if (Right == null)
            {
                throw new NotImplementedException("message");
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

        private Quantity Find(params UnitAndPower[] parts)
        {
            IUnit unit = null;
            if (parts.Length == 1 && parts.Single().Power == 1)
            {
                var part = parts.Single();
                unit = UnitBase.AllUnitsStatic.OfType<SiUnit>().SingleOrDefault(u => u.ClassName == part.Unit.ClassName);
            }
            else
            {
                var unitAndPowers = parts.OrderBy(x => x.UnitName).ToArray();
                unit = UnitBase.AllUnitsStatic.OfType<DerivedUnit>().SingleOrDefault(u => u.Parts.OrderBy(x => x.UnitName).SequenceEqual(unitAndPowers, UnitAndPower.Comparer));
            }
            if (unit == null)
            {
                return null;
            }
            return unit.Quantity;
        }
    }
}