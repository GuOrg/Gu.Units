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
        private readonly ObservableCollection<Conversion> conversions = new ObservableCollection<Conversion>();
        private readonly CodeDomProvider codeDomProvider = CodeDomProvider.CreateProvider("C#");
        private readonly ConversionFormula formula;

        private string symbol;
        private Prefix prefix;
        private IUnit baseUnit;

        public Conversion()
        {
            this.formula = new ConversionFormula(this);
        }

        public Conversion(string className, string symbol)
            : base(className)
        {
            this.symbol = symbol;
            this.formula = new ConversionFormula(this);
        }

        public string Symbol
        {
            get
            {
                return this.symbol;
            }
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

        public ConversionFormula Formula
        {
            get { return this.formula; }
            set
            {
                this.formula.ConversionFactor = value.ConversionFactor;
                this.formula.Offset = value.Offset;
                OnPropertyChanged();
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
        public string UnitName => QuantityName + "Unit";

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
                return this.baseUnit;
            }
            set
            {
                if (Equals(value, this.baseUnit))
                {
                    return;
                }
                this.baseUnit = value;
                this.OnPropertyChanged();
                SyncWithPrefix();
            }
        }

        [XmlIgnore]
        public Prefix Prefix
        {
            get
            {
                return this.prefix;
            }
            set
            {
                if (Equals(value, this.prefix))
                {
                    return;
                }
                this.prefix = value;
                this.OnPropertyChanged();
                SyncWithPrefix();
            }
        }

        [XmlIgnore]
        public bool IsEmpty { get; private set; }

        [XmlIgnore]
        public string UiName { get; private set; }

        public ObservableCollection<Conversion> Conversions => this.conversions;

        public bool AnyOffsetConversion
        {
            get { return Conversions.Any(x => x.Formula.Offset != 0); }
        }

        public bool IsSymbolNameValid => this.codeDomProvider.IsValidIdentifier(Symbol);

        [XmlIgnore]
        public Settings Settings { get; set; }

        private void SyncWithPrefix()
        {
            if (BaseUnit == null || Prefix == null)
            {
                return;
            }
            Formula.ConversionFactor = Math.Pow(10, this.prefix.Power);
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