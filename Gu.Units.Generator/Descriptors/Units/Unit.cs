namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;

    [Serializable]
    public abstract class Unit : INameAndSymbol, INotifyPropertyChanged
    {
        private readonly Quantity quantity;
        private string name;
        private string symbol;
        private string quantityName;

        protected Unit(string name,
            string symbol,
            string quantityName)
        {
            this.name = name;
            this.symbol = symbol;
            this.quantityName = quantityName;
            this.quantity = new Quantity(this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == this.name)
                    return;
                this.name = value;
                OnPropertyChanged();
            }
        }

        public string ClassName => QuantityName + "Unit";

        public string ParameterName => Name.ToParameterName();

        public string Symbol
        {
            get { return this.symbol; }
            set
            {
                if (value == this.symbol)
                    return;
                this.symbol = value;
                OnPropertyChanged();
            }
        }

        public abstract UnitParts Parts { get; }

        public string QuantityName
        {
            get { return this.quantityName; }
            set
            {
                if (value == this.quantityName)
                    return;
                this.quantityName = value;
                OnPropertyChanged();
            }
        }

        public Quantity Quantity => this.quantity;

        public ObservableCollection<FactorConversion> FactorConversions { get; } = new ObservableCollection<FactorConversion>();

        public ObservableCollection<CustomConversion> CustomConversions { get; } = new ObservableCollection<CustomConversion>();

        public ObservableCollection<PrefixConversion> PrefixConversions { get; } = new ObservableCollection<PrefixConversion>();

        public ObservableCollection<PartConversion> PartConversions { get; } = new ObservableCollection<PartConversion>();

        public IEnumerable<IConversion> AllConversions
        {
            get
            {
                foreach (var conversion in FactorConversions)
                {
                    yield return conversion;
                    foreach (var nested in conversion.PrefixConversions)
                    {
                        yield return nested;
                    }
                }

                foreach (var offsetConversion in CustomConversions)
                {
                    yield return offsetConversion;
                }

                foreach (var prefixConversion in PrefixConversions)
                {
                    yield return prefixConversion;
                }

                foreach (var partConversion in PartConversions)
                {
                    yield return partConversion;
                }
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}