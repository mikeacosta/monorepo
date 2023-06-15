namespace UpdateIdentityValues.Common.Models;

public class ServerIdentityValuesModel
{
    public string Environment { get; set; }
    public string ServerName { get; set; }
    public string DatabaseName { get; set; }
    public string ConnectionStringName { get; set; }
    public string ConnectionString { get; set; }
    public int AddOnAmount { get; set; }
    public bool SourceServer { get; set; }
    public List<IdentityValueModel> IdentityValueModels { get; set; }

    public ServerIdentityValuesModel()
    {
        IdentityValueModels = new List<IdentityValueModel>();
    }
}