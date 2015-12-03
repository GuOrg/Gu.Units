namespace Gu.Units
{
    // maybe this should be public idk.
    internal static class Unit<TUnit> where TUnit : struct, IUnit
    {
        internal static readonly TUnit Default = (TUnit)default(TUnit).SiUnit;
    }
}
