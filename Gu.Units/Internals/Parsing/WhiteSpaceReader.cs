namespace Gu.Units
{
    internal static class WhiteSpaceReader
    {
        internal static bool TryRead(string text, ref int pos)
        {
            if (text == null)
            {
                return false;
            }

            var start = pos;
            while (text.Length > pos && char.IsWhiteSpace(text[pos]))
            {
                pos++;
            }

            return pos != start;
        }

        internal static bool TryRead(this string text,
            ref int pos,
            out string padding)
        {
            if (text == null)
            {
                padding = null;
                return false;
            }

            var start = pos;
            if (!TryRead(text, ref pos))
            {
                padding = null;
                return false;
            }

            if (pos == start + 1)
            {
                switch (text[start])
                {
                    case ' ':
                    {
                        padding = " ";
                        return true;
                    }

                    case '\u00A0':
                    {
                        padding = "\u00A0";
                        return true;
                    }
                }
            }

            padding = text.Substring(start, pos - start);
            return true;
        }

        internal static bool IsRestWhiteSpace(string text, int position)
        {
            if (text == null)
            {
                return true;
            }

            TryRead(text, ref position);
            return position == text.Length;
        }

        internal static bool IsRestWhiteSpace(string text, ref int position, int end)
        {
            TryRead(text, ref position);
            return position == text.Length || position >= end;
        }
    }
}