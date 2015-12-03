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
            private readonly Thread _thread;
            private readonly CultureInfo _current;

            public TempCulture(Thread thread, CultureInfo culture)
            {
                this._thread = thread;
                this._current = thread.CurrentCulture;
                this._thread.CurrentCulture = culture;
            }

            public void Dispose()
            {
                this._thread.CurrentCulture = this._current;
            }
        }
    }
}
