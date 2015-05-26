namespace Gu.Units.Generator
{
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using System.Xml.Serialization;

    public class Conversion : TypeMetaData, IUnit
    {
        private readonly ObservableCollection<Conversion> _conversions = new ObservableCollection<Conversion>();
        private readonly CodeDomProvider _codeDomProvider = CodeDomProvider.CreateProvider("C#");
        private readonly ConversionFormula _formula;

        private string _symbol;
        private Prefix _prefix;
        private IUnit _baseUnit;

        public Conversion()
        {
            _formula = new ConversionFormula(this);
        }

        public Conversion(string className, string symbol)
            : base(className)
        {
            _symbol = symbol;
            _formula = new ConversionFormula(this);
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

        public ConversionFormula Formula
        {
            get { return _formula; }
            set
            {
                _formula.ConversionFactor = value.ConversionFactor;
                _formula.Offset = value.Offset;
                OnPropertyChanged();
                OnPropertyChanged("ConversionFactor");
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
        public string UnitName
        {
            get
            {
                return QuantityName + "Unit";
            }
        }

        [XmlIgnore]
        public Quantity Quantity
        {
            get
            {
                return BaseUnit.Quantity;
            }
            set { throw new NotImplementedException(); }
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

        public ObservableCollection<Conversion> Conversions
        {
            get { return _conversions; }
        }

        public bool AnyOffsetConversion
        {
            get { return Conversions.Any(x => x.Formula.Offset != 0); }
        }

        public bool IsSymbolNameValid
        {
            get
            {
                return _codeDomProvider.IsValidIdentifier(Symbol);
            }
        }

        [XmlIgnore]
        public Settings Settings { get; set; }

        private void SyncWithPrefix()
        {
            if (BaseUnit == null || Prefix == null)
            {
                return;
            }
            Formula.ConversionFactor = Math.Pow(10, _prefix.Power);
            if (string.IsNullOrEmpty(Symbol))
            {
                Symbol = Prefix.Symbol + BaseUnit.Symbol;
            }
            if (string.IsNullOrEmpty(ClassName))
            {
                ClassName = Prefix.Name + BaseUnit.ParameterName;
            }
        }

        public void SetParts(IEnumerable<Conversion> subunits)
        {
            var derivedUnit = BaseUnit as DerivedUnit;
            if (derivedUnit == null)
            {
                throw new InvalidOperationException("trying to set partunits when baseunit != DerivedUnit");
            }
            double cf = 1;
            var unitParts = new UnitParts(derivedUnit, derivedUnit.Parts.ToArray());
            foreach (var part in subunits)
            {
                var up = unitParts.Single(x => x.UnitName == part.BaseUnit.ClassName);
                cf = cf * Math.Pow(part.Formula.ConversionFactor, up.Power);
                unitParts.Replace(up, new UnitAndPower(part, up.Power));
            }
            Formula.ConversionFactor = cf;
            ClassName = unitParts.UnitName;
            Symbol = unitParts.Expression;
        }
    }
}