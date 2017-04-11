namespace Gu.Units.Analyzers.Tests
{
    using System;

    using Microsoft.CodeAnalysis.CodeFixes;
    using Microsoft.CodeAnalysis.Diagnostics;

    using NUnit.Framework;

    public class ToAngleCodeFixProviderTests : CodeFixVerifier
    {
        [Test]
        public void IntToDegrees()
        {
            var before = @"
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

            var expected = @"
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
            this.VerifyCSharpFix(before, expected);
        }

        [Test]
        public void IntToNullableDegrees()
        {
            var before = @"
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

            var expected = @"
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
            this.VerifyCSharpFix(before, expected);
        }

        [Test]
        public void NegativeIntToDegrees()
        {
            var before = @"
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

            var expected = @"
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
            this.VerifyCSharpFix(before, expected);
        }

        [Test]
        public void DoubleToDegrees()
        {
            var before = @"
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

            var expected = @"
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
            this.VerifyCSharpFix(before, expected);
        }

        [Test]
        public void NegativeDoubleToDegrees()
        {
            var before = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Angle Bar { get; } = -1.2;
        }
    }";

            var expected = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Angle Bar { get; } = Angle.FromDegrees(-1.2);
        }
    }";
            this.VerifyCSharpFix(before, expected);
        }

        [Test, Explicit("Dunno if there is a need to support this")]
        public void ExpressionToDegrees()
        {
            var before = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Angle Bar { get; } = -1.2 + 2.3;
        }
    }";

            var expected = @"
    namespace ConsoleApplication1
    {
        using Gu.Units;

        public class Foo
        {   
            public Angle Bar { get; } = Angle.FromDegrees(-1.2 + 2.3);
        }
    }";
            this.VerifyCSharpFix(before, expected);
        }

        protected override CodeFixProvider GetCSharpCodeFixProvider()
        {
            return new ToAngleCodeFixProvider();
        }

        protected override DiagnosticAnalyzer GetCSharpDiagnosticAnalyzer()
        {
            throw new Exception();
            //return new TestAnalyzerAnalyzer();
        }
    }
}
