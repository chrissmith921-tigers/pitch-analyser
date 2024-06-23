namespace Baseball_analyser.Helper
{
    using Datatypes;
    using System.IO;
    using System.Text.Json;

    public class DataLoader : IDataLoader
    {
        /// <summary>
        /// Loads a sample data file from a given filepath
        /// </summary>
        /// <param name="localFilePath">Path to file - relative to project.</param>
        /// <returns>A copy of the data as a PitchCollection object.</returns>
        public PitchCollection GetPitchesFromFile(string localFilePath)
        {
            PitchCollection source = new PitchCollection();

            using (StreamReader r = new StreamReader(localFilePath))
            {
                string json = r.ReadToEnd();
                source = JsonSerializer.Deserialize<PitchCollection>(json);
            }

            return source;
        }
    }
}
