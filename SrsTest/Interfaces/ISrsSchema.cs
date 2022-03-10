namespace SrsTest
{
    public interface ISrsSchema
    {
        ISrsSession CurrentSession { get; }
        int CurrentSessionIndex { get; set; }
        int ShortcutId { get; set; }
    }
}