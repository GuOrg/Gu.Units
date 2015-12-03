namespace Gu.Units.Tests.Internals.Helpers
{
    using System.Collections.Concurrent;
    using System.Reflection;
    using System.Text;
    using NUnit.Framework;

    public class StringBuilderPoolTests
    {
        [Test]
        public void UseTwice()
        {
            Clear(); // testrunner may run in parallel creating more than one builder.
            StringBuilder inner1;
            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append("a");
                inner1 = GetInner(builder);
                Assert.AreEqual("a", builder.ToString());
            }

            using (var builder = StringBuilderPool.Borrow())
            {
                builder.Append("bc");
                var inner2 = GetInner(builder);
                Assert.AreSame(inner1, inner2);
                Assert.AreEqual("bc", builder.ToString());
            }
        }

        [Test]
        public void Parallel()
        {
            using (var builder1 = StringBuilderPool.Borrow())
            using (var builder2 = StringBuilderPool.Borrow())
            {
                builder1.Append("a");
                builder2.Append("b");
                Assert.AreNotSame(GetInner(builder1), GetInner(builder2));
                Assert.AreEqual("a", builder1.ToString());
                Assert.AreEqual("b", builder2.ToString());
            }
        }

        private static StringBuilder GetInner(StringBuilderPool.Builder outer)
        {
            var fieldInfo = typeof(StringBuilderPool.Builder).GetField("builder", BindingFlags.Instance | BindingFlags.NonPublic);
            return (StringBuilder)fieldInfo.GetValue(outer);
        }

        private static void Clear()
        {
            var buildersField = typeof (StringBuilderPool).GetField("Builders", BindingFlags.Static | BindingFlags.NonPublic);
            var builders =(ConcurrentQueue<StringBuilder>) buildersField.GetValue(null);
            StringBuilder temp;
            while (builders.TryDequeue(out temp))
            {
            }
        }
    }
}
