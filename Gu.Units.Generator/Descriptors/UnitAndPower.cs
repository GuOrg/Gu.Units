namespace Gu.Units.Generator
{
    using System;
    using System.Linq;

    [Serializable]
    public sealed class UnitAndPower
    {
        private Unit unit;

        public UnitAndPower(string unitName, int power)
        {
            this.UnitName = unitName;
            this.Power = power;
        }

        public string UnitName { get; }

        public Unit Unit => this.unit ??= Settings.Instance.AllUnits.Single(x => x.Name == this.UnitName);

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
            if (unit is null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            return new UnitAndPower(unit.Name, 1) { unit = unit };
        }

        public static UnitAndPower Create(Unit unit, int power)
        {
            if (unit is null)
            {
                throw new ArgumentNullException(nameof(unit));
            }

            if (power == 0)
            {
                throw new ArgumentException("Power is zero.", nameof(power));
            }

            return new UnitAndPower(unit.Name, power) { unit = unit };
        }

        public override string ToString()
        {
            if (this.Power == 1)
            {
                return this.Unit.Symbol;
            }

            return $"{this.Unit.Symbol}{SuperScript.GetString(this.Power)}";
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(UnitAndPower))
            {
                return false;
            }

            return this.Equals((UnitAndPower)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (this.UnitName.GetHashCode() * 397) ^ this.Power;
            }
        }

        private bool Equals(UnitAndPower other)
        {
            return string.Equals(this.UnitName, other.UnitName, StringComparison.Ordinal) && this.Power == other.Power;
        }
    }
}
