





namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Data"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Data))]
    public class DataExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.DataExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Data"/>.</param>
        public DataExtension(Data value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Data"/> value
        /// </summary>		
        public Data Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}