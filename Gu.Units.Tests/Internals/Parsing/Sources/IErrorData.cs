namespace Gu.Units.Tests.Internals.Parsing
{
    using System;

    public interface IErrorData
    {
        Type Type { get; }

        object Expected { get; }

        string ExpectedMessage { get; }

        string Text { get; }

        int Start { get; }

        int ExpectedEnd { get; }
    }
}