namespace Gu.Units.Tests.Internals.Parsing
{
    using System;
    using System.Globalization;
    using System.Threading;

    public static class ThreadExt
    {
        public static IDisposable UsingTempCulture(this Thread thread, CultureInfo culture)
        {
            return new TempCulture(thread, culture);
        }

        private sealed class TempCulture : IDisposable
        {
            private readonly Thread thread;
            private readonly CultureInfo original;

            internal TempCulture(Thread thread, CultureInfo culture)
            {
                this.thread = thread;
                this.original = thread.CurrentCulture;
                thread.CurrentCulture = culture;
            }

            public void Dispose()
            {
                this.thread.CurrentCulture = this.original;
            }
        }
    }
}
