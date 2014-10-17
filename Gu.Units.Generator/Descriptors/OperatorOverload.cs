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
            Right = FindRight(left, Result);
            if (Right == null)
            {
                throw new ArgumentException(string.Format("Cannot create overload for {0} * x = {1}", left.ClassName, Result.ClassName));
            }
            var power = this.FindPower(Left, Right, Result);
            Operator = power > 0 ? Multiply : Divide;
        }

        public Quantity Left { get; private set; }

        public Quantity Right { get; private set; }

        public Quantity Result { get; private set; }

        public string Operator { get; private set; }

        public static bool CanCreate(Quantity left, Quantity result)
        {
            return FindRight(left, result) != null;
        }

        public static Quantity FindRight(Quantity left, Quantity result)
        {
            var derivedUnit = result.Unit as DerivedUnit;
            if (derivedUnit != null)
            {
                var right = Subtract(derivedUnit.Parts.Flattened, left).ToArray();
                return Find(right.ToArray());
            }
            else
            {
                var unit = left.Unit as DerivedUnit;
                var right = Subtract(unit.Parts.Flattened, result).ToArray();
                return Find(right);
            }
        }

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

        private static Quantity Find(params UnitAndPower[] parts)
        {
            IUnit unit = null;
            if (parts.Length == 1 && Math.Abs(parts.Single().Power) == 1)
            {
                var part = parts.Single();
                unit = UnitBase.AllUnitsStatic.OfType<SiUnit>().SingleOrDefault(u => u.ClassName == part.Unit.ClassName);
            }
            else
            {
                var unitAndPowers = parts.OrderBy(x => x.UnitName).ToArray();
                unit = UnitBase.AllUnitsStatic.OfType<DerivedUnit>().SingleOrDefault(u => u.Parts.OrderBy(x => x.UnitName).SequenceEqual(unitAndPowers, UnitAndPower.Comparer));
                if (unit == null)
                {
                    unitAndPowers = unitAndPowers.Select(x => new UnitAndPower(x.Unit, -1 * x.Power)).ToArray();
                    unit = UnitBase.AllUnitsStatic.OfType<DerivedUnit>().SingleOrDefault(u => u.Parts.OrderBy(x => x.UnitName).SequenceEqual(unitAndPowers, UnitAndPower.Comparer));
                }
            }
            if (unit == null)
            {
                return null;
            }
            return unit.Quantity;
        }

        /// <summary>
        /// Solves left * right^x = result
        /// Where x =±1
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        private int FindPower(Quantity left, Quantity right, Quantity result)
        {
            throw new NotImplementedException("message");

            //SiUnit siUnit = left.Unit as SiUnit;
            //if (siUnit != null)
            //{
            //    var unitAndPower = right.Single();
            //    if (Math.Abs(unitAndPower.Power) != 1)
            //    {
            //        throw new ArgumentException();
            //    }
            //    return unitAndPower.Power;
            //}
            //else
            //{
            //    DerivedUnit derivedUnit = (DerivedUnit)left.Unit;
            //    var unitAndPowers = derivedUnit.Parts.OrderBy(x => x.UnitName).ToArray();
            //    var andPowers = right.OrderBy(x => x.UnitName).ToArray();
            //    if (unitAndPowers.Select(x => x.Power).SequenceEqual(andPowers.Select(x => x.Power)))
            //    {
            //        return 1;
            //    }
            //    if (unitAndPowers.Select(x => x.Power).SequenceEqual(andPowers.Select(x =>-1* x.Power)))
            //    {
            //        return -1;
            //    }
            //    throw new ArgumentException("message");
            //}
        }
    }
}