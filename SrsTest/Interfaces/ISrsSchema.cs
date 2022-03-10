namespace SrsTest
{
    public interface ISrsSchema
    {
        ISrsSession CurrentSession { get; }
        int CurrentSessionIndex { get; set; }
        IList<ISessionAndPauseTime> SessionsAndPauseTimes { get; set; }
        int ShortcutId { get; set; }
        int Id { get; set; }
    }
}