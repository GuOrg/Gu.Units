namespace Gu.Units.Generator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using WpfStuff;

    [TypeConverter(typeof(UnitPartsConverter))]
    [Serializable]
    public class UnitParts : IReadOnlyList<UnitAndPower>
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        private ReadonlySet<UnitAndPower> baseParts;

        public UnitParts(IReadOnlyList<UnitAndPower> parts)
        {
            this.Parts = parts;
        }

        public IReadOnlyList<UnitAndPower> Parts { get; }

        public int Count => this.Parts.Count;

        public string Symbol => this.Parts.AsSymbol();

        public string BaseUnitSymbol => this.BaseParts.AsSymbol();

        internal ReadonlySet<UnitAndPower> BaseParts => this.baseParts ?? (this.baseParts = this.CreateBaseParts());

        public UnitAndPower this[int index] => this.Parts[index];

        public static UnitParts operator *(UnitParts left, UnitParts right)
        {
            var result = left.BaseParts.ToList();
            foreach (var rightPart in right.BaseParts)
            {
                var match = result.SingleOrDefault(x => x.UnitName == rightPart.UnitName);
                if (match != null)
                {
                    result.Remove(match);
                    var power = match.Power + rightPart.Power;
                    if (power != 0)
                    {
                        result.Add(new UnitAndPower(match.UnitName, power));
                    }
                }
                else
                {
                    result.Add(rightPart);
                }
            }

            return new UnitParts(result);
        }

        public static UnitParts operator /(UnitParts left, UnitParts right)
        {
            var inverse = right.Inverse();
            return left * inverse;
        }

        public static bool operator ==(UnitParts left, UnitParts right)
        {
            if (Equals(left, null) && Equals(right, null))
            {
                return true;
            }

            if (Equals(left, null) || Equals(right, null))
            {
                return false;
            }

            return left.BaseParts == right.BaseParts;
        }

        public static bool operator !=(UnitParts left, UnitParts right)
        {
            return !(left == right);
        }

        public UnitParts Inverse()
        {
            var unitAndPowers = this.Parts.Select(x => UnitAndPower.Create(x.Unit, -1 * x.Power))
                                    .ToList();
            return new UnitParts(unitAndPowers);
        }

        public IEnumerator<UnitAndPower> GetEnumerator() => this.Parts.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => this.GetEnumerator();

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((UnitParts)obj);
        }

        public override int GetHashCode()
        {
            return this.BaseParts.GetHashCode();
        }

        public override string ToString()
        {
            return this.Symbol;
        }

        protected bool Equals(UnitParts other)
        {
            return this.BaseParts.Equals(other.BaseParts);
        }

        private ReadonlySet<UnitAndPower> CreateBaseParts()
        {
            var all = new List<UnitAndPower>();
            foreach (var part in this.Parts)
            {
                this.GetBaseParts(part, part.Power, all);
            }

            var distinct = all.Select(x => x.Unit).Distinct().ToArray();
            var summed = new List<UnitAndPower>();
            foreach (var unit in distinct)
            {
                var sum = all.Where(x => x.Unit.Name == unit.Name).Sum(x => x.Power);
                if (sum != 0)
                {
                    summed.Add(UnitAndPower.Create(unit, sum));
                }
            }

            return new ReadonlySet<UnitAndPower>(summed);
        }

        private void GetBaseParts(UnitAndPower up, int power, List<UnitAndPower> list)
        {
            if (list.Count > 100)
            {
                Debugger.Break(); // Looks like SO will happen
            }

            if (up.Unit.GetType() == typeof(BaseUnit))
            {
                list.Add(UnitAndPower.Create(up.Unit, power));
                return;
            }

            var derivedUnit = (DerivedUnit)up.Unit;
            foreach (var unitPart in derivedUnit.Parts)
            {
                this.GetBaseParts(unitPart, unitPart.Power * power, list);
            }
        }
    }
}