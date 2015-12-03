namespace Gu.Units
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
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
                if (!Builders.TryDequeue(out this.builder))
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

            public void Append(char c)
            {
                this.builder.Append(c);
            }

            public void Append(string s)
            {
                this.builder.Append(s);
            }

            public override string ToString()
            {
                return this.builder.ToString();
            }

            // not the nicest to have this here perhaps but internal
            internal void Append<TQuantity, TUnit>(
                TQuantity quantity,
                QuantityFormat<TUnit> format,
                IFormatProvider formatProvider)
                where TQuantity : IQuantity<TUnit>
                where TUnit : struct, IUnit, IEquatable<TUnit>
            {
                if (format.ErrorText != null)
                {
                    Append(format.ErrorText);
                    return;
                }

                Append(format.PrePadding);
                var scalarValue = quantity.GetValue(format.Unit);
                Append(scalarValue.ToString(format.ValueFormat, formatProvider));
                Append(format.Padding);
                Append(format.SymbolFormat ?? format.Unit.Symbol);
                Append(format.PostPadding);
            }

            // not the nicest to have this here perhaps but internal
            internal void Append(IReadOnlyList<SymbolAndPower> symbolAndPowers, SymbolFormat symbolFormat)
            {
                foreach (var symbolAndPower in symbolAndPowers.Where(x => x.Power > 0))
                {
                    if (this.builder.Length != 0)
                    {
                        AppendMultiplication(symbolFormat);
                    }

                    Append(symbolAndPower, symbolFormat);
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
                        Append('/');
                    }
                }

                foreach (var symbolAndPower in symbolAndPowers.Where(x => x.Power < 0))
                {
                    if (this.builder.Length != 0 && this.builder[this.builder.Length - 1] != '/')
                    {
                        AppendMultiplication(symbolFormat);
                    }

                    Append(symbolAndPower, symbolFormat);
                }
            }

            private void AppendMultiplication(SymbolFormat symbolFormat)
            {
                switch (symbolFormat)
                {
                    case SymbolFormat.SignedHatPowers:
                    case SymbolFormat.FractionHatPowers:
                        Append('*');
                        break;
                    case SymbolFormat.Default:
                    case SymbolFormat.SignedSuperScript:
                    case SymbolFormat.FractionSuperScript:
                        Append('⋅');
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(symbolFormat), symbolFormat, null);
                }
            }

            internal void Append(SymbolAndPower symbolAndPower,
                SymbolFormat symbolFormat)
            {
                Append(symbolAndPower.Symbol);

                if (symbolAndPower.Power == 1)
                {
                    return;
                }

                switch (symbolFormat)
                {
                    case SymbolFormat.SignedHatPowers:
                        Append('^');
                        Append(symbolAndPower.Power.ToString());
                        break;
                    case SymbolFormat.FractionHatPowers:
                        {
                            var power = Math.Abs(symbolAndPower.Power);
                            if (power == 1)
                            {
                                return;
                            }
                            Append('^');
                            Append(power.ToString());
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
                                Append(SuperScript.Minus);
                            }
                            Append(SuperScript.GetChar(Math.Abs(symbolAndPower.Power)));
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
                            Append(SuperScript.GetChar(Math.Abs(symbolAndPower.Power)));
                            break;
                        }
                    default:
                        throw new ArgumentOutOfRangeException(nameof(symbolFormat), symbolFormat, null);
                }
            }
        }
    }
}
