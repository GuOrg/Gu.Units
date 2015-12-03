namespace Gu.Units
{
    internal static class Skipper
    {
        internal static bool TrySkip(string text, ref int pos, string skipText)
        {
            if (string.IsNullOrEmpty(skipText) ||
                text.Length - pos < skipText.Length)
            {
                return false;
            }

            if (skipText.Length == 1)
            {
                if (text[pos] == skipText[0])
                {
                    pos++;
                    return true;
                }

                return false;
            }

            int start = pos;
            int end = pos + skipText.Length;
            while (pos < end)
            {
                if (text[pos] != skipText[pos - start])
                {
                    pos = start;
                    return false;
                }
                pos++;
            }

            return true;
        }

        internal static bool TrySkip(string text, ref int pos, char skipChar)
        {
            if (pos == text.Length)
            {
                return false;
            }

            if (text[pos] == skipChar)
            {
                pos++;
                return true;
            }

            return false;
        }
    }
}
