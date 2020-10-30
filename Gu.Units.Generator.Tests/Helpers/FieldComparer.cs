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
            return this.Compare(x, y, new List<ComparedPair>());
        }

        private int Compare(object x, object y, ICollection<ComparedPair> compared)
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
                    if (this.Compare(oX, oY, compared) != 0)
                    {
                        return -1;
                    }
                }
            }

            return 0;
        }

        private class ComparedPair
        {
            private readonly object x;
            private readonly object y;

            internal ComparedPair(object x, object y)
            {
                this.x = x;
                this.y = y;
            }

            internal bool HasCompared(object xo, object yo)
            {
                return ReferenceEquals(this.x, xo) && ReferenceEquals(this.y, yo);
            }
        }
    }
}