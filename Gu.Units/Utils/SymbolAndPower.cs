namespace Gu.Units
{
    using System;

    public struct SymbolAndPower : IEquatable<SymbolAndPower>
    {
        private const string Superscripts = "⁺⁻⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const string SuperscriptDigits = "⁰¹²³⁴⁵⁶⁷⁸⁹";
        private const char MultiplyDot = '⋅';
        private const char MultiplyStar = '*';
        private const char MultiplyX = 'x';
        private const char Divide = '/';

        public readonly string Symbol;
        public readonly int Power;

        internal SymbolAndPower(string symbol, int power)
        {
            if (String.IsNullOrEmpty(symbol))
            {
                throw new ArgumentNullException("symbol");
            }
            Symbol = symbol;
            Power = power;
        }

        public static bool operator ==(SymbolAndPower left, SymbolAndPower right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(SymbolAndPower left, SymbolAndPower right)
        {
            return !left.Equals(right);
        }

        public override string ToString()
        {
            string p;
            if (Power == 1)
            {
                p = "";
            }
            else if (Power > 1)
            {
                p = new string(SuperscriptDigits[Power], 1);
            }
            else
            {
                p = new string(new[] { '⁻', SuperscriptDigits[-1 * Power] });
            }
            return String.Format("{0}{1}", Symbol, p);
        }

        public bool Equals(SymbolAndPower other)
        {
            return String.Equals(Symbol, other.Symbol) && Power == other.Power;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }
            return obj is SymbolAndPower && Equals((SymbolAndPower)obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Symbol.GetHashCode() * 397) ^ Power;
            }
        }

        internal static SymbolAndPower Read(string s, ref int pos, ref Sign sign)
        {
            if (sign == Sign.None)
            {
                throw new ArgumentException("Sign cannot be none", "sign");
            }
            ReadWhiteSpace(s, ref pos);
            if (pos == s.Length)
            {
                throw new FormatException(String.Format("Expected symbol or operator. {0} position: end", s));
            }

            var op = ReadOperator(s, ref pos);
            if (op != Operator.None)
            {
                ReadWhiteSpace(s, ref pos);
                if (ReadOperator(s, ref pos) != Operator.None)
                {
                    var message = String.Format("Cannot have multiple operators in a row. {0} position: {1}", s, pos);
                    throw new FormatException(message);
                }
                if (op == Operator.Division)
                {
                    if (sign == Sign.Negative)
                    {
                        throw new FormatException(String.Format("String cannot contain / twice. String is: {0}", s));
                    }
                    sign = Sign.Negative;
                }
            }
            ReadWhiteSpace(s, ref pos);
            return ReadSymbolAndPower(s, ref pos, sign);
        }

        internal static bool CanRead(string s, ref int pos)
        {
            ReadWhiteSpace(s, ref pos);
            return pos < s.Length;
        }

        private static Operator ReadOperator(string s, ref int pos)
        {
            if (pos == s.Length)
            {
                return Operator.None;
            }

            if (s[pos] == MultiplyDot || s[pos] == MultiplyStar || s[pos] == MultiplyX)
            {
                pos++;
                return Operator.Multiply;
            }

            if (s[pos] == Divide)
            {
                pos++;
                return Operator.Division;
            }

            return Operator.None;
        }

        private static SymbolAndPower ReadSymbolAndPower(string s, ref int pos, Sign sign)
        {
            var start = pos;
            while (s.Length > pos && IsSymbol(s[pos]))
            {
                pos++;
            }
            if (pos == start)
            {
                throw new FormatException(String.Format("No symbol found at {0} in {1}", pos, s));
            }
            var symbol = s.Substring(start, pos - start);
            ReadWhiteSpace(s, ref pos);

            var power = s.Length == pos
                            ? 1
                            : ReadPower(s, ref pos);
            if (power == 0)
            {
                throw new FormatException(String.Format("Power cannot be 0, error at {0} in {1}", start + symbol.Length, s));
            }
            if (sign == Sign.Negative && power < 0)
            {
                throw new FormatException(String.Format("Power cannot be negative after / error at {0} in {1}", start + symbol.Length, s));
            }
            return new SymbolAndPower(symbol, (int)sign * power);
        }

        private static bool IsSymbol(char c)
        {
            if (c == '°' || c == '‰' || c == '%')
            {
                return true;
            }

            return Char.IsLetter(c);
        }

        private static int ReadPower(string s, ref int pos)
        {
            ReadWhiteSpace(s, ref pos);
            if (s[pos] == '^')
            {
                return ReadHatPower(s, ref pos);
            }
            if (Superscripts.IndexOf(s[pos]) == -1)
            {
                return 1;
            }
            return ReadSuperScriptPower(s, ref pos);
        }

        private static int ReadHatPower(string s, ref int pos)
        {
            if (s[pos] != '^')
            {
                throw new InvalidOperationException();
            }
            pos++;
            ReadWhiteSpace(s, ref pos);
            var ps = ReadSign(s, ref pos);
            if (ps == Sign.None)
            {
                ps = Sign.Positive;
            }
            ReadWhiteSpace(s, ref pos);
            var i = ReadSingleCharInt(s, ref pos);
            return (int)ps * i;
        }

        private static int ReadSuperScriptPower(string s, ref int pos)
        {
            if (Superscripts.IndexOf(s[pos]) == -1)
            {
                throw new InvalidOperationException();
            }

            var ps = ReadSuperScriptSign(s, ref pos);
            if (ps == Sign.None)
            {
                ps = Sign.Positive;
            }
            ReadWhiteSpace(s, ref pos);
            var i = ReadSingleCharSuperScriptInt(s, ref pos);
            return (int)ps * i;
        }

        private static Sign ReadSuperScriptSign(string s, ref int pos)
        {
            var sign = Sign.None;
            if (s[pos] == '⁺')
            {
                sign = Sign.Positive;
            }

            if (s[pos] == '⁻')
            {
                sign = Sign.Negative;
            }

            if (sign != Sign.None)
            {
                pos++;
            }
            return sign;
        }

        private static int ReadSingleCharInt(string s, ref int pos)
        {
            if (!Char.IsDigit(s[pos]))
            {
                throw new FormatException(String.Format("Expected digit at pos: {0} in {1} was {2}", pos, s, s[pos]));
            }
            int i = (int)Char.GetNumericValue(s[pos]);
            pos++;
            if (pos < s.Length && Char.IsDigit(s[pos]))
            {
                throw new FormatException(String.Format("Did not expect digit at pos: {0} in {1} was {2}", pos, s, s[pos]));
            }
            return i;
        }

        private static int ReadSingleCharSuperScriptInt(string s, ref int pos)
        {
            var indexOf = SuperscriptDigits.IndexOf(s[pos]);
            if (indexOf == -1)
            {
                throw new FormatException(String.Format("Expected digit at pos: {0} in {1} was {2}", pos, s, s[pos]));
            }
            int i = indexOf;
            pos++;
            if (pos < s.Length && SuperscriptDigits.IndexOf(s[pos]) != -1)
            {
                throw new FormatException(String.Format("Did not expect digit at pos: {0} in {1} was {2}", pos, s, s[pos]));
            }
            return i;
        }

        private static bool Read(string s, ref int pos, string toRead)
        {
            int start = pos;
            while (s.Length < pos && pos - start < toRead.Length)
            {
                if (s[pos] != toRead[pos - start])
                {
                    pos = start;
                    return false;
                }
                pos++;
            }
            return true;
        }

        private static Sign ReadSign(string s, ref int pos)
        {
            var sign = Sign.None;
            if (s[pos] == '+')
            {
                sign = Sign.Positive;
            }

            if (s[pos] == '-')
            {
                sign = Sign.Negative;
            }

            if (sign != Sign.None)
            {
                pos++;
            }
            return sign;
        }

        private static void ReadWhiteSpace(string s, ref int pos)
        {
            while (s.Length > pos && Char.IsWhiteSpace(s[pos]))
            {
                pos++;
            }
        }

        private enum Operator
        {
            None,
            Multiply,
            Division
        }
    }
}
