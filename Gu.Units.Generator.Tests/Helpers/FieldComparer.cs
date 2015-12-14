namespace Gu.Units.Generator.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    public class FieldComparer : IComparer
    {
        public static readonly FieldComparer Default = new FieldComparer();

        private FieldComparer()
        {
        }

        public int Compare(object x, object y)
        {
            return Compare(x, y, new List<ComparedPair>());
        }

        private int Compare(object x, object y, List<ComparedPair> compared)
        {
            if (x == null && y == null)
            {
                return 0;
            }

            if (x == null || y == null)
            {
                return -1;
            }

            if (x.GetType() != y.GetType())
            {
                return -1;
            }

            var fields = x.GetType().GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
            foreach (var field in fields)
            {
                var oX = field.GetValue(x);
                var oY = field.GetValue(y);
                if (field.FieldType.IsEquatable())
                {
                    if (!Equals(oX, oY))
                    {
                        return -1;
                    }
                }
                else
                {
                    if (compared.Any(c => c.HasCompared(oX, oY)))
                    {
                        return 0;
                    }

                    compared.Add(new ComparedPair(oX, oY));
                    if (Compare(oX, oY, compared) != 0)
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }

        private class ComparedPair
        {
            internal readonly object X;
            internal readonly object Y;

            public ComparedPair(object x, object y)
            {
                this.X = x;
                this.Y = y;
            }

            public bool HasCompared(object x, object y)
            {
                return ReferenceEquals(this.X, x) && ReferenceEquals(this.Y, y);
            }
        }
    }
}