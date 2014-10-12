namespace Gu.Units.Generator
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows;
    using System.Xml.Serialization;

    using Annotations;
    using WpfStuff;
    /// <summary>
    /// http://www.periodni.com/international_system_of_units.html
    /// </summary>
    public class SiUnit : TypeMetaData, INotifyPropertyChanged
    {
        private string _symbol;
        private Quantity _quantity;

        public SiUnit()
        {
            _quantity = new Quantity("", "", this);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string Symbol
        {
            get { return _symbol; }
            set
            {
                if (value == _symbol)
                {
                    return;
                }
                _symbol = value;
                OnPropertyChanged();
            }
        }

        public Quantity Quantity
        {
            get { return _quantity; }
            set
            {
                if (Equals(value, _quantity))
                {
                    return;
                }
                _quantity = value;
                foreach (var unit in _quantity.Units)
                {
                    unit.Unit = this;
                }
                OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
