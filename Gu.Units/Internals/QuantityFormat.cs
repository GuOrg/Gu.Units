namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("CompositeFormat: {CompositeFormat}")]
    internal class QuantityFormat<TUnit> : IEquatable<QuantityFormat<TUnit>>
        where TUnit : struct, IUnit, IEquatable<TUnit>
    {
        public static QuantityFormat<TUnit> Default => FormatCache<TUnit>.DefaultQuantityFormat;
        internal static readonly char NoBreakingSpace = '\u00A0';
        internal static readonly string NoBreakingSpaceString = "\u00A0";
        private string compositeFormat;

        private QuantityFormat(
            string prePadding,
            string valueFormat,
            string padding,
            string symbolFormat,
            string postPadding,
            string errorText,
            TUnit unit)
        {
            PrePadding = prePadding;
            ValueFormat = valueFormat;
            Padding = padding;
            SymbolFormat = symbolFormat;
            PostPadding = postPadding;
            ErrorText = errorText;
            Unit = unit;
        }

        private QuantityFormat(string errorText, TUnit unit)
        {
            ErrorText = errorText;
            Unit = unit;
        }

        internal string PrePadding { get; }

        internal string ValueFormat { get; }

        internal string Padding { get; }

        internal string SymbolFormat { get; }

        internal string PostPadding { get; }

        internal string ErrorText { get; }

        internal string CompositeFormat => this.compositeFormat ?? (this.compositeFormat = CreateCompositeFormat());

        internal TUnit Unit { get; }

        public static bool operator ==(QuantityFormat<TUnit> left,
            QuantityFormat<TUnit> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(QuantityFormat<TUnit> left,
            QuantityFormat<TUnit> right)
        {
            return !Equals(left, right);
        }

        public bool Equals(QuantityFormat<TUnit> other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(PrePadding, other.PrePadding) &&
                   string.Equals(ValueFormat, other.ValueFormat) &&
                   string.Equals(Padding, other.Padding) &&
                   string.Equals(SymbolFormat, other.SymbolFormat) &&
                   string.Equals(PostPadding, other.PostPadding) &&
                   string.Equals(ErrorText, other.ErrorText) &&
                   Unit.Equals(other.Unit);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return Equals((QuantityFormat<TUnit>)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = PrePadding?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ (ValueFormat?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (Padding?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (SymbolFormat?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (PostPadding?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ (ErrorText?.GetHashCode() ?? 0);
                hashCode = (hashCode * 397) ^ Unit.GetHashCode();
                return hashCode;
            }
        }

        internal static QuantityFormat<TUnit> Create(
            PaddedFormat valueFormat,
            PaddedFormat symbolFormat,
            TUnit unit)
        {
            var errorFormat = CreateErrorFormat(valueFormat, symbolFormat);

            string padding = null;
            if (valueFormat.PostPadding == null &&
                symbolFormat.PrePadding == null)
            {
                if (ShouldSpace(symbolFormat.Format))
                {
                    padding = NoBreakingSpaceString;
                }
            }
            else
            {
                padding = valueFormat.PostPadding + symbolFormat.PrePadding;
            }

            return new QuantityFormat<TUnit>(
                valueFormat.PrePadding,
                valueFormat.Format,
                padding,
                symbolFormat.Format,
                symbolFormat.PostPadding,
                errorFormat,
                unit);
        }

        internal static QuantityFormat<TUnit> CreateUnknown(string errorFormat, TUnit unit)
        {
            return new QuantityFormat<TUnit>(errorFormat, unit);
        }

        private static bool ShouldSpace(string symbol)
        {
            if (symbol.Length > 1)
            {
                return true;
            }

            return char.IsLetter(symbol[0]);
        }

        private static string CreateErrorFormat(PaddedFormat valueFormat, PaddedFormat symbolFormat)
        {
            if (valueFormat.IsUnknown ||
                symbolFormat.IsUnknown)
            {
                using (var writer = StringBuilderPool.Borrow())
                {
                    if (valueFormat.IsUnknown)
                    {
                        writer.Append($"{{value: {valueFormat.Format ?? "null"}}}");
                    }
                    else
                    {
                        writer.Append(valueFormat.PrePadding);
                        writer.Append(valueFormat.Format);
                    }

                    writer.Append(NoBreakingSpace);
                    if (symbolFormat.IsUnknown)
                    {
                        writer.Append($"{{unit: {symbolFormat.Format ?? "null"}}}");
                    }
                    else
                    {
                        writer.Append(symbolFormat.Format);
                        writer.Append(symbolFormat.PostPadding);
                    }
                    return writer.ToString();
                }
            }

            return null;
        }

        private string CreateCompositeFormat()
        {
            using (var builder = StringBuilderPool.Borrow())
            {
                if (ErrorText != null)
                {
                    builder.Append(ErrorText);
                    return builder.ToString();
                }

                builder.Append(PrePadding);

                if (string.IsNullOrEmpty(ValueFormat))
                {
                    builder.Append("{0}");
                }
                else
                {
                    builder.Append("{0:");
                    builder.Append(ValueFormat);
                    builder.Append("}");
                }

                builder.Append(Padding);
                builder.Append(SymbolFormat ?? Unit.Symbol);
                builder.Append(PostPadding);
                var compositeFormat = builder.ToString();
                return compositeFormat;
            }
        }
    }
}