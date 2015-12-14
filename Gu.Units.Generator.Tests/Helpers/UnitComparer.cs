namespace Gu.Units.Generator.Tests
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class UnitComparer : IComparer<BaseUnit>, IComparer
    {
        public static readonly UnitComparer Default = new UnitComparer();

        private UnitComparer()
        {
        }

        public int Compare(BaseUnit x, BaseUnit y)
        {
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

            if (x.AllConversions.Count() != 0 || y.AllConversions.Count() != 0)
            {

            }

            return 0;
        }

        int IComparer.Compare(object x, object y)
        {
            return Compare((BaseUnit)x, (BaseUnit)y);
        }
    }
}