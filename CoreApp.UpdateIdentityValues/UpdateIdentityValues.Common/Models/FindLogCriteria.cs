namespace UpdateIdentityValues.Common.Models;

public class FindLogCriteria
{
    public int? Id { get; set; }
    public DateTime? StartTimeStamp { get; set; }
    public DateTime? EndTimeStamp { get; set; }
    public bool? HasException { get; set; }
}