namespace CoreLibrary.Data.Dapper.Context;

public class DataContextService
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