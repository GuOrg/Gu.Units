namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using Annotations;

    public class UnitAndPower : INotifyPropertyChanged
    {
        private SiUnit _siUnit;
        private int _power;
        public UnitAndPower()
        {
            this.SiUnit = new SiUnit();
        }

        public UnitAndPower(SiUnit siUnit)
        {
            this.SiUnit = siUnit;
            Power = 1;
        }
      
        public UnitAndPower(SiUnit siUnit, int power)
        {
            if (power == 0)
            {
                throw new ArgumentException("power == 0", "power");
            }
            this.SiUnit = siUnit;
            Power = power;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static UnitAndPower Empty
        {
            get
            {
                return new UnitAndPower(new SiUnit(), 0);
            }
        }

        [XmlIgnore]
        public SiUnit SiUnit
        {
            get { return this._siUnit; }
            set
            {
                if (Equals(value, this._siUnit))
                {
                    return;
                }
                this._siUnit = value;
                OnPropertyChanged();
                OnPropertyChanged("UnitName");
            }
        }

        public string UnitName
        {
            get
            {
                return this.SiUnit.ClassName;
            }
            set
            {
                this.SiUnit = new SiUnit { ClassName = value };
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
                return this.SiUnit.ClassName;
            }
            return string.Format("{0}^{1}", this.SiUnit.ClassName, Power);
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

        protected bool Equals(UnitAndPower other)
        {
            return Equals(this._siUnit, other._siUnit) && this._power == other._power;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            if (ReferenceEquals(this, obj))
            {
                return true;
            }
            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            return Equals((UnitAndPower)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((this._siUnit != null ? this._siUnit.GetHashCode() : 0) * 397) ^ this._power;
            }
        }
    }
}
