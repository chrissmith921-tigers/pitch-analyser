using Baseball_analyser.Datatypes;
using Baseball_analyser.Helper;
using Baseball_analyser.Logic;
using System;
using System.Linq;
using System.Text.Json;

namespace Baseball_analyser
{
    class Program
    {
        static void Main(string[] args)
        {
            DataLoader dataLoader = new DataLoader();
            PitchAnalyser pitchAnalyser = new PitchAnalyser(dataLoader);
            string pitchChoice = string.Empty;
            do
            {
                Console.WriteLine("What pitch type would you like to get strike rate for? [All / FastBall [FB] / CurveBall [CB] / Slider [SL] / Cutter [CT]");
                pitchChoice = Console.ReadLine();

            } while (!PitchType.PitchTypesAccepted.Contains(pitchChoice) 
                && 
                (!pitchChoice.Equals("ALL", StringComparison.OrdinalIgnoreCase)));
            
            if (pitchChoice.Equals("ALL", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var pitchtyp in PitchType.PitchTypesAccepted)
                {
                    PrintOutput(pitchAnalyser.GetStrikePercentage(pitchtyp), pitchtyp);
                }
            }
            else
            {
                PrintOutput(pitchAnalyser.GetStrikePercentage(pitchChoice), pitchChoice);
            }
        }

        private static void PrintOutput(Double percentage, string pitchChoice)
        {
            Console.WriteLine($"{percentage}% strike rate for pitch type {pitchChoice}");
        }

    }
}
