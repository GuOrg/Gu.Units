namespace Gu.Units.Generator
{
    using System;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml.Serialization;

    public abstract class UnitBase : TypeMetaData, IUnit
    {
        public static readonly ObservableCollection<IUnit> AllUnitsStatic = new ObservableCollection<IUnit>();
        private readonly ReadOnlyObservableCollection<IUnit> _allUnitsReadonly;
        private string _symbol;
        private Quantity _quantity;
        private string _quantityName;

        protected UnitBase(string @namespace, string className, string symbol)
            : base(@namespace, className)
        {
            _symbol = symbol;
            this.PropertyChanged += (sender, args) =>
            {
                TryAdd();
            };
            TryAdd();
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
                if(Quantity !=null)
                    return this.Quantity.ClassName;
                return _quantityName;
            }
            set
            {
                if (Quantity != null)
                {
                    throw new InvalidOperationException("Trying to set quantity");
                }
                _quantityName = value;
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
        protected bool Equals(UnitBase other)
        {
            return string.Equals(_symbol, other._symbol);
        }
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((UnitBase) obj);
        }
        public override int GetHashCode()
        {
            return _symbol.GetHashCode();
        }
        public static bool operator ==(UnitBase left, UnitBase right)
        {
            return Equals(left, right);
        }
        public static bool operator !=(UnitBase left, UnitBase right)
        {
            return !Equals(left, right);
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
    }
}