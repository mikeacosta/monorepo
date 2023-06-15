namespace UpdateIdentityValues.Common.Models;

public class LogModel
{
    public int? Id { get; set; }
    public string Log { get; set; }
    public DateTime TimeStamp { get; set; }
    public string Exception { get; set; }
}