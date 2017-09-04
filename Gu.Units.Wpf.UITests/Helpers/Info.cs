namespace Gu.Units.Wpf.UITests
{
    using System;
    using Demo;

    public static class Info
    {
        public static string ExeFileName { get; } = new Uri(typeof(MainWindow).Assembly.CodeBase, UriKind.Absolute).LocalPath;
    }
}
