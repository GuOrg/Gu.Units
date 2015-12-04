namespace Gu.Units.Generator
{
    using System.CodeDom.Compiler;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml.Serialization;
    using WpfStuff;

    public abstract class UnitBase : TypeMetaData, IUnit
    {
        private readonly ParentCollection<UnitBase, Conversion> conversions;
        private readonly CodeDomProvider provider = CodeDomProvider.CreateProvider("C#");

        private string symbol;
        private Quantity quantity;
        private Settings settings;

        protected UnitBase()
        {
            this.conversions = new ParentCollection<UnitBase, Conversion>(this, (unit, parent) => unit.BaseUnit = parent);
            Quantity = new Quantity(this);
        }

        protected UnitBase(string className, string symbol)
            : base(className)
        {
            this.conversions = new ParentCollection<UnitBase, Conversion>(this, (unit, parent) => unit.BaseUnit = parent);
            Quantity = new Quantity(this);
            this.symbol = symbol;
        }

        public string Symbol
        {
            get { return this.symbol; }
            set
            {
                if (value == this.symbol)
                {
                    return;
                }
                this.symbol = value;
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
                OnPropertyChanged(nameof(UnitName));
            }
        }

        [XmlIgnore]
        public string UnitName => QuantityName + "Unit";

        public ObservableCollection<Conversion> Conversions => this.conversions;

        [XmlIgnore]
        public bool AnyOffsetConversion
        {
            get { return Conversions.Any(x => x.Formula.Offset != 0); }
        }

        [XmlIgnore]
        public Quantity Quantity
        {
            get { return this.quantity; }
            set
            {
                if (Equals(value, this.quantity))
                {
                    return;
                }
                this.quantity = value;
                this.OnPropertyChanged();
                foreach (var subUnit in Conversions)
                {
                    subUnit.Quantity = this.quantity;
                }
            }
        }

        [XmlIgnore]
        public bool IsEmpty => string.IsNullOrEmpty(this.ClassName) || string.IsNullOrEmpty(this.Symbol);

        [XmlIgnore]
        public abstract string UiName { get; }

        public bool IsSymbolNameValid => this.provider.IsValidIdentifier(Symbol);

        [XmlIgnore]
        public Settings Settings
        {
            get { return this.settings; }
            set
            {
                if (Equals(value, this.settings))
                {
                    return;
                }
                this.settings = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            return this.UiName;
        }
    }
}