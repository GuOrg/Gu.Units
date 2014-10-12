namespace Gu.Units
{
    using System;

    public interface IQuantity
    {
        Type GetType();
    }

    public interface IQuantity<out T> : IQuantity
        where T : IPower<IUnit>
    {
    }

    public struct Quantity<T> : IQuantity<T> where T : IPower<IUnit>
    {
    }

    public interface IQuantity<T1,T2> : IQuantity
        where T1 : IPower<IUnit>
        where T2 : IPower<IUnit>
    {
    }

    public interface IQuantity<T1, T2, T3> : IQuantity
        where T1 : IPower<IUnit>
        where T2 : IPower<IUnit>
        where T3 : IPower<IUnit>
    {
    }

    public interface IQuantity<T1, T2, T3, T4> : IQuantity
        where T1 : IPower<IUnit>
        where T2 : IPower<IUnit>
        where T3 : IPower<IUnit>
        where T4 : IPower<IUnit>
    {
    }

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