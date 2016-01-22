namespace Gu.Units.Wpf
{
    using System;
    using System.ComponentModel;
    using System.Globalization;
    using System.Windows;
    using System.Windows.Data;
    using System.Windows.Markup;

    [MarkupExtensionReturnType(typeof(IValueConverter))]
    public class SolidAngleConverter : MarkupExtension, IValueConverter
    {
        private static readonly string StringFormatNotSet = "Not Set";
        private SolidAngleUnit? unit;
        private Binding binding;
        private string stringFormat = StringFormatNotSet;
        private QuantityFormat<SolidAngleUnit> quantityFormat;
        private string bindingStringFormat = StringFormatNotSet;
        private string errorText;

        public SolidAngleConverter()
        {
        }

        public SolidAngleConverter([TypeConverter(typeof(SolidAngleUnitTypeConverter))]SolidAngleUnit unit)
        {
            Unit = unit;
        }

        [ConstructorArgument("unit"), TypeConverter(typeof(SolidAngleUnitTypeConverter))]
        public SolidAngleUnit? Unit
        {
            get { return this.unit; }
            set
            {
                if (value == null)
                {
                    var message = $"{nameof(Unit)} cannot be null";
                    throw new ArgumentException(message, nameof(value));
                }

                this.unit = value.Value;
            }
        }

        public SymbolFormat? SymbolFormat { get; set; }

        public UnitInput? UnitInput { get; set; }

        public string StringFormat
        {
            get { return this.stringFormat; }
            set
            {
                StringFormatParser<SolidAngleUnit>.VerifyFormat(value);
                this.stringFormat = value;
                OnStringFormatChanged();
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            // the binding does not have stringformat set at this point
            // caching the binding to resolve later.
            try
            {
                var provideValueTarget = (IProvideValueTarget)serviceProvider.GetService(typeof(IProvideValueTarget));
                var targetObject = provideValueTarget?.TargetObject;
                this.binding = targetObject as Binding;
                if (this.binding == null && targetObject != null)
                {
                    if (Is.DesignMode)
                    {
                        throw new InvalidOperationException("TargetObject is not a binding");
                    }
                }
            }
            catch (NullReferenceException)
            {
                if (Is.DesignMode)
                {
                    throw new InvalidOperationException("Touching provideValueTarget?.TargetObject threw");
                }
            }

            return this;
        }

        public object Convert(object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            if (!IsValidConvertTargetType(targetType) && Is.DesignMode)
            {
                var message = $"{GetType().Name} does not support converting to {targetType.Name}";
                throw new ArgumentException(message, nameof(targetType));
            }

            if (value != null && !(value is SolidAngle) && Is.DesignMode)
            {
                var message = $"{GetType().Name} only supports converting from {typeof(SolidAngle)}";
                throw new ArgumentException(message, nameof(value));
            }

            if (this.bindingStringFormat == StringFormatNotSet)
            {
                TryGetStringFormatFromBinding();
            }

            if (this.unit == null)
            {
                if (Is.DesignMode)
                {
                    var message = $"{nameof(Unit)} cannot be null\r\n" +
                                  $"Must be specified Explicitly or in Binding.StringFormat";
                    throw new ArgumentException(message);
                }

                return "No unit set";
            }

            if (this.errorText != null)
            {
                return this.errorText;
            }

            if (value == null)
            {
                return targetType == typeof(string)
                    ? string.Empty
                    : null;
            }

            var solidAngle = (SolidAngle)value;

            var format = this.bindingStringFormat != null && this.bindingStringFormat != StringFormatNotSet
                ? this.bindingStringFormat
                : null;
            if (format != null)
            {
                return solidAngle;
            }

            format = this.stringFormat != null && this.stringFormat != StringFormatNotSet
                ? this.stringFormat
                : null;
            if (format != null &&
                (targetType == typeof(string) || targetType == typeof(object)))
            {
                return solidAngle.ToString(this.quantityFormat, culture);
            }


            if ((SymbolFormat != null || UnitInput == Wpf.UnitInput.SymbolRequired) &&
               (targetType == typeof(string) || targetType == typeof(object)))
            {
                return solidAngle.ToString(Unit.Value, SymbolFormat ?? Units.SymbolFormat.FractionSuperScript, culture);
            }

            if (IsValidConvertTargetType(targetType))
            {
                return solidAngle.GetValue(this.unit.Value);
            }

            return value;
        }

        public object ConvertBack(object value,
            Type targetType,
            object parameter,
            CultureInfo culture)
        {
            if (!(targetType == typeof(SolidAngle) || targetType == typeof(SolidAngle?)))
            {
                var message = $"{GetType().Name} does not support converting to {targetType.Name}";
                throw new NotSupportedException(message);
            }

            if (value == null)
            {
                return null;
            }

            if (this.StringFormat == null)
            {
                TryGetStringFormatFromBinding();
            }

            if (this.unit == null)
            {
                if (Is.DesignMode)
                {
                    var message = $"{nameof(Unit)} cannot be null\r\n" +
                                  $"Must be specified Explicitly or in Binding.StringFormat";
                    throw new ArgumentException(message);
                }

                return value;
            }

            if (value is double)
            {
                return new SolidAngle((double)value, this.unit.Value);
            }

            var text = value as string;
            if (string.IsNullOrEmpty(text))
            {
                return null;
            }

            var unitInput = UnitInput ?? Wpf.UnitInput.ScalarOnly;
            switch (unitInput)
            {
                case Wpf.UnitInput.ScalarOnly:
                    {
                        double d;
                        if (double.TryParse(text, NumberStyles.Float, culture, out d))
                        {
                            return new SolidAngle(d, this.unit.Value);
                        }

                        return value; // returning raw to trigger error
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
                                return new SolidAngle(d, this.unit.Value);
                            }
                        }

                        goto case Wpf.UnitInput.SymbolRequired;
                    }
                case Wpf.UnitInput.SymbolRequired:
                    {
                        SolidAngle result;
                        if (SolidAngle.TryParse(text, NumberStyles.Float, culture, out result))
                        {
                            return result;
                        }

                        return text;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void TryGetStringFormatFromBinding()
        {
            this.bindingStringFormat = this.binding?.StringFormat;
            if (!string.IsNullOrEmpty(bindingStringFormat))
            {
                OnStringFormatChanged();
            }
        }

        private void OnStringFormatChanged()
        {
            if (this.bindingStringFormat != StringFormatNotSet &&
                this.stringFormat != StringFormatNotSet &&
                this.bindingStringFormat != this.stringFormat)
            {
                this.errorText += $"Both {nameof(Binding)}.{nameof(Binding.StringFormat)} and {nameof(StringFormat)} are set.";

                if (Is.DesignMode)
                {
                    throw new InvalidOperationException(this.errorText);
                }
            }

            var format = this.stringFormat == StringFormatNotSet
                ? this.bindingStringFormat
                : this.stringFormat;
            if (StringFormatParser<SolidAngleUnit>.TryParse(format, out this.quantityFormat))
            {
                if (UnitInput == null && this.quantityFormat.SymbolFormat != null)
                {
                    UnitInput = Wpf.UnitInput.SymbolRequired;
                }

                if (this.unit == null)
                {
                    this.unit = this.quantityFormat.Unit;
                }

                else if (this.unit != this.quantityFormat.Unit)
                {
                    this.errorText += $"Unit is set to '{Unit}' but {nameof(StringFormat)} is '{format}'";
                    if (Is.DesignMode)
                    {
                        throw new InvalidOperationException(this.errorText);
                    }
                }

                return;
            }

            this.errorText = this.quantityFormat.ErrorText;
            if (Is.DesignMode)
            {
                throw new ArgumentException($"Error parsing: '{this.errorText}'");
            }

            this.stringFormat = null;
        }

        private bool IsValidConvertTargetType(Type targetType)
        {
            return targetType == typeof(string) ||
                   targetType == typeof(double) ||
                   targetType == typeof(object);
        }
    }
}