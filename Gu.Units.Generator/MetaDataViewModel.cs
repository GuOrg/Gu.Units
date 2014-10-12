namespace Gu.Units.Generator
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using Annotations;

    public class MetaDataViewModel : INotifyPropertyChanged
    {
        public MetaDataViewModel()
            : this(new Quantity(Settings.NameSpace,"", new UnitAndPower[0]))
        {
        }

        public MetaDataViewModel(Quantity quantity)
        {
            this.Quantity = quantity;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Namespace
        {
            get
            {
                return this.Quantity.Namespace;
            }
            set
            {
                if (value == this.Quantity.Namespace)
                {
                    return;
                }
                this.Quantity.Namespace = value;
                this.OnPropertyChanged();
            }
        }

        public string ValueTypeName
        {
            get
            {
                return this.Quantity.Type.ClassName;
            }
            set
            {
                if (value == this.Quantity.Type.ClassName)
                {
                    return;
                }
                this.Quantity.Type.ClassName = value;
                this.OnPropertyChanged();
            }
        }

        public string UnitTypeName
        {
            get
            {
                return this.Unit.ClassName;
            }
            set
            {
                if (value == Unit.ClassName)
                {
                    return;
                }
                Unit.ClassName = value;
                this.OnPropertyChanged();
            }
        }

        public string Symbol
        {
            get
            {
                return this.Unit.Symbol;
            }
            set
            {
                if (value == Unit.Symbol)
                {
                    return;
                }
                Unit.Symbol = value;
                this.OnPropertyChanged();
            }
        }

        public string Conversion
        {
            get
            {
                return this.Unit.Conversion;
            }
            set
            {
                if (value == Unit.Conversion)
                {
                    return;
                }
                Unit.Conversion = value;
                this.OnPropertyChanged();
            }
        }

        internal Quantity Quantity { get; set; }

        internal Unit Unit { get; set; }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}