namespace Gu.Units.Generator
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Linq;
    using System.Runtime.Remoting.Channels;
    using System.Text;
    using System.Xml.Serialization;

    using Gu.Units.Generator.WpfStuff;

    [TypeConverter(typeof(UnitPartsConverter))]
    public class UnitParts : ObservableCollection<UnitAndPower>
    {
        public UnitParts(IEnumerable<UnitAndPower> parts)
            : base(parts)
        {
        }

        public UnitParts(params UnitAndPower[] parts)
            : base(parts)
        {
        }

        public UnitParts()
        {
            this.CollectionChanged += (sender, args) =>
                {
                    this.OnPropertyChanged(new PropertyChangedEventArgs("Expression"));
                    if (args.NewItems != null)
                    {
                        foreach (var newItem in args.NewItems.OfType<INotifyPropertyChanged>())
                        {
                            newItem.PropertyChanged += this.OnPartPropertyChanged;
                        }
                    }
                    if (args.OldItems != null)
                    {
                        foreach (var oldItem in args.OldItems.OfType<INotifyPropertyChanged>())
                        {
                            oldItem.PropertyChanged -= this.OnPartPropertyChanged;
                        }
                    }
                };
        }

        public static UnitParts CreateFrom(Quantity quantity)
        {
            var siUnit = quantity.Unit as SiUnit;
            if (siUnit != null)
            {
                return new UnitParts(new UnitAndPower(siUnit, 1));
            }
            var derivedUnit = quantity.Unit as DerivedUnit;
            return new UnitParts(derivedUnit.Parts);
        }

        public IEnumerable<UnitAndPower> Flattened
        {
            get
            {
                var all = new List<UnitAndPower>();
                foreach (var up in this)
                {
                    GetAll(up, 0, all);
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
            return new UnitParts(leftPowers);
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
            return new UnitParts(leftPowers);
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

        [XmlIgnore]
        public string Expression
        {
            get { return CreateExpression(this.AsEnumerable()); }
        }

        [XmlIgnore]
        public string BaseUnitExpression
        {
            get { return CreateExpression(Flattened); }
        }

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
                Debugger.Break();
            }
            if (up.Unit is SiUnit)
            {
                list.Add(new UnitAndPower(up.Unit, up.Power + power));
                return;
            }
            var derivedUnit = (DerivedUnit)up.Unit;
            foreach (var unitPart in derivedUnit.Parts)
            {
                GetAll(unitPart, up.Power - 1, list);
            }
        }

        private void OnPartPropertyChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            this.OnPropertyChanged(new PropertyChangedEventArgs("Expression"));
        }

        private string CreateExpression(IEnumerable<UnitAndPower> ups)
        {
            if (!this.Any())
            {
                return "ERROR No Units";
            }
            var sb = new StringBuilder();
            UnitAndPower previous = null;
            foreach (var unitAndPower in ups)
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
                    default:
                        sb.Append("^")
                          .Append(Math.Abs(unitAndPower.Power));
                        break;
                }
                previous = unitAndPower;
            }
            return sb.ToString();
        }
    }
}