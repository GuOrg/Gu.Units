namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using Annotations;

    public class UnitAndPower : INotifyPropertyChanged
    {
        private SiUnit _unit;
        private int _power;
        public UnitAndPower()
        {
            Unit = new SiUnit();
        }

        public UnitAndPower(SiUnit unit)
        {
            Unit = unit;
            Power = 1;
        }
        public UnitAndPower(SiUnit unit, int power)
        {
            if (power == 0)
            {
                throw new ArgumentException("power == 0", "power");
            }
            Unit = unit;
            Power = power;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [XmlIgnore]
        public SiUnit Unit
        {
            get { return _unit; }
            set
            {
                if (Equals(value, _unit))
                {
                    return;
                }
                _unit = value;
                OnPropertyChanged();
                OnPropertyChanged("UnitName");
            }
        }

        public string UnitName
        {
            get
            {
                return Unit.ClassName;
            }
            set
            {
                Unit = new SiUnit { ClassName = value };
            }
        }

        public int Power
        {
            get { return _power; }
            set
            {
                if (value == _power)
                {
                    return;
                }
                _power = value;
                OnPropertyChanged();
            }
        }

        public override string ToString()
        {
            if (Power == 1)
            {
                return Unit.ClassName;
            }
            return string.Format("{0}^{1}", Unit.ClassName, Power);
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
