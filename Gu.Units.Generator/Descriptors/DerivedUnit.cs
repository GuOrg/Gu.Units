namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Xml.Serialization;

    using Gu.Units.Generator.WpfStuff;

    [Serializable]
    public class DerivedUnit : UnitBase
    {
        private readonly UnitParts _parts = new UnitParts();
        private bool _explicitName;

        public DerivedUnit()
            : base(null, null, null)
        {
            _parts.CollectionChanged += PartsOnCollectionChanged;
        }

        public DerivedUnit(string @namespace, string name, string symbol, params UnitAndPower[] parts)
            : base(@namespace, name, symbol)
        {
            if (parts.Length == 0)
            {
                throw new ArgumentException("No units", "units");
            }
            if (parts.Length != parts.Select(x => x.Unit.ClassName).Distinct().Count())
            {
                throw new ArgumentException("Units must be distinct", "units");
            }
            var unitAndPowers = parts.OrderBy(x => x.Unit).ThenBy(x => x.Power).ToList();
            foreach (var unitAndPower in unitAndPowers)
            {
                _parts.Add(unitAndPower);
            }
            _parts.CollectionChanged += PartsOnCollectionChanged;
        }

        public static DerivedUnit Empty
        {
            get
            {
                return new DerivedUnit();
            }
        }

        public UnitParts Parts
        {
            get
            {
                return _parts;
            }
            set
            {
                _parts.Clear();
                _parts.InvokeAddRange(value);
            }
        }

        public bool ExplicitName
        {
            get { return _explicitName; }
            set
            {
                if (value.Equals(_explicitName))
                {
                    return;
                }
                _explicitName = value;
                OnPropertyChanged();
            }
        }

        [XmlIgnore]
        public override string UiName
        {
            get
            {
                return Parts.Expression;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}  ({1})", Symbol, this.UiName);
        }

        private void PartsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs notifyCollectionChangedEventArgs)
        {
            if (string.IsNullOrEmpty(ClassName))
            {
                ClassName = _parts.UnitName;
                ExplicitName = false;
            }
        }
    }
}