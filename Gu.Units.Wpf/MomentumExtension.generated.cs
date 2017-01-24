﻿





namespace Gu.Units.Wpf
{
    using System;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="MarkupExtension"/> for quantities of type <see cref="Momentum"/> in XAML.
    /// </summary>
    [MarkupExtensionReturnType(typeof(Momentum))]
    public class MomentumExtension : MarkupExtension
    {
        /// <summary>
        /// Initializes a new instance of <see cref="Gu.Units.Wpf.MomentumExtension"/>.
        /// </summary>
        /// <param name="value"><see cref="Gu.Units.Momentum"/>.</param>
        public MomentumExtension(Momentum value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets the <see cref="Momentum"/> value
        /// </summary>		
        public Momentum Value { get; private set; }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this.Value;
        }
    }
}