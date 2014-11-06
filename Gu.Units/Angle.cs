namespace Gu.Units
{
    public partial struct  Angle
    {
        public static implicit operator Angle(MathNet.Spatial.Units.Angle angle)
        {
            return Angle.FromRadians(angle.Radians);
        }

        public static implicit operator MathNet.Spatial.Units.Angle(Angle angle)
        {
            return MathNet.Spatial.Units.Angle.FromRadians(angle.Radians);
        }
    }
}
