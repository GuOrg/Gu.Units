namespace Gu.Units.Generator
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml.Serialization;

    public class SubUnit : TypeMetaData, ISubUnit
    {
        private readonly ObservableCollection<SubUnit> _subUnits = new ObservableCollection<SubUnit>();
        private readonly CodeDomProvider _provider = CodeDomProvider.CreateProvider("C#");
     
        private string _symbol;
        private double _conversionFactor;
        private Quantity _quantity;
        private string _quantityName;
        private Prefix _prefix;
        private IUnit _baseUnit;

        public SubUnit()
        {

        }

        public SubUnit(string @namespace, string className, string symbol, double conversionFactor)
            : base(@namespace, className)
        {
            _symbol = symbol;
            _conversionFactor = conversionFactor;
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

        public double ConversionFactor
        {
            get
            {
                return _conversionFactor;
            }
            set
            {
                if (value == _conversionFactor)
                {
                    return;
                }
                _conversionFactor = value;
                this.OnPropertyChanged();
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
        public string QuantityName
        {
            get
            {
                if (Quantity == null)
                {
                    return "Error no quantity";
                }
                return Quantity.ClassName;
            }
            set
            {
                throw new InvalidOperationException("Implementing this just cos IUnit, too lazy to refactor now");
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
        public IUnit BaseUnit
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
                SyncWithPrefix();
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
                SyncWithPrefix();
            }
        }

        [XmlIgnore]
        public bool IsEmpty { get; private set; }

        [XmlIgnore]
        public string UiName { get; private set; }

        public bool IsSymbolNameValid
        {
            get
            {
                return _provider.IsValidIdentifier(Symbol);
            }
        }

        private void SyncWithPrefix()
        {
            if (BaseUnit == null || Prefix == null)
            {
                return;
            }
            ConversionFactor = Math.Pow(10, _prefix.Factor);
            if (string.IsNullOrEmpty(Symbol))
            {
                Symbol = Prefix.Symbol + BaseUnit.Symbol;
            }
            if (string.IsNullOrEmpty(ClassName))
            {
                ClassName = Prefix.Name + BaseUnit.ParameterName;
            }
        }

        public void SetParts(IEnumerable<SubUnit> subunits)
        {
            var derivedUnit = BaseUnit as DerivedUnit;
            if (derivedUnit == null)
            {
                throw new InvalidOperationException("trying to set partunits when baseunit != DerivedUnit");
            }
            double cf = 1;
            var unitParts = new UnitParts(derivedUnit.Parts.ToArray());
            foreach (var part in subunits)
            {
                var up = unitParts.Single(x => x.UnitName == part.BaseUnit.ClassName);
                cf = cf * Math.Pow(part.ConversionFactor, up.Power);
                unitParts.Replace(up, new UnitAndPower(part, up.Power));
            }
            ConversionFactor = cf;
            ClassName = unitParts.UnitName;
            Symbol = unitParts.Expression;
        }
    }
}