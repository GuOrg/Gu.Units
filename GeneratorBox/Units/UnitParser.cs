namespace GeneratorBox
{
    using System;

    public class UnitParser
    {
        public static TValue Parse<TUnit, TValue>(string s, Func<double, TUnit, TValue> @from) 
            where TUnit : IUnit 
            where TValue : IUnitValue
        {
            throw new NotImplementedException();
        }
    }
}