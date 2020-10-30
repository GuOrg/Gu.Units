namespace Gu.Units.Generator
{
    using System;

    [Serializable]
#pragma warning disable CA1716 // Identifiers should not match keywords
    public enum Operator
#pragma warning restore CA1716 // Identifiers should not match keywords
    {
        None,
        Multiply,
        Divide,
    }
}