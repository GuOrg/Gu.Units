namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using JetBrains.Annotations;

    [Serializable]
    public class CustomConversion : IConversion, INotifyPropertyChanged
    {
        private string name;
        private string symbol;
        private Unit unit;
        private string toSi;
        private string fromSi;

        public CustomConversion(string name,
            string symbol,
            string toSi,
            string fromSi)
        {
            this.name = name;
            this.symbol = symbol;
            this.toSi = toSi;
            this.fromSi = fromSi;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Name
        {
            get { return this.name; }
            set
            {
                if (value == this.name)
                {
                    return;
                }

                this.name = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(ToSi));
                OnPropertyChanged(nameof(FromSi));
                OnPropertyChanged(nameof(ParameterName));
            }
        }

        public string ParameterName => Name.ToParameterName();

        public string Symbol
        {
            get { return this.symbol; }
            set
            {
                if (value == this.symbol)
                {
                    return;
                }

                this.symbol = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SymbolConversion));
            }
        }

        public string ToSi
        {
            get { return this.toSi; }
            set
            {
                if (value == this.toSi)
                    return;
                this.toSi = value;
                OnPropertyChanged();
                OnPropertyChanged(SymbolConversion);
                OnPropertyChanged(nameof(CanRoundtrip));
                try
                {
                    var temp = ExpressionParser.Evaluate(1, ParameterName, value);
                }
                catch (Exception e)
                {
                    throw new ArgumentException("Failed roundtripping", e);
                }
            }
        }

        public string FromSi
        {
            get { return this.fromSi; }
            set
            {
                if (value == this.fromSi)
                {
                    return;
                }

                this.fromSi = value;
                OnPropertyChanged();
                OnPropertyChanged(SymbolConversion);
                OnPropertyChanged(nameof(CanRoundtrip));

                try
                {
                    var temp = ExpressionParser.Evaluate(1, Unit.ParameterName, value);
                }
                catch (Exception e)
                {
                    throw new ArgumentException(e.Message, e);
                }
            }
        }

        public string SymbolConversion => this.GetSymbolConversion();

        public Unit Unit => this.unit ?? (this.unit = this.GetUnit());

        public bool CanRoundtrip => this.CanRoundtrip();

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}