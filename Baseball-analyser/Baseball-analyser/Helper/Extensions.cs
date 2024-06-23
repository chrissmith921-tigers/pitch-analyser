using Baseball_analyser.Datatypes;

namespace Baseball_analyser.Helper
{
    public static class Extensions
    {
        /// <summary>
        /// Determines if pitch is inside the bounds of the strikezone. Units are in inches.
        /// </summary>
        /// <param name="pitch">The pitch object</param>
        /// <returns>true if pitch is in strike zone, (assuming very edge is not) otherwise false.</returns>
        public static bool IsStrike(this Pitch pitch)
        {
            return (pitch.HorizontalPoint < 8.5 && pitch.HorizontalPoint > -8.5 && pitch.VerticalPoint < 12 && pitch.VerticalPoint > -12);
        }
    }
}
