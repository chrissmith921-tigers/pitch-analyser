using Baseball_analyser.Datatypes;
using Baseball_analyser.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Baseball_analyser.Logic
{
    public class PitchAnalyser
    {
        private readonly IDataLoader _dataLoader;
        private PitchCollection _pitchCollection;
        public PitchAnalyser(IDataLoader dataLoader)
        {
            _dataLoader = dataLoader;
        }

        public Double GetStrikePercentage(string pitchType)
        {
            return GetStrikePercentage("SampleData\\sampleDataset.json", pitchType);
        }
        /// <summary>
        /// Allows override of file path to data file.
        /// </summary>
        /// <param name="dataFile">Local path to data file</param>
        /// <param name="pitchType">Pitch type</param>
        /// <returns>A double which represents the percentage of pitches that are strikes</returns>
        public Double GetStrikePercentage(string dataFile, string pitchType)
        {
            if (_pitchCollection == null)
            {
                //only load from the file once per use. 
                _pitchCollection = _dataLoader.GetPitchesFromFile(dataFile);
            }
            var pitches = _pitchCollection.Pitches.Where(
                r => r.PitchType.Equals(pitchType, StringComparison.OrdinalIgnoreCase)
            ).ToArray();

            var totalPitchCount = pitches.Length;
            if (totalPitchCount == 0) return 0;
            var strikes = pitches.Where(x=>x.IsStrike()).Count();

            return (strikes / (double)totalPitchCount) * 100;
        }
    }
}
