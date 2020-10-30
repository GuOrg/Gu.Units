#pragma warning disable 1591
namespace Gu.Units
{
    using System;

    /// <summary>
    /// Explicit conversions.
    /// </summary>
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

        /// <summary>
        /// Create a <see cref="Time"/> with the equivalent value.
        /// </summary>
        /// <param name="timeSpan">The <see cref="TimeSpan"/>.</param>
        /// <returns>A <see cref="Time"/>.</returns>
        public static Time FromTimeSpan(TimeSpan timeSpan) => Time.FromSeconds(timeSpan.TotalSeconds);

        /// <summary>
        /// Create a <see cref="TimeSpan"/> with the equivalent value.
        /// </summary>
        /// <returns>A <see cref="TimeSpan"/>.</returns>
        public TimeSpan ToTimeSpan() => TimeSpan.FromSeconds(this.seconds);
    }
}