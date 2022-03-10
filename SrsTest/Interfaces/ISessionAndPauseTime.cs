namespace SrsTest
{
    internal interface ISessionAndPauseTime
    {
        TimeSpan? PauseTime { get; set; }
        ISrsSession? SrsSession { get; set; }
    }
}