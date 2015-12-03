namespace Gu.Units
{
    using System;
    using System.Runtime.CompilerServices;

    internal static class IntReader
    {
        private static readonly int MaxDigits = int.MaxValue.ToString().Length;
        internal static int ReadInt32(string text, ref int pos)
        {
            int result;
            if (TryReadInt32(text, ref pos, out result))
            {
                return result;
            }

            throw new FormatException($"Expected int starting at pos: {pos} in {text} was {text[pos]}");
        }

        internal static bool TryReadInt32(string text, ref int pos, out int result)
        {
            if (pos == text.Length)
            {
                result = 0;
                return false;
            }

            var sign = OperatorReader.TryReadSign(text, ref pos);

            var start = pos;
            var end = Math.Min(text.Length, pos + MaxDigits - 1);
            result = 0;

            while (pos < end)
            {
                var c = text[pos] - '0';
                if (c < 0 || 9 < c)
                {
                    break;
                }

                result *= 10;
                result += c;
                pos++;
            }

            if (pos == start)
            {
                if (sign != Sign.None)
                {
                    pos--;
                }

                return false;
            }

            if (pos < end ||
                !IsDigit(text, pos))
            {
                switch (sign)
                {
                    case Sign.Negative:
                        result = -result;
                        return true;
                    case Sign.None:
                    case Sign.Positive:
                        return true;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            // getting here means we must handle the last digit and potential overflows.

            long temp = result;
            temp *= 10;
            temp += text[pos] - '0';

            switch (sign)
            {
                case Sign.Negative:
                    {
                        temp = -temp;
                        if (temp >= int.MinValue)
                        {
                            result = (int)temp;
                            pos++;
                            return true;
                        }

                        pos = start - 1;
                        result = 0;
                        return false;
                    }
                case Sign.None:
                case Sign.Positive:
                    {
                        if (temp <= int.MaxValue)
                        {
                            result = (int)temp;
                            pos++;
                            return true;
                        }
                        pos = start - sign == Sign.Positive
                            ? 1
                            : 0;
                        result = 0;
                        return false;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        internal static bool IsDigit(string text, int index)
        {
            if (index < text.Length)
            {
                return IsDigit(text[index]);
            }

            return false;
        }

        internal static bool TrySkipDigits(string text, ref int pos)
        {
            var start = pos;
            while (pos < text.Length && IsDigit(text[pos]))
            {
                pos++;
            }

            return pos != start;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static bool IsDigit(char c)
        {
            switch (c)
            {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                    return true;
                default:
                    return false;
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int GetDigit(char c)
        {
            switch (c)
            {
                case '0':
                    return 0;
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                default:
                    throw new ArgumentOutOfRangeException(nameof(c), $"{c} is not a digit, check before calling");
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static int GetDigitOrMinusOne(char c)
        {
            var i = c - '0';
            return i < 0 || i > 9
                ? -1
                : i;
        }
    }
}
