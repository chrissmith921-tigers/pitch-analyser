using Newtonsoft.Json;

namespace Baseball_analyser.Datatypes
{
    public class PitchCollection
    {
        [JsonProperty("Pitches")]
        public Pitch[] Pitches { get; set; }
    }
}
