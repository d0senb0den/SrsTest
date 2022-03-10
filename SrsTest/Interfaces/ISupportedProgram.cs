namespace SrsTest
{
    internal interface ISupportedProgram
    {
        int Id { get; set; }
        IList<ISrsTrainableShortcut> Shortcuts { get; set; }
    }
}