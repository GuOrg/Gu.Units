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

        private class TempCulture : IDisposable
        {
            private readonly Thread thread;
            private readonly CultureInfo current;

            public TempCulture(Thread thread, CultureInfo culture)
            {
                this.thread = thread;
                this.current = thread.CurrentCulture;
                this.thread.CurrentCulture = culture;
            }

            public void Dispose()
            {
                this.thread.CurrentCulture = this.current;
            }
        }
    }
}
