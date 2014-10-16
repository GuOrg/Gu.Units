namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using Annotations;

    public class UnitAndPower : INotifyPropertyChanged
    {
        private IUnit _unit;
        private string _unitName;
        private int _power;
        public UnitAndPower()
        {
        }

        public UnitAndPower(IUnit unit)
        {
            _unit = unit;
            _power = 1;
        }

        public UnitAndPower(IUnit unit, int power)
        {
            if (power == 0)
            {
                throw new ArgumentException("power == 0", "power");
            }
            _unit = unit;
            _power = power;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public static readonly IEqualityComparer<UnitAndPower> Comparer = new UnitNamePowerEqualityComparer();

        public static UnitAndPower Empty
        {
            get
            {
                return new UnitAndPower()
                           {
                               _unit = null,
                               _power = 0
                           };
            }
        }

        [XmlIgnore]
        public IUnit Unit
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
                if (Unit != null)
                    return this.Unit.ClassName;
                return _unitName;
            }
            set
            {
                if (Unit != null)
                {
                    throw new InvalidOperationException("Trying to set unit name");
                }
                _unitName = value;
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
                if (Unit == null)
                {
                    return string.Format("(({0})null)^1", UnitName);
                }
                return this.Unit.Symbol;
            }
            return string.Format("({0}){1}^{2}", this.Unit == null ? "null" : "", this.UnitName, Power);
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
            return Equals(_unit, other._unit) && _power == other._power;
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
                return ((_unit != null ? _unit.GetHashCode() : 0) * 397) ^ _power;
            }
        }

        private sealed class UnitNamePowerEqualityComparer : IEqualityComparer<UnitAndPower>
        {
            public bool Equals(UnitAndPower x, UnitAndPower y)
            {
                if (ReferenceEquals(x, y))
                {
                    return true;
                }
                if (ReferenceEquals(x, null))
                {
                    return false;
                }
                if (ReferenceEquals(y, null))
                {
                    return false;
                }
                if (x.GetType() != y.GetType())
                {
                    return false;
                }
                return string.Equals(x.UnitName, y.UnitName) && x._power == y._power;
            }
            public int GetHashCode(UnitAndPower obj)
            {
                unchecked
                {
                    return ((obj._unitName != null ? obj._unitName.GetHashCode() : 0) * 397) ^ obj._power;
                }
            }
        }

    }
}
