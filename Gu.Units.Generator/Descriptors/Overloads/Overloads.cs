﻿namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Overloads
    {
        public static IReadOnlyList<MissingOverloads> Find(IReadOnlyList<Unit> units)
        {
            var quantities = units.Select(u => u.Quantity).ToList();
            FindInverseOverloads(quantities);
            return FindOperatorOverloads(units.ToList(), quantities)
                .Select(x => new MissingOverloads(x.Key, x.Value))
                .OrderByDescending(x => x.Missing.Count)
                .ToList();
        }

        private static Dictionary<UnitParts, List<MissingOverload>> FindOperatorOverloads(IReadOnlyList<Unit> units, IReadOnlyList<Quantity> quantities)
        {
            var missing = new Dictionary<UnitParts, List<MissingOverload>>();
            foreach (var left in quantities)
            {
                left.OperatorOverloads.Clear();

                foreach (var right in quantities)
                {
                    if (OperatorOverload.TryCreateMultiplication(left, right, units, out var overload))
                    {
                        left.OperatorOverloads.Add(overload);
                    }
                    else
                    {
                        var result = left.Unit.Parts * right.Unit.Parts;
                        if (result.Count == 0)
                        {
                            continue;
                        }

                        if (!missing.TryGetValue(result, out var list))
                        {
                            list = new List<MissingOverload>();
                            missing[result] = list;
                        }

                        list.Add(new MissingOverload(left, OperatorOverload.Multiply, right, result));
                    }

                    if (OperatorOverload.TryCreateDivision(left, right, units, out overload))
                    {
                        left.OperatorOverloads.Add(overload);
                    }
                    else
                    {
                        var result = left.Unit.Parts / right.Unit.Parts;
                        if (result.Count == 0)
                        {
                            continue;
                        }

                        if (!missing.TryGetValue(result, out var list))
                        {
                            list = new List<MissingOverload>();
                            missing[result] = list;
                        }

                        list.Add(new MissingOverload(left, OperatorOverload.Divide, right, result));
                    }
                }
            }

            return missing;
        }

        private static void FindInverseOverloads(IReadOnlyList<Quantity> quantities)
        {
            foreach (var quantity in quantities)
            {
                var match = quantities.FirstOrDefault(x => InverseOverload.IsInverse(quantity, x));
                quantity.Inverse = match is null
                    ? null
                    : new InverseOverload(quantity, match);
            }
        }
    }
}
