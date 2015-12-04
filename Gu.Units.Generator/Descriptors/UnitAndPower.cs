namespace Gu.Units.Generator
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Xml.Serialization;
    using Annotations;

    public class UnitAndPower : INotifyPropertyChanged
    {
        public static readonly IEqualityComparer<UnitAndPower> Comparer = new UnitNamePowerEqualityComparer();

        private IUnit unit;
        private string unitName;
        private int power;
        private IUnit parent;
        private UnitAndPower()
        {
        }

        public UnitAndPower(IUnit unit)
        {
            this.unit = unit;
            this.power = 1;
        }

        public UnitAndPower(IUnit unit, int power)
        {
            if (power == 0)
            {
                throw new ArgumentException("power == 0", nameof(power));
            }
            this.unit = unit;
            this.power = power;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [XmlIgnore]
        public IUnit Unit
        {
            get
            {
                return this.unit ?? (this.unit = Parent.Settings.AllUnits.Single(x => x.ClassName == this.unitName));
            }
            set
            {
                if (Equals(value, this.unit))
                {
                    return;
                }
                this.unit = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(UnitName));
            }
        }

        public string UnitName
        {
            get
            {
                if (Unit != null)
                {
                    return this.Unit.ClassName;
                }
                return this.unitName;
            }
            set
            {
                this.unitName = value;
            }
        }

        public int Power
        {
            get { return this.power; }
            set
            {
                if (value == this.power)
                {
                    return;
                }
                this.power = value;
                OnPropertyChanged();
            }
        }

        [XmlIgnore]
        public IUnit Parent
        {
            get { return this.parent; }
            set
            {
                this.parent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(Unit));
            }
        }

        public static UnitAndPower operator ^(UnitAndPower up, int i)
        {
            return new UnitAndPower(up.Unit, up.Power * i);
        }

        public override string ToString()
        {
            if (Power == 1)
            {
                if (Unit == null)
                {
                    return $"(({UnitName})null)^1";
                }
                return this.Unit.Symbol;
            }
            return $"({(this.Unit == null ? "null" : "")}){this.UnitName}^{Power}";
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool Equals(UnitAndPower other)
        {
            return Equals(this.unit, other.unit) && this.power == other.power;
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
                return ((this.unit?.GetHashCode() ?? 0) * 397) ^ this.power;
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
                return string.Equals(x.UnitName, y.UnitName) && x.power == y.power;
            }

            public int GetHashCode(UnitAndPower obj)
            {
                unchecked
                {
                    return ((obj.unitName?.GetHashCode() ?? 0) * 397) ^ obj.power;
                }
            }
        }
    }
}
