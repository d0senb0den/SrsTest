namespace SrsTest
{
    public interface ISessionAndPauseTime
    {
        TimeSpan? PauseTime { get; set; }
        ISrsSession? SrsSession { get; set; }
    }
}