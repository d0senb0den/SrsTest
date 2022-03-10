namespace SrsTest
{
    public interface ISrsSession
    {
        int CurrentRepCount { get; set; }
        DateTime? DeadLine { get; set; }
        DateTime? EndedTime { get; set; }
        int GoalRepCount { get; set; }
        int Id { get; set; }
        TimeSpan? MaxDuration { get; set; }
        DateTime? ScheduledDateTime { get; set; }
        string? State { get; set; }
    }
}