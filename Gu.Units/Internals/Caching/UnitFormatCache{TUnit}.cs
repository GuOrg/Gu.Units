namespace Gu.Units
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    internal static class UnitFormatCache<TUnit>
        where TUnit : struct, IUnit, IEquatable<TUnit>
    {
        private static readonly Lazy<Caches> LazyCache = new Lazy<Caches>(() => new Caches());

        internal static Caches Cache => LazyCache.Value;

        internal static PaddedFormat GetOrCreate(string format, out TUnit unit)
        {
            if (string.IsNullOrEmpty(format))
            {
                unit = Unit<TUnit>.Default;
                return PaddedFormat.NullFormat;
            }

            var pos = 0;
            return GetOrCreate(format, ref pos, out unit);
        }

        internal static PaddedFormat GetOrCreate(TUnit unit, SymbolFormat symbolFormat)
        {
            if (!Cache.TryGetParts(unit, out var symbolAndPowers))
            {
                throw new ArgumentOutOfRangeException($"Did not find parts for {unit.Symbol}");
            }

            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append(symbolAndPowers, symbolFormat);
                var format = builder.ToString();
                return new PaddedFormat(null, format, null);
            }
        }

        internal static PaddedFormat GetOrCreate(string format, ref int pos, out TUnit unit)
        {
            var start = pos;
            _ = WhiteSpaceReader.TryRead(format, ref pos, out var prePadding);
            if (format == null ||
                pos == format.Length)
            {
                pos = start;
                unit = Unit<TUnit>.Default;
                return PaddedFormat.CreateUnknown(prePadding, null);
            }

            if (Cache.TryGetUnitForSymbol(format, ref pos, out var symbol, out unit))
            {
                if (WhiteSpaceReader.IsRestWhiteSpace(format, pos))
                {
                    _ = WhiteSpaceReader.TryRead(format, ref pos, out var postPadding);
                    return new PaddedFormat(prePadding, symbol, postPadding);
                }

                pos -= symbol.Length;
            }

            if (SymbolAndPowerReader.TryRead(format, ref pos, out IReadOnlyList<SymbolAndPower> symbolsAndPowers))
            {
                symbol = format.Substring(start, pos - start);

                _ = WhiteSpaceReader.TryRead(format, ref pos, out var postPadding);
                if (!WhiteSpaceReader.IsRestWhiteSpace(format, pos))
                {
                    pos = start;
                    unit = Unit<TUnit>.Default;
                    return PaddedFormat.CreateUnknown(prePadding, format.Substring(start));
                }

                if (Cache.TryGetUnitForParts(symbolsAndPowers, out unit))
                {
                    Cache.Add(symbol, symbolsAndPowers);
                    Cache.Add(symbol, unit);
                }
                else
                {
                    pos = start;
                    unit = Unit<TUnit>.Default;
                    return PaddedFormat.CreateUnknown(prePadding, format.Substring(start));
                }

                return new PaddedFormat(prePadding, symbol, postPadding);
            }

            pos = start;
            return PaddedFormat.CreateUnknown(prePadding, format);
        }

        internal class Caches
        {
            private readonly Map<ReadonlySet<SymbolAndPower>, TUnit> unitPartsMap = new Map<ReadonlySet<SymbolAndPower>, TUnit>();
            private readonly StringMap<TUnit> symbolUnitMap = new StringMap<TUnit>();
            private readonly StringMap<IReadOnlyList<SymbolAndPower>> symbolPartsMap = new StringMap<IReadOnlyList<SymbolAndPower>>();

            internal Caches()
            {
                var units = GetUnits();
                foreach (var unit in units)
                {
                    _ = this.symbolUnitMap.Add(unit.Symbol, unit);

                    var pos = 0;
                    if (SymbolAndPowerReader.TryRead(unit.Symbol, ref pos, out IReadOnlyList<SymbolAndPower> result))
                    {
                        if (!WhiteSpaceReader.IsRestWhiteSpace(unit.Symbol, pos))
                        {
                            throw new InvalidOperationException($"Failed splitting {((IUnit)unit).Symbol} into {nameof(SymbolAndPower)}");
                        }

                        if (result.Count == 0)
                        {
                            throw new InvalidOperationException($"Did not find any parts in {unit.Symbol}");
                        }

                        _ = this.symbolPartsMap.Add(unit.Symbol, result);
                        var sapSet = new ReadonlySet<SymbolAndPower>(result);
                        this.unitPartsMap.TryAdd(sapSet, unit);
                    }
                }
            }

            internal void Add(string symbol, IReadOnlyList<SymbolAndPower> parts)
            {
                _ = this.symbolPartsMap.Add(symbol, parts);
            }

            internal void Add(string symbol, TUnit unit)
            {
                _ = this.symbolUnitMap.Add(symbol, unit);
            }

            internal bool TryGetParts(TUnit unit, out IReadOnlyList<SymbolAndPower> result)
            {
                return this.symbolPartsMap.TryGet(unit.Symbol, out result);
            }

            internal bool TryGetUnitForSymbol(string text, ref int pos, out string symbol, out TUnit result)
            {
                var success = this.symbolUnitMap.TryGetBySubString(text, pos, out symbol, out var temp);
                if (success)
                {
                    pos += symbol.Length;
                    result = temp;
                    return true;
                }

                result = Unit<TUnit>.Default;
                return false;
            }

            internal bool TryGetUnitForSymbol(string text, ref int pos, out TUnit result)
            {
                var success = this.symbolUnitMap.TryGetBySubString(text, pos, out var key, out var temp);
                if (success)
                {
                    pos += key.Length;
                    result = temp;
                    return true;
                }

                result = Unit<TUnit>.Default;
                return false;
            }

            internal bool TryGetUnitForParts(IReadOnlyList<SymbolAndPower> symbolsAndPowers, out TUnit unit)
            {
                var set = new ReadonlySet<SymbolAndPower>(symbolsAndPowers);
                return this.unitPartsMap.TryGet(set, out unit);
            }

            private static IReadOnlyList<TUnit> GetUnits()
            {
                var units = typeof(TUnit).GetFields(BindingFlags.GetField | BindingFlags.Public | BindingFlags.Static)
                    .Where(f => f.FieldType == typeof(TUnit))
                    .Select(f => (TUnit)f.GetValue(null))
                    .Distinct()
                    .ToList();
                return units;
            }
        }
    }
}