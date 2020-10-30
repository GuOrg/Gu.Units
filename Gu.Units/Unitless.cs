#pragma warning disable 1591
namespace Gu.Units
{
    /// <summary>
    /// Implicit conversions.
    /// </summary>
    public partial struct Unitless
    {
#pragma warning disable CA2225 // Operator overloads have named alternates
        public static implicit operator double(Unitless ul)
        {
            return ul.Scalar;
        }

        public static explicit operator Unitless(double d)
        {
            return FromScalar(d);
        }
#pragma warning restore CA2225 // Operator overloads have named alternates
    }
}
