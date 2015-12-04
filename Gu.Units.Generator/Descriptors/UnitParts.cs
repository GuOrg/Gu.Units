namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Gu.Units.Generator.WpfStuff;

    [TypeConverter(typeof(UnitPartsConverter))]
    public class UnitParts : ParentCollection<IUnit, UnitAndPower>, INotifyPropertyChanged
    {
        private static readonly BaseUnitOrderComparer _baseUnitOrderComparer = new BaseUnitOrderComparer();
        public UnitParts(IUnit baseUnit, IEnumerable<UnitAndPower> parts)
            : base(baseUnit, (up, u) => up.Parent = u, parts)
        {
            base.CollectionChanged += (sender, args) =>
            {
                base.OnPropertyChanged(new PropertyChangedEventArgs(nameof(Expression)));
                base.OnPropertyChanged(new PropertyChangedEventArgs(nameof(BaseUnitExpression)));
            };
        }

        public UnitParts(IUnit baseUnit, params UnitAndPower[] parts)
            : this(baseUnit, (IEnumerable<UnitAndPower>)parts)
        {
        }

        public static UnitParts CreateFrom(Quantity quantity)
        {
            var siUnit = quantity.Unit as SiUnit;
            if (siUnit != null)
            {
                return new UnitParts(siUnit, new UnitAndPower(siUnit, 1));
            }
            var derivedUnit = quantity.Unit as DerivedUnit;
            return new UnitParts(derivedUnit, derivedUnit.Parts);
        }

        public IEnumerable<UnitAndPower> Flattened
        {
            get
            {
                var all = new List<UnitAndPower>();
                foreach (var up in this)
                {
                    GetAll(up, up.Power, all);
                }
                var distinct = all.Select(x => x.Unit).Distinct().ToArray();
                foreach (SiUnit unit in distinct)
                {
                    var sum = all.Where(x => x.UnitName == unit.ClassName).Sum(x => x.Power);
                    if (sum != 0)
                    {
                        yield return new UnitAndPower(unit, sum);
                    }
                }
            }
        }

        [XmlIgnore]
        public string Expression => CreateExpression(this.AsEnumerable());

        [XmlIgnore]
        public string BaseUnitExpression => CreateExpression(Flattened);

        [XmlIgnore]
        public string UnitName
        {
            get
            {
                var builder = new StringBuilder();
                int sign = 1;
                foreach (var up in this)
                {
                    if (sign == 1 && up.Power < 0)
                    {
                        builder.Append("Per");
                        sign = -1;
                    }
                    var p = Math.Abs(up.Power);
                    switch (p)
                    {
                        case 1:
                            break;
                        case 2:
                            builder.Append("Square");
                            break;
                        case 3:
                            builder.Append("Cubic");
                            break;
                        default:
                            throw new NotImplementedException("message");
                    }
                    if (up.Power > 0)
                    {
                        builder.Append(up.UnitName);
                    }
                    else
                    {
                        builder.Append(up.UnitName.TrimEnd('s'));
                    }
                }
                return builder.ToString();
            }
        }

        public static UnitParts operator *(UnitParts left, UnitParts right)
        {
            var leftPowers = left.Flattened.ToList();
            var rightPowers = right.Flattened.ToList();
            foreach (var rightPower in rightPowers.ToArray())
            {
                var leftPower = leftPowers.SingleOrDefault(x => x.UnitName == rightPower.UnitName);
                if (leftPower != null)
                {
                    if (leftPower.Power == (-1 * rightPower.Power))
                    {
                        leftPowers.Remove(leftPower);
                    }
                    leftPower.Power += rightPower.Power;
                    rightPowers.Remove(rightPower);
                }
            }
            leftPowers.AddRange(rightPowers.Select(x => new UnitAndPower(x.Unit, x.Power)));
            return new UnitParts(null, leftPowers);
        }

        public static UnitParts operator /(UnitParts left, UnitParts right)
        {
            var leftPowers = left.Flattened.ToList();
            var rightPowers = right.Flattened.ToList();
            foreach (var rightPower in rightPowers.ToArray())
            {
                var leftPower = leftPowers.SingleOrDefault(x => x.UnitName == rightPower.UnitName);
                if (leftPower != null)
                {
                    if (leftPower.Power == rightPower.Power)
                    {
                        leftPowers.Remove(leftPower);
                    }
                    leftPower.Power -= rightPower.Power;
                    rightPowers.Remove(rightPower);
                }
            }
            leftPowers.AddRange(rightPowers.Select(x => new UnitAndPower(x.Unit, -1 * x.Power)));
            return new UnitParts(null, leftPowers);
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
            var leftPowers = left.Flattened.OrderBy(x => x.UnitName).ToArray();
            var rightPowers = right.Flattened.OrderBy(x => x.UnitName).ToArray();
            if (leftPowers.Count() != rightPowers.Count())
            {
                return false;
            }
            return leftPowers.SequenceEqual(rightPowers, UnitAndPower.Comparer);
        }

        public static bool operator !=(UnitParts left, UnitParts right)
        {
            return !(left == right);
        }

        public void Replace(UnitAndPower old, UnitAndPower @new)
        {
            var indexOf = base.IndexOf(old);
            base.RemoveAt(indexOf);
            base.Insert(indexOf, @new);
        }

        public override string ToString()
        {
            return this.Expression;
        }

        private void GetAll(UnitAndPower up, int power, List<UnitAndPower> list)
        {
            if (list.Count > 100)
            {
                Debugger.Break(); // Looks like SO will happen
            }
            if (up.Unit is SiUnit)
            {
                list.Add(new UnitAndPower(up.Unit, power));
                return;
            }
            var derivedUnit = (DerivedUnit)up.Unit;
            foreach (var unitPart in derivedUnit.Parts)
            {
                GetAll(unitPart, unitPart.Power * power, list);
            }
        }

        private string CreateExpression(IEnumerable<UnitAndPower> ups)
        {
            if (!this.Any())
            {
                return "";
            }
            var sb = new StringBuilder();
            UnitAndPower previous = null;
            foreach (var unitAndPower in ups.OrderBy(x => x, _baseUnitOrderComparer).ToArray())
            {
                if (previous != null)
                {
                    sb.Append("⋅");
                }
                sb.Append(unitAndPower.Unit == null ? unitAndPower.UnitName : unitAndPower.Unit.Symbol);
                if (unitAndPower.Power < 0)
                {
                    sb.Append("⁻");
                    if (unitAndPower.Power == -1)
                    {
                        sb.Append("¹");
                    }
                }
                switch (Math.Abs(unitAndPower.Power))
                {
                    case 1:
                        break;
                    case 2:
                        sb.Append("²");
                        break;
                    case 3:
                        sb.Append("³");
                        break;
                    case 4:
                        sb.Append("⁴");
                        break;
                    default:
                        sb.Append("^")
                          .Append(Math.Abs(unitAndPower.Power));
                        break;
                }
                previous = unitAndPower;
            }
            return sb.ToString();
        }

        public class BaseUnitOrderComparer : IComparer<UnitAndPower>
        {
            private readonly string[] _order = { "kg", "m", "s", "A", "cd", "mol" };
            public int Compare(UnitAndPower x, UnitAndPower y)
            {
                var indexOfX = Array.IndexOf(_order, x.Unit.Symbol);
                var indexOfY = Array.IndexOf(_order, y.Unit.Symbol);
                if (indexOfX < 0 && indexOfY < 0)
                {
                    return String.Compare(x.Unit.Symbol, y.Unit.Symbol, StringComparison.Ordinal);
                }
                return indexOfX.CompareTo(indexOfY);
            }
        }
    }
}