namespace Gu.Units
{
    using System;

    public interface IQuantity
    {
        Type GetType();
        double SiValue { get; }
    }

    public interface IQuantity<TUnit> : IQuantity
        where TUnit : IUnit
    {
    }

    public interface IQuantity<TUnit, TPower> : IQuantity
        where TUnit : IUnit
        where TPower : IPower
    {
    }

    public interface IQuantity<TUnit1, TPower1, TUnit2, TPower2> : IQuantity
        where TUnit1 : IUnit
        where TPower1 : IPower
        where TUnit2 : IUnit
        where TPower2 : IPower
    {
    }

    public interface IQuantity<TUnit1, TPower1, TUnit2, TPower2, TUnit3, TPower3> : IQuantity
        where TUnit1 : IUnit
        where TPower1 : IPower
        where TUnit2 : IUnit
        where TPower2 : IPower
        where TUnit3 : IUnit
        where TPower3 : IPower
    {
    }

    public interface IQuantity<TUnit1, TPower1, TUnit2, TPower2, TUnit3, TPower3, TUnit4, TPower4> : IQuantity
        where TUnit1 : IUnit
        where TPower1 : IPower
        where TUnit2 : IUnit
        where TPower2 : IPower
        where TUnit3 : IUnit
        where TPower3 : IPower
        where TUnit4 : IUnit
        where TPower4 : IPower
    {
    }
}