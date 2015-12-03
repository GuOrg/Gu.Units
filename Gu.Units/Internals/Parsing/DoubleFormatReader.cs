namespace Gu.Units
{
    internal static class DoubleFormatReader
    {
        internal static bool TryRead(string format, ref int pos, out string result)
        {
            if (string.IsNullOrEmpty(format) || pos == format.Length)
            {
                result = null;
                return true;
            }
            switch (format[pos])
            {
                case 'e':
                case 'E':
                case 'f':
                case 'F':
                case 'g':
                case 'G':
                case 'n':
                case 'N':
                    return TryReadPrefixNumberFormat(format, ref pos, out  result); ;
                case 'r':
                    pos++;
                    result = "r";
                    return true;
                case 'R':
                    pos++;
                    result = "R";
                    return true;
                case '0':
                case '#':
                    return TryReadPoundAndZeroFormat(format, ref pos, out  result);
                default:
                    result = format.Substring(pos);
                    return false;
            }
        }

        private static bool TryReadPoundAndZeroFormat(string format, ref int pos, out  string result)
        {
            var start = pos;
            pos++;
            while (pos < format.Length)
            {
                switch (format[pos])
                {
                    case '#':
                    case '0':
                        pos++;
                        continue;
                    case '.':
                    case ',':
                    case ' ':
                    case '\u00A0':
                        {
                            if (format.Length == pos + 1)
                            {
                                break;
                            }
                            switch (format[pos + 1])
                            {
                                case '#':
                                case '0':
                                    {
                                        pos++;
                                        continue;
                                    }
                            }
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                break;
            }

            result = format.Substring(start, pos - start);
            return true;
        }

        private static bool TryReadPrefixNumberFormat(string format, ref int pos, out string result)
        {
            var start = pos;
            pos++;
            IntReader.TrySkipDigits(format, ref pos);
            result = format.Substring(start, pos - start);
            return true;
        }
    }
}
