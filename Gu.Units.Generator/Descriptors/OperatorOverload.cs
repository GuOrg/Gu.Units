namespace Gu.Units.Generator
{
    using System;
    using System.Linq;

    public class OperatorOverload
    {
        public static string Divide = "/";
        public static string Multiply = "*";
        public OperatorOverload(Quantity left, Quantity result, Settings settings)
        {
            Left = left;
            Result = result;
            Right = FindRight(settings, left, Result);
            if (Right == null)
            {
                throw new ArgumentException($"Cannot create overload for {left.ClassName} * x = {Result.ClassName}");
            }
            var power = this.FindPower(Left, Right, Result);
            Operator = power > 0 ? Multiply : Divide;
        }

        public Quantity Left { get; private set; }

        public Quantity Right { get; private set; }

        public Quantity Result { get; private set; }

        public string Operator { get; private set; }

        public static bool CanCreate(Settings settings, Quantity left, Quantity result)
        {
            return FindRight(settings, left, result) != null;
        }

        public static Quantity FindRight(Settings settings, Quantity left, Quantity result)
        {
            var derivedUnit = result.Unit as DerivedUnit;
            if (derivedUnit != null)
            {
                var right = UnitParts.CreateFrom(result) / UnitParts.CreateFrom(left);
                return Find(settings, right.Flattened.ToArray());
            }
            else
            {
                var right = UnitParts.CreateFrom(left) / UnitParts.CreateFrom(result);
                return Find(settings, right.Flattened.ToArray());
            }
        }

        public override string ToString()
        {
            return $"{Left.ClassName} {Operator} {Right.ClassName} = {Result.ClassName}";
        }

        private static Quantity Find(Settings settings, params UnitAndPower[] parts)
        {
            IUnit unit = null;
            if (parts.Length == 1 && Math.Abs(parts.Single().Power) == 1)
            {
                var part = parts.Single();
                unit = settings.SiUnits.SingleOrDefault(u => u.ClassName == part.Unit.ClassName);
            }
            else
            {
                var unitAndPowers = parts.OrderBy(x => x.UnitName).ToArray();
                unit = settings.DerivedUnits.SingleOrDefault(u => u.Parts.OrderBy(x => x.UnitName).SequenceEqual(unitAndPowers, UnitAndPower.Comparer));
                if (unit == null)
                {
                    unitAndPowers = unitAndPowers.Select(x => new UnitAndPower(x.Unit, -1 * x.Power)).ToArray();
                    unit = settings.DerivedUnits.SingleOrDefault(u => u.Parts.OrderBy(x => x.UnitName).SequenceEqual(unitAndPowers, UnitAndPower.Comparer));
                }
            }
            return unit?.Quantity;
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
            var leftParts = UnitParts.CreateFrom(left);
            var rightParts = UnitParts.CreateFrom(right);
            var resultParts = UnitParts.CreateFrom(result);
            if (leftParts * rightParts == resultParts)
            {
                return 1;
            }
            if (leftParts / rightParts == resultParts)
            {
                return -1;
            }
            else
            {
                throw new ArgumentException(
                    $"Cound not find power for {left.ClassName}*{right.ClassName}^x == {result.ClassName}");
            }
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
            //    if (unitAndPowers.Select(x => x.Power).SequenceEqual(andPowers.Select(x => -1 * x.Power)))
            //    {
            //        return -1;
            //    }
            //    throw new ArgumentException("message");
            //}
        }
    }
}