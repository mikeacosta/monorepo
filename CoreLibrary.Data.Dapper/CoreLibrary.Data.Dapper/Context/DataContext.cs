using System.Data;
using System.Data.SqlClient;
using CoreLibrary.Data.Dapper.Query;
using Dapper;

namespace CoreLibrary.Data.Dapper.Context;

public class DataContext
{
    private readonly string _connectionString;

    public DataContext(string connectionString)
    {
        _connectionString = connectionString;
        SqlMapper.AddTypeMap(typeof(string), DbType.AnsiString);
    }

    public T GetRow<T>(QueryPacket queryPacket, CommandType commandType = CommandType.Text,
        int? commandTimeout = default)
    {
        using var db = new SqlConnection(_connectionString);
        var result = db.Query<T>(queryPacket.SqlString, queryPacket.SqlParams, commandType: commandType,
            commandTimeout: commandTimeout);
        return result.FirstOrDefault();
    }
    
    public async Task<T> GetRowAsync<T>(QueryPacket queryPacket, CommandType commandType = CommandType.Text,
        int? commandTimeout = default)
    {
        using var db = new SqlConnection(_connectionString);
        var result = await db.QueryAsync<T>(queryPacket.SqlString, queryPacket.SqlParams, commandType: commandType,
            commandTimeout: commandTimeout);
        return result.FirstOrDefault();
    }
    
    public IList<T> GetRows<T>(QueryPacket queryPacket, CommandType commandType = CommandType.Text,
        int? commandTimeout = default)
    {
        using var db = new SqlConnection(_connectionString);
        var result = db.Query<T>(queryPacket.SqlString, queryPacket.SqlParams, commandType: commandType,
            commandTimeout: commandTimeout);
        return result.ToList();
    }
    
    public async Task<IList<T>> GetRowsAsync<T>(QueryPacket queryPacket, CommandType commandType = CommandType.Text,
        int? commandTimeout = default)
    {
        using var db = new SqlConnection(_connectionString);
        var result = await db.QueryAsync<T>(queryPacket.SqlString, queryPacket.SqlParams, commandType: commandType,
            commandTimeout: commandTimeout);
        return result.ToList();
    }
    
    public int Execute(QueryPacket queryPacket, CommandType commandType = CommandType.Text,
        int? commandTimeout = default)
    {
        using var db = new SqlConnection(_connectionString);
        var result = db.Execute(queryPacket.SqlString, queryPacket.SqlParams, commandType: commandType,
            commandTimeout: commandTimeout);
        return result;
    }
}