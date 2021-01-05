namespace Gu.Units.Generator.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public sealed class UnitComparer : IComparer<BaseUnit>, IComparer
    {
        public static readonly UnitComparer Default = new UnitComparer();

        private UnitComparer()
        {
        }

        public int Compare(BaseUnit x, BaseUnit y)
        {
            if (x is null || y is null)
            {
                return -1;
            }

            if (x.GetType() != y.GetType())
            {
                return -1;
            }

            if (x.Symbol != y.Symbol)
            {
                return -1;
            }

            if (x.Name != y.Name)
            {
                return -1;
            }

            if (x.AllConversions.Any() || y.AllConversions.Any())
            {
                return -1;
            }

            return 0;
        }

        int IComparer.Compare(object x, object y)
        {
            return this.Compare((BaseUnit)x, (BaseUnit)y);
        }
    }
}