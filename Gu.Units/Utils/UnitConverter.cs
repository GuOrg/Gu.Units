namespace Gu.Units
{
    using System;

    public class UnitConverter
    {
        public static double ConvertFrom<T>(double value, T unit) where T : IUnit
        {
            return unit.ToSiUnit(value);
        }

        public static double ConvertTo<T>(double siValue, T unit) where T : IUnit
        {
            return siValue / unit.ToSiUnit(1.0); // This will not work for temperature. Leaving for now as it will prolly be big changes in conversion
        }
    }
}