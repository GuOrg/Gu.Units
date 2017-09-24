namespace Gu.Units.Analyzers.Tests
{
    using Gu.Roslyn.Asserts;
    using NUnit.Framework;

    public class ToLengthCodeFixProviderTests
    {
        [Test]
        public void IntToMillimetres()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Foo()
        {
            Bar = ↓1;
        }

        public Length Bar { get; }
    }
}";

            var fixedCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Foo()
        {
            Bar = Length.FromMillimetres(1);
        }

        public Length Bar { get; }
    }
}";
            AnalyzerAssert.CodeFix<ToLengthCodeFixProvider>("CS0029", testCode, fixedCode);
        }

        [Test]
        [Explicit("ToDo")]
        public void NullableIntToMillimetres()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        private static int? value = 0;
        private static Length Foo => value.Value; 
    }
}";

            var fixedCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        private static int? value = 0;
        private static Length Foo => Length.FromMillimetres(value.Value); 
    }
}";
            AnalyzerAssert.CodeFix<ToLengthCodeFixProvider>("CS0029", testCode, fixedCode);
        }

        [Test]
        public void NegativeIntToMillimetres()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Foo()
        {
            Bar = ↓-1;
        }

        public Length Bar { get; }
    }
}";

            var fixedCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Foo()
        {
            Bar = Length.FromMillimetres(-1);
        }

        public Length Bar { get; }
    }
}";
            AnalyzerAssert.CodeFix<ToLengthCodeFixProvider>("CS0029", testCode, fixedCode);
        }

        [Test]
        public void DoubleToMillimetres()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Foo()
        {
            Bar = ↓1.2;
        }

        public Length Bar { get; }
    }
}";

            var fixedCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Foo()
        {
            Bar = Length.FromMillimetres(1.2);
        }

        public Length Bar { get; }
    }
}";
            AnalyzerAssert.CodeFix<ToLengthCodeFixProvider>("CS0029", testCode, fixedCode);
        }

        [Test]
        public void NegativeDoubleToMillimetres()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Length Bar { get; } = ↓-1.2;
    }
}";

            var fixedCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Length Bar { get; } = Length.FromMillimetres(-1.2);
    }
}";
            AnalyzerAssert.CodeFix<ToLengthCodeFixProvider>("CS0029", testCode, fixedCode);
        }

        [Test]
        [Explicit("Dunno if there is a need to support this")]
        public void ExpressionToMillimetres()
        {
            var testCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Length Bar { get; } = ↓-1.2 + 2.3;
    }
}";

            var fixedCode = @"
namespace RoslynSandbox
{
    using Gu.Units;

    public class Foo
    {   
        public Length Bar { get; } = Length.FromMillimetres(-1.2 + 2.3);
    }
}";
            AnalyzerAssert.CodeFix<ToLengthCodeFixProvider>("CS0029", testCode, fixedCode);
        }
    }
}