namespace Gu.Units.Generator
{
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;

    public class SubUnit : TypeMetaData, ISubUnit
    {
        private string _symbol;
        private Quantity _quantity;
        private string _quantityName;
        private string _conversion;

        private Prefix _prefix;

        private UnitBase _baseUnit;

        private readonly ObservableCollection<SubUnit> _subUnits = new ObservableCollection<SubUnit>();

        public string Symbol
        {
            get
            {
                return _symbol;
            }
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
                return _quantityName;
            }
            set
            {
                if (value == _quantityName)
                {
                    return;
                }
                _quantityName = value;
                this.OnPropertyChanged();
            }
        }

        [XmlIgnore]
        public Quantity Quantity
        {
            get
            {
                return _quantity;
            }
            set
            {
                if (Equals(value, _quantity))
                {
                    return;
                }
                _quantity = value;
                this.OnPropertyChanged();
            }
        }

        [XmlIgnore]
        public Prefix Prefix
        {
            get
            {
                return _prefix;
            }
            set
            {
                if (Equals(value, _prefix))
                {
                    return;
                }
                _prefix = value;
                this.OnPropertyChanged();
            }
        }

        [XmlIgnore]
        public UnitBase BaseUnit
        {
            get
            {
                return _baseUnit;
            }
            set
            {
                if (Equals(value, _baseUnit))
                {
                    return;
                }
                _baseUnit = value;
                this.OnPropertyChanged();
            }
        }

        public string Conversion
        {
            get
            {
                return _conversion;
            }
            set
            {
                if (value == _conversion)
                {
                    return;
                }
                _conversion = value;
                this.OnPropertyChanged();
            }
        }

        [XmlIgnore]
        public bool IsEmpty { get; private set; }

        [XmlIgnore]
        public string UiName { get; private set; }

        [XmlIgnore]
        public ObservableCollection<SubUnit> SubUnits
        {
            get
            {
                return this._subUnits;
            }
        }
    }
}