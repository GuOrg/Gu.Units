namespace Gu.Units
{
    using System;

    public interface IQuantity<in TUnit> : IQuantity
        where TUnit : IUnit
    {
        double GetValue(TUnit unit);
        string ToString(TUnit unit);
        string ToString(TUnit unit, SymbolFormat symbolFormat);
        string ToString(TUnit unit, IFormatProvider formatProvider);
        string ToString(TUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider);
        string ToString(string valueFormat, TUnit unit);
        string ToString(string valueFormat, TUnit unit, SymbolFormat symbolFormat);
        string ToString(string valueFormat, TUnit unit, IFormatProvider formatProvider);
        string ToString(string valueFormat, TUnit unit, SymbolFormat symbolFormat, IFormatProvider formatProvider);
    }
}