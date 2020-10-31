namespace Gu.Units
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    internal static class StringBuilderPool
    {
        private static readonly ConcurrentQueue<StringBuilder> Builders = new ConcurrentQueue<StringBuilder>();

        internal static Builder Borrow()
        {
            return new Builder();
        }

        internal sealed class Builder : IDisposable
        {
            private readonly StringBuilder builder;
            private bool disposed;

            internal Builder()
            {
                if (!Builders.TryDequeue(out this.builder!))
                {
                    this.builder = new StringBuilder(12);
                }
            }

            internal int Length => this.builder.Length;

            public void Dispose()
            {
                if (this.disposed)
                {
                    return;
                }

                this.disposed = true;
                this.builder.Clear();
                Builders.Enqueue(this.builder);
            }

            public override string ToString()
            {
                return this.builder.ToString();
            }

            internal void Append(char c)
            {
                this.builder.Append(c);
            }

            internal void Append(string? s)
            {
                this.builder.Append(s);
            }

            // not the nicest to have this here perhaps but internal
            internal void Append<TQuantity, TUnit>(
                TQuantity quantity,
                QuantityFormat<TUnit> format,
                IFormatProvider? formatProvider)
                where TQuantity : IQuantity<TUnit>
                where TUnit : struct, IUnit, IEquatable<TUnit>
            {
                if (format.ErrorText != null)
                {
                    this.Append(format.ErrorText);
                    return;
                }

                this.Append(format.PrePadding);
                var scalarValue = quantity.GetValue(format.Unit);
                this.Append(scalarValue.ToString(format.ValueFormat, formatProvider));
                this.Append(format.Padding);
                this.Append(format.SymbolFormat ?? format.Unit.Symbol);
                this.Append(format.PostPadding);
            }

            // not the nicest to have this here perhaps but internal
            internal void Append(IReadOnlyList<SymbolAndPower> symbolAndPowers, SymbolFormat symbolFormat)
            {
                foreach (var symbolAndPower in symbolAndPowers.Where(x => x.Power > 0))
                {
                    if (this.builder.Length != 0)
                    {
                        this.AppendMultiplication(symbolFormat);
                    }

                    this.Append(symbolAndPower, symbolFormat);
                }

                if ((symbolFormat == SymbolFormat.Default ||
                     symbolFormat == SymbolFormat.FractionHatPowers ||
                     symbolFormat == SymbolFormat.FractionSuperScript) &&
                    symbolAndPowers.Any(x => x.Power < 0))
                {
                    if (this.builder.Length == 0)
                    {
                        this.builder.Append("1/");
                    }
                    else
                    {
                        this.Append('/');
                    }
                }

                foreach (var symbolAndPower in symbolAndPowers.Where(x => x.Power < 0))
                {
                    if (this.builder.Length != 0 && this.builder[this.builder.Length - 1] != '/')
                    {
                        this.AppendMultiplication(symbolFormat);
                    }

                    this.Append(symbolAndPower, symbolFormat);
                }
            }

            internal void Append(SymbolAndPower symbolAndPower, SymbolFormat symbolFormat)
            {
                this.Append(symbolAndPower.Symbol);
                if (symbolAndPower.Power == 1)
                {
                    return;
                }

                switch (symbolFormat)
                {
                    case SymbolFormat.SignedHatPowers:
                        this.Append('^');
                        this.Append(symbolAndPower.Power.ToString(CultureInfo.InvariantCulture));
                        break;
                    case SymbolFormat.FractionHatPowers:
                        {
                            var power = Math.Abs(symbolAndPower.Power);
                            if (power == 1)
                            {
                                return;
                            }

                            this.Append('^');
                            this.Append(power.ToString(CultureInfo.InvariantCulture));
                            break;
                        }

                    case SymbolFormat.SignedSuperScript:
                        {
                            if (symbolAndPower.Power == 1)
                            {
                                return;
                            }

                            if (symbolAndPower.Power < 0)
                            {
                                this.Append(SuperScript.Minus);
                            }

                            this.Append(SuperScript.GetChar(Math.Abs(symbolAndPower.Power)));
                            break;
                        }

                    case SymbolFormat.Default:
                    case SymbolFormat.FractionSuperScript:
                        {
                            var power = Math.Abs(symbolAndPower.Power);
                            if (power == 1)
                            {
                                return;
                            }

                            this.Append(SuperScript.GetChar(Math.Abs(symbolAndPower.Power)));
                            break;
                        }

                    default:
                        throw new ArgumentOutOfRangeException(nameof(symbolFormat), symbolFormat, null);
                }
            }

            private void AppendMultiplication(SymbolFormat symbolFormat)
            {
                switch (symbolFormat)
                {
                    case SymbolFormat.SignedHatPowers:
                    case SymbolFormat.FractionHatPowers:
                        this.Append('*');
                        break;
                    case SymbolFormat.Default:
                    case SymbolFormat.SignedSuperScript:
                    case SymbolFormat.FractionSuperScript:
                        this.Append('⋅');
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(symbolFormat), symbolFormat, null);
                }
            }
        }
    }
}
