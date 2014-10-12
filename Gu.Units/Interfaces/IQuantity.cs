namespace Gu.Units
{
    using System;

    public interface IQuantity
    {
        Type GetType();
    }

    public interface IQuantity<out TPower, out TUnit> : IQuantity
        where TPower : IPower<TUnit>
        where TUnit : IUnit
    {
    }

    public struct Quantity<TPower,TUnit> : IQuantity<TPower, TUnit>
        where TPower : IPower<TUnit>
        where TUnit : IUnit
    {
    }

    public interface IQuantity<TPower1,TUnit1,TPower2,TUnit2> : IQuantity
        where TPower1 : IPower<TUnit1>
        where TPower2 : IPower<TUnit2>
        where TUnit1 : IUnit
        where TUnit2 : IUnit
    {
    }

    public interface IQuantity<T1, T2, T3> : IQuantity
        where T1 : IPower<IUnit>
        where T2 : IPower<IUnit>
        where T3 : IPower<IUnit>
    {
    }

    //public interface IQuantity<T1, T2, T3, T4> : IQuantity
    //    where T1 : IPower<IUnit>
    //    where T2 : IPower<IUnit>
    //    where T3 : IPower<IUnit>
    //    where T4 : IPower<IUnit>
    //{
    //}

    public interface IPower<out T> where T : IUnit
    {
    }

    public interface I1<out T> : IPower<T> where T : IUnit
    {
    }

    public interface I2<out T> : IPower<T> where T : IUnit
    {
    }

    public interface I3<out T> : IPower<T> where T : IUnit
    {
    }

    public interface INeg1<out T> : IPower<T> where T : IUnit
    {
    }

    public interface INeg2<out T> : IPower<T> where T : IUnit
    {
    }

    public interface INeg3<out T> : IPower<T> where T : IUnit
    {
    }
}