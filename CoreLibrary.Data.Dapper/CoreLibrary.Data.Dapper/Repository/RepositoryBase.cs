using CoreLibrary.Data.Dapper.Context;
using CoreLibrary.Data.Dapper.Context.Interface;

namespace CoreLibrary.Data.Dapper.Repository;

public abstract class RepositoryBase
{
    public IDataContextService DataContextService { get; set; }
    public string ConnectionString;
    public string DatabaseName;

    protected RepositoryBase(IDataContextService? dataService = null)
    {
    }
    
    protected RepositoryBase(string connectionString, string databaseName, IDataContextService? dataService = null)
    {
        ConnectionString = connectionString;
        DatabaseName = databaseName;
        DataContextService = dataService ?? new DataContextService(connectionString);
    }
}