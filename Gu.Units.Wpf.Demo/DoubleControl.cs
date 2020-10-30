namespace Gu.Units.Wpf.Demo
{
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;

    // Dummy control for testing binding of doubles.
    public class DoubleControl : TextBox
    {
        public static readonly DependencyProperty NumberProperty = DependencyProperty.Register(
            nameof(Number),
            typeof(double),
            typeof(DoubleControl),
            new FrameworkPropertyMetadata(default(double), FrameworkPropertyMetadataOptions.BindsTwoWayByDefault) { DefaultUpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged });

        public double Number
        {
            get => (double)this.GetValue(NumberProperty);
            set => this.SetValue(NumberProperty, value);
        }
    }
}
