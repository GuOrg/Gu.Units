namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Gu.Units.Generator.WpfStuff;

    [TypeConverter(typeof(UnitPartsConverter))]
    public class UnitParts : ObservableCollection<UnitAndPower>
    {
        public IEnumerable<UnitAndPower> Flattened
        {
            get
            {
                var all = new List<UnitAndPower>();
                foreach (var up in this)
                {
                    GetAll(up, 0, all);
                }
                foreach (SiUnit unit in all.Select(x => x.Unit).Distinct())
                {
                    var sum = all.Where(x => Equals(x.Unit, unit)).Sum(x => x.Power);
                    if (sum != 0)
                    {
                        yield return new UnitAndPower(unit, sum);
                    }
                }
            }
        }

        [XmlIgnore]
        public string UiName
        {
            get
            {
                if (!this.Any())
                {
                    return "ERROR No Units";
                }
                var sb = new StringBuilder();
                UnitAndPower previous = null;
                foreach (var unitAndPower in this)
                {
                    if (previous != null)
                    {
                        if (previous.Power > 0 && unitAndPower.Power < 0)
                        {
                            sb.Append(" / ");
                        }
                        else
                        {
                            sb.Append("⋅");
                        }
                    }
                    sb.Append(unitAndPower.Unit.Symbol);
                    if (Math.Abs(unitAndPower.Power) > 1)
                    {
                        sb.Append("^")
                          .Append(Math.Abs(unitAndPower.Power));
                    }
                    previous = unitAndPower;
                }
                return sb.ToString();
            }
        }

        private void GetAll(UnitAndPower up, int power, List<UnitAndPower> list)
        {
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
    }
}