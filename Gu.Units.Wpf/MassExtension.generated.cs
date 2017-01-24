﻿





namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Mass"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Mass))]
    public class MassExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.MassExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Mass"/>.</param>
        public MassExtension(Mass value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Mass"/> value
        /// </summary>		
        public Mass Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}