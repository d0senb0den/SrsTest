namespace SrsTest
{
    public interface ISrsTrainableShortcut
    {
        int DeckIndex { get; set; }
        string DifficultyLevel { get; set; }
        bool HasBeenUsed { get; set; }
        int Id { get; set; }
        bool IsMastered { get; set; }
        ISrsSchema SrsSchema { get; set; }
        int SupportedProgramId { get; set; }

    }
}