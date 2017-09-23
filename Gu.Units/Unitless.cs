#pragma warning disable 1591
namespace Gu.Units
{
    public partial struct Unitless
    {
        public static implicit operator double(Unitless ul)
        {
            return ul.Scalar;
        }

        public static explicit operator Unitless(double d)
        {
            return FromScalar(d);
        }
    }
}
