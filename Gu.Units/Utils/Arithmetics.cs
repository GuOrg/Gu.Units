namespace Gu.Units.Utils
{
    using System;
    public static class Arithmetics
    {
        public static IQuantity Multiply<TPowerLeft, TPowerRight, TUnit>(IQuantity<TPowerLeft, TUnit> left, IQuantity<TPowerRight, TUnit> right)
            where TPowerLeft : IPower<TUnit>
            where TPowerRight : IPower<TUnit>
            where TUnit : IUnit
        {
            return new Quantity<I2<TUnit>, TUnit>();
        }
    }
}
