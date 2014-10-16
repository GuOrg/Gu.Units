namespace Gu.Units.Generator
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Collections.Specialized;
    using System.Linq;
    using System.Xml.Serialization;

    public abstract class UnitBase : TypeMetaData, IUnit
    {
        public static readonly ObservableCollection<IUnit> AllUnitsStatic = new ObservableCollection<IUnit>();
        private readonly ReadOnlyObservableCollection<IUnit> _allUnitsReadonly;
        private readonly ObservableCollection<SubUnit> _subUnits = new ObservableCollection<SubUnit>();
        private readonly CodeDomProvider _provider = CodeDomProvider.CreateProvider("C#");

        private string _symbol;
        private Quantity _quantity;
        private string _quantityName;

        protected UnitBase(string @namespace, string className, string symbol)
            : base(@namespace, className)
        {
            _symbol = symbol;
            this.PropertyChanged += (sender, args) => this.TryAdd();
            TryAdd();
            _allUnitsReadonly = new ReadOnlyObservableCollection<IUnit>(AllUnitsStatic);
            _subUnits.CollectionChanged += SubUnitsOnCollectionChanged;
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
                if (Quantity != null)
                {
                    return this.Quantity.ClassName;
                }
                return _quantityName;
            }
            set
            {
                if (Quantity != null)
                {
                    this.Quantity.ClassName = value;
                }
                else
                {
                    _quantityName = value;
                }
            }
        }

        public ObservableCollection<SubUnit> SubUnits
        {
            get
            {
                return _subUnits;
            }
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
                foreach (var subUnit in SubUnits)
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

        [XmlIgnore]
        public ReadOnlyObservableCollection<IUnit> AllUnits
        {
            get
            {
                return _allUnitsReadonly;
            }
        }

        public bool IsSymbolNameValid
        {
            get
            {
                return _provider.IsValidIdentifier(Symbol);
            }
        }

        public override string ToString()
        {
            return this.UiName;
        }

        private void TryAdd()
        {
            if (!IsEmpty)
            {
                if (AllUnitsStatic.All(x => !(x.Symbol == this.Symbol && x.ClassName == this.ClassName)))
                {
                    AllUnitsStatic.Add(this);
                }
            }
        }

        private void SubUnitsOnCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (var subUnit in e.NewItems.OfType<SubUnit>())
                {
                    subUnit.Quantity = this.Quantity;
                    subUnit.BaseUnit = this;
                }
            }
        }
    }
}