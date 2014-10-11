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
            throw new NotImplementedException("message");
        }
    }
}