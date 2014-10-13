namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Gu.Units.Generator.WpfStuff;

    [TypeConverter(typeof(UnitPartsConverter))]
    public class UnitParts : ObservableCollection<UnitAndPower>
    {
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
                    sb.Append(unitAndPower.SiUnit.Symbol);
                    if (Math.Abs(unitAndPower.Power) > 1)
                    {
                        sb.Append("^")
                          .Append(unitAndPower.Power);
                    }
                    previous = unitAndPower;
                }
                return sb.ToString();
            }
        }
    }
}