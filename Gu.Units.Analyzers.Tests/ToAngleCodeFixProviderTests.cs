namespace Gu.Units.Analyzers.Tests
{
    using Gu.Roslyn.Asserts;
    using NUnit.Framework;

    [Explicit("Fix later.")]
    public class ToAngleCodeFixProviderTests
    {
        [Test]
        public void IntToDegrees()
        {
            var testCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Foo()
            {
                Bar = 1;
            }

            public Angle Bar { get; }
        }
    }";

            var fixedCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Foo()
            {
                Bar = Angle.FromDegrees(1);
            }

            public Angle Bar { get; }
        }
    }";
            AnalyzerAssert.CodeFix<ToAngleCodeFixProvider>("CS0266", testCode, fixedCode);
        }

        [Test]
        public void IntToNullableDegrees()
        {
            var testCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Foo()
            {
                Bar = 1;
            }

            public Angle? Bar { get; }
        }
    }";

            var fixedCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Foo()
            {
                Bar = Angle.FromDegrees(1);
            }

            public Angle? Bar { get; }
        }
    }";
            AnalyzerAssert.CodeFix<ToAngleCodeFixProvider>("CS0266", testCode, fixedCode);
        }

        [Test]
        public void NegativeIntToDegrees()
        {
            var testCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Foo()
            {
                Bar = -1;
            }

            public Angle Bar { get; }
        }
    }";

            var fixedCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Foo()
            {
                Bar = Angle.FromDegrees(-1);
            }

            public Angle Bar { get; }
        }
    }";
            AnalyzerAssert.CodeFix<ToAngleCodeFixProvider>("CS0266", testCode, fixedCode);
        }

        [Test]
        public void DoubleToDegrees()
        {
            var testCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Foo()
            {
                Bar = 1.2;
            }

            public Angle Bar { get; }
        }
    }";

            var fixedCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Foo()
            {
                Bar = Angle.FromDegrees(1.2);
            }

            public Angle Bar { get; }
        }
    }";
            AnalyzerAssert.CodeFix<ToAngleCodeFixProvider>("CS0266", testCode, fixedCode);
        }

        [Test]
        public void NegativeDoubleToDegrees()
        {
            var testCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Angle Bar { get; } = -1.2;
        }
    }";

            var fixedCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Angle Bar { get; } = Angle.FromDegrees(-1.2);
        }
    }";
            AnalyzerAssert.CodeFix<ToAngleCodeFixProvider>("CS0266", testCode, fixedCode);
        }

        [Test]
        [Explicit("Dunno if there is a need to support this")]
        public void ExpressionToDegrees()
        {
            var testCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Angle Bar { get; } = -1.2 + 2.3;
        }
    }";

            var fixedCode = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Angle Bar { get; } = Angle.FromDegrees(-1.2 + 2.3);
        }
    }";
            AnalyzerAssert.CodeFix<ToAngleCodeFixProvider>("CS0266", testCode, fixedCode);
        }
    }
}
