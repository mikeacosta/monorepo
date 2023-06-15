namespace UpdateIdentityValues.Common.Models;

public class IdentityValueModel
{
    public string Table { get; set; }
    public string IdentityColumnName { get; set; }
    public string IdentityValue { get; set; }
    public string SqlCommandToSetValue { get; set; }
}