#pragma warning disable 1591
namespace Gu.Units
{
    using System;

    public partial struct Time
    {
        public static explicit operator TimeSpan(Time time)
        {
            return TimeSpan.FromSeconds(time.seconds);
        }

        public static explicit operator Time(TimeSpan timeSpan)
        {
            return FromSeconds(timeSpan.TotalSeconds);
        }
    }
}