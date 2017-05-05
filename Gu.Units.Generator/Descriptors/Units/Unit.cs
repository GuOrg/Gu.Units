namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Newtonsoft.Json;

    [Serializable]
    public abstract class Unit : INameAndSymbol, INotifyPropertyChanged
    {
        private readonly Quantity quantity;
        private string name;
        private string symbol;
        private string quantityName;

        protected Unit(string name, string symbol, string quantityName)
        {
            this.name = name;
            this.symbol = symbol;
            this.quantityName = quantityName;
            this.quantity = new Quantity(this);
        }

        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        public abstract UnitParts Parts { get; }

        [JsonProperty(Order = 3)]
        public ObservableCollection<FactorConversion> FactorConversions { get; } = new ObservableCollection<FactorConversion>();

        [JsonProperty(Order = 4)]
        public ObservableCollection<CustomConversion> CustomConversions { get; } = new ObservableCollection<CustomConversion>();

        [JsonProperty(Order = 5)]
        public ObservableCollection<PrefixConversion> PrefixConversions { get; } = new ObservableCollection<PrefixConversion>();

        [JsonProperty(Order = 6)]
        public ObservableCollection<PartConversion> PartConversions { get; } = new ObservableCollection<PartConversion>();

        public string ClassName => this.QuantityName + "Unit";

        public string ParameterName => this.Name.ToParameterName();

        public string XDocParameterName => this.Name.FirstCharLower();

        public Quantity Quantity => this.quantity;

        public IEnumerable<IConversion> AllConversions
        {
            get
            {
                foreach (var conversion in this.FactorConversions)
                {
                    yield return conversion;
                    foreach (var nested in conversion.PrefixConversions)
                    {
                        yield return nested;
                    }
                }

                foreach (var offsetConversion in this.CustomConversions)
                {
                    yield return offsetConversion;
                }

                foreach (var prefixConversion in this.PrefixConversions)
                {
                    yield return prefixConversion;
                }

                foreach (var partConversion in this.PartConversions)
                {
                    yield return partConversion;
                }
            }
        }

        [JsonProperty(Order = 0)]
        public string Name
        {
            get => this.name;
            set
            {
                if (value == this.name)
                {
                    return;
                }

                this.name = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.ParameterName));
                this.OnPropertyChanged(nameof(this.XDocParameterName));
            }
        }

        [JsonProperty(Order = 1)]
        public string Symbol
        {
            get => this.symbol;
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

        [JsonProperty(Order = 2)]
        public string QuantityName
        {
            get => this.quantityName;
            set
            {
                if (value == this.quantityName)
                {
                    return;
                }

                this.quantityName = value;
                this.OnPropertyChanged();
                this.OnPropertyChanged(nameof(this.ClassName));
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}