﻿namespace Gu.Units
{
    using System;
    using System.Diagnostics;

    [DebuggerDisplay("CompositeFormat: {CompositeFormat}")]
    internal sealed class QuantityFormat<TUnit> : IEquatable<QuantityFormat<TUnit>>
        where TUnit : struct, IUnit, IEquatable<TUnit>
    {
        internal const char NoBreakingSpace = '\u00A0';
        internal const string NoBreakingSpaceString = "\u00A0";

        private static readonly StringComparer OrdinalComparer = StringComparer.Ordinal;

        private string? compositeFormat;

        private QuantityFormat(
            string? prePadding,
            string? valueFormat,
            string? padding,
            string? symbolFormat,
            string? postPadding,
            string? errorText,
            TUnit unit)
        {
            this.PrePadding = prePadding;
            this.ValueFormat = valueFormat;
            this.Padding = padding;
            this.SymbolFormat = symbolFormat;
            this.PostPadding = postPadding;
            this.ErrorText = errorText;
            this.Unit = unit;
        }

        private QuantityFormat(string errorText, TUnit unit)
        {
            this.ErrorText = errorText;
            this.Unit = unit;
        }

        internal static QuantityFormat<TUnit> Default => FormatCache<TUnit>.DefaultQuantityFormat;

        internal string? PrePadding { get; }

        internal string? ValueFormat { get; }

        internal string? Padding { get; }

        internal string? SymbolFormat { get; }

        internal string? PostPadding { get; }

        internal string? ErrorText { get; }

        internal string CompositeFormat => this.compositeFormat ??= this.CreateCompositeFormat();

        internal TUnit Unit { get; }

        public static bool operator ==(QuantityFormat<TUnit> left, QuantityFormat<TUnit> right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(QuantityFormat<TUnit> left, QuantityFormat<TUnit> right)
        {
            return !Equals(left, right);
        }

        public bool Equals(QuantityFormat<TUnit>? other)
        {
            if (other is null)
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return OrdinalComparer.Equals(this.PrePadding, other.PrePadding) &&
                   OrdinalComparer.Equals(this.ValueFormat, other.ValueFormat) &&
                   OrdinalComparer.Equals(this.Padding, other.Padding) &&
                   OrdinalComparer.Equals(this.SymbolFormat, other.SymbolFormat) &&
                   OrdinalComparer.Equals(this.PostPadding, other.PostPadding) &&
                   OrdinalComparer.Equals(this.ErrorText, other.ErrorText) &&
                   this.Unit.Equals(other.Unit);
        }

        public override bool Equals(object? obj)
        {
            return obj is QuantityFormat<TUnit> format && this.Equals(format);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = this.PrePadding?.GetHashCode() ?? 0;
                hashCode = (hashCode * 397) ^ GetHashCode(this.ValueFormat);
                hashCode = (hashCode * 397) ^ GetHashCode(this.Padding);
                hashCode = (hashCode * 397) ^ GetHashCode(this.SymbolFormat);
                hashCode = (hashCode * 397) ^ GetHashCode(this.PostPadding);
                hashCode = (hashCode * 397) ^ GetHashCode(this.ErrorText);
                hashCode = (hashCode * 397) ^ this.Unit.GetHashCode();
                return hashCode;

                static int GetHashCode(string? s)
                {
                    return s is null
                        ? 0
                        : OrdinalComparer.GetHashCode(s);
                }
            }
        }

        internal static QuantityFormat<TUnit> Create(PaddedFormat valueFormat, PaddedFormat symbolFormat, TUnit unit)
        {
            var errorFormat = CreateErrorFormat(valueFormat, symbolFormat);
            string? padding = null;
            if (valueFormat.PostPadding is null &&
                symbolFormat.PrePadding is null)
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

        private static bool ShouldSpace(string? symbol)
        {
            return symbol is { } && char.IsLetter(symbol[0]);
        }

        private static string? CreateErrorFormat(PaddedFormat valueFormat, PaddedFormat symbolFormat)
        {
            if (valueFormat.IsUnknown ||
                symbolFormat.IsUnknown)
            {
                using var writer = StringBuilderPool.Borrow();
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

            return null;
        }

        private string CreateCompositeFormat()
        {
            using var builder = StringBuilderPool.Borrow();
            if (this.ErrorText != null)
            {
                builder.Append(this.ErrorText);
                return builder.ToString();
            }

            builder.Append(this.PrePadding);

            if (string.IsNullOrEmpty(this.ValueFormat))
            {
                builder.Append("{0}");
            }
            else
            {
                builder.Append("{0:");
                builder.Append(this.ValueFormat);
                builder.Append("}");
            }

            builder.Append(this.Padding);
            builder.Append(this.SymbolFormat ?? this.Unit.Symbol);
            builder.Append(this.PostPadding);
            var format = builder.ToString();
            return format;
        }
    }
}
