namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Xml.Serialization;

    using Annotations;
    using WpfStuff;

    /// <summary>
    /// http://www.periodni.com/international_system_of_units.html
    /// </summary>
    public class SiUnit : UnitBase
    {
        public SiUnit()
            : base(null,null,null)
        {
        }

        public SiUnit(string @namespace, string name, string symbol)
            : base(@namespace, name, symbol)
        {
        }

        [XmlIgnore]
        public override string UiName
        {
            get
            {
                return this.Symbol;
            }
        }

        public override string ToString()
        {
            return this.UiName;
        }
    }
}
