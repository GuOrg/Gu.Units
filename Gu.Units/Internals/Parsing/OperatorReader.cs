namespace Gu.Units
{
    internal static class OperatorReader
    {
        private const char MultiplyDot = '⋅';
        private const char MultiplyStar = '*';
        private const char MultiplyX = 'x';
        private const char Divide = '/';

        internal static MultiplyOrDivide TryReadMultiplyOrDivide(string s, ref int pos)
        {
            if (pos == s.Length)
            {
                return MultiplyOrDivide.None;
            }

            if (s[pos] == MultiplyDot || s[pos] == MultiplyStar || s[pos] == MultiplyX)
            {
                pos++;
                return MultiplyOrDivide.Multiply;
            }

            if (s[pos] == Divide)
            {
                pos++;
                return MultiplyOrDivide.Division;
            }

            return MultiplyOrDivide.None;
        }

        internal static Sign TryReadSign(string text, ref int pos)
        {
            if (text[pos] == '+')
            {
                pos++;
                return Sign.Positive;
            }

            if (text[pos] == '-')
            {
                pos++;
                return Sign.Negative;
            }

            return Sign.None;
        }
    }
}