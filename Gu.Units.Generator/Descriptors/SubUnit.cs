namespace Gu.Units.Generator
{
    using System.Collections.ObjectModel;
    using System.Xml.Serialization;

    public class SubUnit : TypeMetaData, ISubUnit
    {
        private string _symbol;
        private Quantity _quantity;
        private string _quantityName;
        private double conversionFactor;
        private Prefix _prefix;
        private UnitBase _baseUnit;

        private readonly ObservableCollection<SubUnit> _subUnits = new ObservableCollection<SubUnit>();

        public SubUnit()
        {
            
        }

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
                ConversionFactor = _prefix.Factor;
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

        public double ConversionFactor
        {
            get
            {
                return this.conversionFactor;
            }
            set
            {
                if (value == this.conversionFactor)
                {
                    return;
                }
                this.conversionFactor = value;
                this.OnPropertyChanged();
            }
        }

        public ObservableCollection<SubUnit> SubUnits
        {
            get
            {
                return this._subUnits;
            }
        }

        [XmlIgnore]
        public bool IsEmpty { get; private set; }

        [XmlIgnore]
        public string UiName { get; private set; }
    }
}