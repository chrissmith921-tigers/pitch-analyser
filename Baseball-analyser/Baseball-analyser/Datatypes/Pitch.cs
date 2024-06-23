using Newtonsoft.Json;

namespace Baseball_analyser.Datatypes
{
    public class Pitch
    {
        [JsonProperty("PitchType")]
        public string PitchType { get; set; }

        [JsonProperty("HorizontalPoint")]
        public double HorizontalPoint { get; set; }

        [JsonProperty("VerticalPoint")]
        public double VerticalPoint { get; set; }

        public override string ToString()
        {
            return $"Horizontal Point: {HorizontalPoint}, Vertical Point: {VerticalPoint}, Type: {PitchType}";
        }
    }
}
