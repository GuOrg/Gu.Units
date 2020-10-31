#nullable enable
namespace Gu.Units.Wpf
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Text;
    using System.Windows.Data;
    using System.Windows.Markup;

    /// <summary>
    /// An <see cref="IValueConverter"/> for quantities of type <see cref="AmountOfSubstance"/>
    /// </summary>
    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class AmountOfSubstanceConverter : MarkupExtension, IValueConverter
    {
        private AmountOfSubstanceUnit? unit;
        private Binding binding;
        private QuantityFormat<AmountOfSubstanceUnit>? quantityFormat;
        private QuantityFormat<AmountOfSubstanceUnit>? bindingQuantityFormat;
        private string? valueFormat;
        private bool initialized;
        private StringBuilder errorText = new StringBuilder();

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.AmountOfSubstanceConverter"/> class.
        /// </summary>
        public AmountOfSubstanceConverter()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Gu.Units.Wpf.AmountOfSubstanceConverter"/> class.
        /// </summary>
        /// <param name="unit"><see cref="Gu.Units.AmountOfSubstanceUnit"/>.</param>
        public AmountOfSubstanceConverter(AmountOfSubstanceUnit unit)
        {
            this.Unit = unit;
        }

        /// <summary>
        /// Gets or sets the <see cref="AmountOfSubstanceUnit"/>
        /// </summary>
        [ConstructorArgument("unit")]
        [TypeConverter(typeof(AmountOfSubstanceUnitTypeConverter))]
        public AmountOfSubstanceUnit? Unit
        {
            get => this.unit;
            set
            {
                if (value == null)
                {
                    this.errorText.AppendLine($"{nameof(this.Unit)} cannot be null");
                    if (Is.DesignMode)
                    {
                        throw new ArgumentException(this.errorText.ToString(), nameof(value));
                    }
                }

                this.unit = value.Value;
            }
        }

        /// <summary>
        /// Gets or sets the format to use when formatting the scalar part.
        /// Formats valid for formatting <see cref="double"/> are valid
        /// </summary>
        public string? ValueFormat
        {
            get => this.valueFormat;
            set
            {
                if (!StringFormatParser<AmountOfSubstanceUnit>.CanParseValueFormat(value))
                {
                    if (Is.DesignMode)
                    {
                        StringFormatParser<AmountOfSubstanceUnit>.VerifyValueFormat(value);
                    }

                    this.errorText.AppendLine(StringFormatParser<AmountOfSubstanceUnit>.CreateFormatErrorString(value, typeof(double)));
                }

                this.valueFormat = value;
            }
        }

        /// <summary>
        /// Gets or sets the <see cref="SymbolFormat"/> that is used when formatting the unit.
        /// </summary>
        public SymbolFormat? SymbolFormat { get; set; }

        /// <summary>
        /// Gets or sets the <see cref="Gu.Units.Wpf.UnitInput"/> that specifies if unit is allowed or required for user input.
        /// </summary>
        public UnitInput? UnitInput { get; set; }

        /// <summary>
        /// Gets or sets the composite string format to use when formatting the quantity value.
        /// </summary>
        public string? StringFormat
        {
            get => this.quantityFormat?.CompositeFormat;
            set
            {
                if (StringFormatParser<AmountOfSubstanceUnit>.TryParse(value, out this.quantityFormat))
                {
                    if (this.unit != null && this.unit != this.quantityFormat.Unit)
                    {
                        var message = $"Unit is set to '{this.unit.Value.symbol}' but StringFormat is '{value}'";
                        if (Is.DesignMode)
                        {
                            throw new InvalidOperationException(message);
                        }
                    }
                }
                else
                {
                    if (Is.DesignMode)
                    {
                        StringFormatParser<AmountOfSubstanceUnit>.VerifyQuantityFormat(value);
                    }

                    this.errorText.AppendLine(StringFormatParser<AmountOfSubstanceUnit>.CreateFormatErrorString(value, typeof(AmountOfSubstanceUnit)));
                }
            }
        }

        /// <inheritdoc />
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // the binding does not have string format set at this point
            // caching the binding to resolve later.
            try
            {
                var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
                var targetObject = provideValueTarget?.TargetObject;
                this.binding = targetObject as Binding;
                if (this.binding == null && targetObject != null)
                {
                    this.errorText.AppendLine("TargetObject is not a binding");
                    if (Is.DesignMode)
                    {
                        throw new InvalidOperationException(this.errorText.ToString());
                    }
                }
            }
            catch (NullReferenceException)
            {
                this.errorText.AppendLine("Touching provideValueTarget?.TargetObject threw");
                if (Is.DesignMode)
                {
                    throw new InvalidOperationException(this.errorText.ToString());
                }
            }

            return this;
        }

        /// <inheritdoc />
        public object? Convert(object value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (!this.initialized)
            {
                this.Initialize();
            }

            var message = this.errorText.ToString();
            if (!IsValidConvertTargetType(targetType))
            {
                message += $"{this.GetType().Name} does not support converting to {targetType.Name}";
            }

            if (value != null && !(value is AmountOfSubstance))
            {
                message += $"{this.GetType().Name} only supports converting from {typeof(AmountOfSubstance)}";
            }

            if (message != string.Empty)
            {
                message = message.TrimEnd('\r', '\n');
                if (Is.DesignMode)
                {
                    throw new InvalidOperationException(message);
                }

                return message;
            }

            if (value == null)
            {
                return targetType == typeof(string)
                    ? string.Empty
                    : null;
            }

            var amountOfSubstance = (AmountOfSubstance)value;
            if (this.bindingQuantityFormat != null)
            {
                if (string.IsNullOrEmpty(this.bindingQuantityFormat.SymbolFormat))
                {
                    return amountOfSubstance.GetValue(this.unit.Value);
                }

                return amountOfSubstance;
            }

            if (targetType == typeof(string) || targetType == typeof(object))
            {
                if (this.UnitInput == Wpf.UnitInput.SymbolRequired)
                {
                    return amountOfSubstance.ToString(this.quantityFormat, culture);
                }

                if (this.ValueFormat != null)
                {
                    return amountOfSubstance.GetValue(this.unit.Value).ToString(this.valueFormat, culture);
                }

                return amountOfSubstance.GetValue(this.unit.Value);
            }

            return amountOfSubstance.GetValue(this.unit.Value);
        }

        /// <inheritdoc />
        public object? ConvertBack(object value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (!this.initialized)
            {
                this.Initialize();
            }

            var message = this.errorText.ToString();
            if (!(targetType == typeof(AmountOfSubstance) || targetType == typeof(AmountOfSubstance?)))
            {
                message += $"{this.GetType().Name} does not support converting to {targetType.Name}";
            }

            if (message != string.Empty)
            {
                message = message.TrimEnd('\r', '\n');
                if (Is.DesignMode)
                {
                    throw new InvalidOperationException(message);
                }

                return message;
            }

            if (value == null)
            {
                return null;
            }

            if (value is double)
            {
                return new AmountOfSubstance((double)value, this.unit.Value);
            }

            var text = value as string;
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            var unitInput = this.UnitInput ?? Wpf.UnitInput.ScalarOnly;
            switch (unitInput)
            {
                case Wpf.UnitInput.ScalarOnly:
                    {
                        double d;
                        if (double.TryParse(text, NumberStyles.Float, culture, out d))
                        {
                            return new AmountOfSubstance(d, this.unit.Value);
                        }

                        AmountOfSubstance result;
                        if (AmountOfSubstance.TryParse(text, NumberStyles.Float, culture, out result))
                        {
                            return $"#{text}#"; // returning modified text so that TypeConverter fails and we get an error
                        }

                        return text; // returning raw to trigger error
                    }

                case Wpf.UnitInput.SymbolAllowed:
                    {
                        double d;
                        int pos = 0;
                        WhiteSpaceReader.TryRead(text, ref pos);
                        if (DoubleReader.TryRead(text, ref pos, NumberStyles.Float, culture, out d))
                        {
                            WhiteSpaceReader.TryRead(text, ref pos);
                            if (pos == text.Length)
                            {
                                return new AmountOfSubstance(d, this.unit.Value);
                            }
                        }

                        goto case Wpf.UnitInput.SymbolRequired;
                    }

                case Wpf.UnitInput.SymbolRequired:
                    {
                        AmountOfSubstance result;
                        if (AmountOfSubstance.TryParse(text, NumberStyles.Float, culture, out result))
                        {
                            return result;
                        }

                        return text;
                    }

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private static bool IsValidConvertTargetType(Type targetType)
        {
            return targetType == typeof(string) ||
                   targetType == typeof(double) ||
                   targetType == typeof(double?) ||
                   targetType == typeof(object);
        }

        private void Initialize()
        {
            this.initialized = true;
            BindingStringFormat.TryGet(this.binding, out this.bindingQuantityFormat);
            if (!string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat))
            {
                if (this.ValueFormat != null)
                {
                    this.errorText.AppendLine($"ValueFormat cannot be set when Binding.StringFormat is a unit format.");
                }

                if (this.StringFormat != null)
                {
                    this.errorText.AppendLine($"ValueFormat cannot be set when Binding.StringFormat is a unit format.");
                }
            }

            if (this.quantityFormat != null)
            {
                if (this.ValueFormat != null)
                {
                    this.errorText.AppendLine($"Both ValueFormat and StringFormat cannot be set.");
                }
            }
            else
            {
                if (this.unit != null && this.SymbolFormat != null)
                {
                    this.quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(this.ValueFormat, this.unit.Value, this.SymbolFormat.Value);
                }
            }

            if (this.unit == null)
            {
                var hasFmtUnit = !string.IsNullOrEmpty(this.quantityFormat?.SymbolFormat);
                var hasBindingUnit = !string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat);
                if (!hasFmtUnit && !hasBindingUnit)
                {
                    this.errorText.AppendLine($"Unit cannot be null.");
                    this.errorText.AppendLine($"Must be specified Explicitly or in StringFormat or in Binding.StringFormat.");
                }
                else if (hasFmtUnit && !hasBindingUnit)
                {
                    this.unit = this.quantityFormat.Unit;
                }
                else if (!hasFmtUnit && hasBindingUnit)
                {
                    this.unit = this.bindingQuantityFormat.Unit;
                }
                else
                {
                    if (this.quantityFormat.Unit != this.bindingQuantityFormat.Unit)
                    {
                        this.errorText.AppendLine($"Ambiguous units StringFormat: {this.quantityFormat.CompositeFormat} Binding.StringFormat: {this.bindingQuantityFormat.CompositeFormat}");
                    }

                    this.unit = this.quantityFormat.Unit;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(this.quantityFormat?.SymbolFormat) &&
                    this.unit != this.quantityFormat.Unit)
                {
                    this.errorText.AppendLine($"Unit is set to '{this.unit}' but StringFormat is '{this.StringFormat.Replace("{0:", string.Empty).Replace("}", string.Empty)}'");
                }

                var hasBindingUnit = !string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat);
            }

            if (this.UnitInput == Wpf.UnitInput.SymbolRequired)
            {
                if (string.IsNullOrEmpty(this.quantityFormat?.SymbolFormat))
                {
                    if (string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat))
                    {
                        if (this.unit == null)
                        {
                            this.errorText.AppendLine("UnitInput == SymbolRequired but no unit format is specified");
                        }
                        else if (this.SymbolFormat != null)
                        {
                            this.quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(this.ValueFormat, this.unit.Value, this.SymbolFormat.Value);
                            if (this.UnitInput == null)
                            {
                                this.UnitInput = Wpf.UnitInput.SymbolRequired;
                            }
                            else if (this.UnitInput == Wpf.UnitInput.ScalarOnly)
                            {
                                this.errorText.AppendLine("Cannot have ScalarOnly and SymbolFormat specified");
                            }
                        }
                        else
                        {
                            this.quantityFormat = FormatCache<AmountOfSubstanceUnit>.GetOrCreate(this.ValueFormat, this.unit.Value);
                            if (this.UnitInput == null)
                            {
                                this.UnitInput = Wpf.UnitInput.ScalarOnly;
                            }
                            else if (this.UnitInput == Wpf.UnitInput.ScalarOnly)
                            {
                                this.errorText.AppendLine("Cannot have ScalarOnly and SymbolFormat specified");
                            }
                        }
                    }
                    else
                    {
                        this.quantityFormat = this.bindingQuantityFormat;
                    }
                }
            }

            if (this.UnitInput == null)
            {
                if (!string.IsNullOrEmpty(this.quantityFormat?.SymbolFormat) ||
                    !string.IsNullOrEmpty(this.bindingQuantityFormat?.SymbolFormat))
                {
                    this.UnitInput = Wpf.UnitInput.SymbolRequired;
                }
            }
        }
    }
}
