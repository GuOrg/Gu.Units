namespace Gu.Units.Wpf.Demo
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    // Dummy control for testing binding of doubles.
    public class DoubleControl : Control
    {
        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register(
            "Value",
            typeof(double),
            typeof(DoubleControl),
            new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault) {DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged});

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
    }
}
