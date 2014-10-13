namespace Gu.Units.Generator
{
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;

    public abstract class UnitBase : TypeMetaData, IUnit
    {
        public static readonly ObservableCollection<IUnit> AllUnitsStatic = new ObservableCollection<IUnit>();
        private readonly ReadOnlyObservableCollection<IUnit> _allUnitsReadonly;
        private string _symbol;
        private Quantity _quantity;

        protected UnitBase(string @namespace, string className, string symbol)
            : base(@namespace, className)
        {
            _symbol = symbol;
            AllUnitsStatic.Add(this);
            _allUnitsReadonly = new ReadOnlyObservableCollection<IUnit>(AllUnitsStatic);
        }

        public string Symbol
        {
            get { return this._symbol; }
            set
            {
                if (value == this._symbol)
                {
                    return;
                }
                this._symbol = value;
                this.OnPropertyChanged();
            }
        }

        public string QuantityName
        {
            get
            {
                return this.Quantity.ClassName;
            }
            set
            {
                if (Quantity == null)
                {
                    this.Quantity = Generator.Quantity.Empty;
                }
                this.Quantity.ClassName = value;
            }
        }

        [XmlIgnore]
        public Quantity Quantity
        {
            get { return this._quantity; }
            set
            {
                if (Equals(value, this._quantity))
                {
                    return;
                }
                this._quantity = value;
                this.OnPropertyChanged();
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

        [XmlIgnore]
        public ReadOnlyObservableCollection<IUnit> AllUnits
        {
            get
            {
                return _allUnitsReadonly;
            }
        }

        public override string ToString()
        {
            return this.UiName;
        }
    }
}