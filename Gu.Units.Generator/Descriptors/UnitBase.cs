namespace Gu.Units.Generator
{
    using System.CodeDom.Compiler;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml.Serialization;
    using WpfStuff;

    public abstract class UnitBase : TypeMetaData, IUnit
    {
        private readonly ParentCollection<UnitBase, Conversion> _conversions;
        private readonly CodeDomProvider _provider = CodeDomProvider.CreateProvider("C#");

        private string _symbol;
        private Quantity _quantity;
        private Settings _settings;

        protected UnitBase()
        {
            _conversions = new ParentCollection<UnitBase, Conversion>(this, (unit, parent) => unit.BaseUnit = parent);
            Quantity = new Quantity(this);
        }

        protected UnitBase(string @namespace, string className, string symbol)
            : base(@namespace, className)
        {
            _conversions = new ParentCollection<UnitBase, Conversion>(this, (unit, parent) => unit.BaseUnit = parent);
            Quantity = new Quantity(this);
            _symbol = symbol;
        }

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (value == _symbol)
                {
                    return;
                }
                _symbol = value;
                this.OnPropertyChanged();
            }
        }

        public string QuantityName
        {
            get
            {
                return Quantity.ClassName;
            }
            set
            {
                if (Quantity.ClassName == value)
                {
                    return;
                }
                Quantity.ClassName = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Conversion> Conversions
        {
            get
            {
                return _conversions;
            }
        }

        [XmlIgnore]
        public bool AnyOffsetConversion
        {
            get { return Conversions.Any(x => x.Formula.Offset != 0); }
        }

        [XmlIgnore]
        public Quantity Quantity
        {
            get { return _quantity; }
            set
            {
                if (Equals(value, _quantity))
                {
                    return;
                }
                _quantity = value;
                this.OnPropertyChanged();
                foreach (var subUnit in Conversions)
                {
                    subUnit.Quantity = _quantity;
                }
            }
        }

        [XmlIgnore]
        public bool IsEmpty
        {
            get
            {
                return string.IsNullOrEmpty(this.ClassName) || string.IsNullOrEmpty(this.Symbol);
            }
        }

        [XmlIgnore]
        public abstract string UiName { get; }

        public bool IsSymbolNameValid
        {
            get
            {
                return _provider.IsValidIdentifier(Symbol);
            }
        }

        [XmlIgnore]
        public Settings Settings
        {
            get { return _settings; }
            set
            {
                if (Equals(value, _settings))
                {
                    return;
                }
                _settings = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return this.UiName;
        }
    }
}