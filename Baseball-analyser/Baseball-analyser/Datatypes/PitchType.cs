using System.Collections.Generic;

namespace Baseball_analyser.Datatypes
{
    /// <summary>
    /// Class to hold the different types of Pitches accepted by the system.
    /// </summary>
    public static class PitchType
    {
        public static string FastBall = "FB";
        public static string Cutter = "CT";
        public static string Slider = "SL";
        public static string CurveBall = "CB";
        /// <summary>
        /// List holding pitches to be checked 
        /// </summary>
        public static List<string> PitchTypesAccepted = new() { FastBall, Cutter, CurveBall, Slider };
    }
}
