namespace Baseball_analyser.Helper
{
    using Baseball_analyser.Datatypes;

    /// <summary>
    /// Allows testing on the <see cref="DataLoader"/> object
    /// </summary>
    public interface IDataLoader
    {
        PitchCollection GetPitchesFromFile(string localFilePath);
    }
}
