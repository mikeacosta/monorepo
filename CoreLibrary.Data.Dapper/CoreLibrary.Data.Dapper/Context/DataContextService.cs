using CoreLibrary.Data.Dapper.Context.Interface;

namespace CoreLibrary.Data.Dapper.Context;

public class DataContextService : IDataContextService
{
    private readonly string _connectionString;

    public DataContextService(string connectionString)
    {
        _connectionString = connectionString;
    }

    public DataContext DataContext
    {
        get { return new DataContext(_connectionString); }
    }
}