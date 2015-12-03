namespace Gu.Units
{
    using System;

    internal static class PowerReader
    {
        internal static int Read(string text, ref int pos)
        {
            int result;
            if (TryRead(text, ref pos, out result))
            {
                return result;
            }

            var message = $"Expected to find power at position {pos} in {text}.";
            throw new FormatException(message);
        }

        internal static bool TryRead(string text, ref int pos, out int result)
        {
            if (pos == text.Length)
            {
                result = 1;
                return true;
            }

            int start = pos;
            if (text[pos] == '^')
            {
                var success = TryReadHatPower(text, ref pos, out result);
                pos = success
                    ? pos
                    : start;
                return success;
            }

            if (text[pos].IsSuperscriptDigitOrSign())
            {
                var success = TryReadSuperScriptPower(text, ref pos, out result);
                pos = success
                    ? pos
                    : start;
                return success;
            }

            result = 1;
            return true;
        }

        private static bool TryReadHatPower(string text, ref int pos, out int power)
        {
            if (text[pos] != '^')
            {
                // leaving this even if it is a try method. Getting here means something should have been checked before
                throw new InvalidOperationException("Check that there is a hat power to read before calling this");
            }

            pos++;
            WhiteSpaceReader.TryRead(text, ref pos);

            var ps = OperatorReader.TryReadSign(text, ref pos);
            if (ps == Sign.None)
            {
                ps = Sign.Positive;
            }

            if (OperatorReader.TryReadSign(text, ref pos) != Sign.None)
            {
                // not allowing a^--2 as it is most likely a typo
                power = 0;
                return false;
            }

            WhiteSpaceReader.TryRead(text, ref pos);
            if (IntReader.TryReadInt32(text, ref pos, out power))
            {
                power *= (int)ps;
                return true;
            }

            power = 0;
            return false;
        }

        private static bool TryReadSuperScriptPower(string text, ref int pos, out int power)
        {
            if (!text[pos].IsSuperscriptDigitOrSign())
            {
                power = 0;
                return false;
            }

            var sign = TryReadSuperScriptSign(text, ref pos);
            if (sign == Sign.None)
            {
                sign = Sign.Positive;
            }

            if (TryReadSuperScriptSign(text, ref pos) != Sign.None)
            {
                // not allowing a⁻⁻² as it is most likely a typo
                power = 0;
                return false;
            }

            WhiteSpaceReader.TryRead(text, ref pos);
            if (TryReadSuperScriptInt(text, ref pos, out power))
            {
                power *= (int)sign;
                return true;
            }

            power = 0;
            return false;
        }

        private static Sign TryReadSuperScriptSign(string text, ref int pos)
        {
            var sign = Sign.None;
            if (text[pos] == SuperScript.Plus)
            {
                pos++;
                sign = Sign.Positive;
            }
            else if (text[pos] == SuperScript.Minus)
            {
                pos++;
                sign = Sign.Negative;
            }

            return sign;
        }

        private static bool TryReadSuperScriptInt(string text, ref int pos, out int result)
        {
            result = SuperScript.GetDigit(text[pos]);
            if (result < 0)
            {
                result = 0;
                return false;
            }

            pos++;

            while (pos < text.Length &&
                  text[pos].IsSuperscriptDigit())
            {
                result *= 10;
                result += SuperScript.GetDigit(text[pos]);
                pos++;
            }

            return true;
        }

        private static bool IsSuperscriptDigit(this char c)
        {
            return SuperScript.SuperscriptDigits.IndexOf(c) > -1;
        }

        private static bool IsSuperscriptDigitOrSign(this char c)
        {
            if (c == SuperScript.Minus ||
                c == SuperScript.Plus)
            {
                return true;
            }

            return SuperScript.SuperscriptDigits.IndexOf(c) > -1;
        }
    }
}