namespace Gu.Units
{
    using System.Diagnostics.CodeAnalysis;

    internal static class WhiteSpaceReader
    {
        internal static bool TryRead(string text, ref int pos)
        {
            if (text is null)
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

        internal static bool TryRead(string text, ref int pos, [NotNullWhen(true)] out string? padding)
        {
            if (text is null)
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
            if (text is null)
            {
                return true;
            }

            _ = TryRead(text, ref position);
            return position == text.Length;
        }

        internal static bool IsRestWhiteSpace(string text, ref int position, int end)
        {
            _ = TryRead(text, ref position);
            return position == text.Length || position >= end;
        }
    }
}