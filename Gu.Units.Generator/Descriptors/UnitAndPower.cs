namespace Gu.Units.Generator
{
    using System;
    using System.ComponentModel;
    using System.Linq;

    [Serializable]
    public class UnitAndPower : INotifyPropertyChanged
    {
        private Unit unit;
        public UnitAndPower(string unitName, int power)
        {
            UnitName = unitName;
            Power = power;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public string UnitName { get; }

        public Unit Unit => this.unit ?? (this.unit = Settings.Instance.AllUnits.Single(x => x.Name == UnitName));

        public int Power { get; }

        public static bool operator ==(UnitAndPower left, UnitAndPower right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(UnitAndPower left, UnitAndPower right)
        {
            return !Equals(left, right);
        }

        public static UnitAndPower Create(Unit unit)
        {
            Ensure.NotNull(unit, nameof(unit));
            return new UnitAndPower(unit.Name, 1) { unit = unit };
        }

        public static UnitAndPower Create(Unit unit, int power)
        {
            Ensure.NotNull(unit, nameof(unit));
            Ensure.NotEqual(power, 0, nameof(power));
            return new UnitAndPower(unit.Name, power) { unit = unit };
        }

        public override string ToString()
        {
            if (Power == 1)
            {
                return this.Unit.Symbol;
            }

            return $"{Unit.Symbol}{SuperScript.GetString(Power)}";
        }

        protected bool Equals(UnitAndPower other)
        {
            return string.Equals(UnitName, other.UnitName) && Power == other.Power;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;
            if (ReferenceEquals(this, obj))
                return true;
            if (obj.GetType() != this.GetType())
                return false;
            return Equals((UnitAndPower)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (UnitName.GetHashCode() * 397) ^ Power;
            }
        }
    }
}
