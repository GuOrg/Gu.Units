namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Globalization;

    public interface ISuccessData
    {
        Type Type { get; }

        object Expected { get; }

        int ExpectedEnd { get; }

        int Start { get; }

        string Text { get; }

        CultureInfo CultureInfo { get; }
    }
}