namespace CoreLibrary.Data.Dapper.Query;

public class QueryPacket
{
    public string Database { get; set; }
    public string SqlString { get; set; }
    public object? SqlParams { get; set; }

    public QueryPacket(string sqlString, string sqlDatabase)
    {
        Database = sqlDatabase;
        SqlString = sqlString;
        SqlParams = null;
    }

    public QueryPacket(string sqlString, object sqlParams, string sqlDatabase)
    {
        Database = sqlDatabase;
        SqlString = sqlString;
        SqlParams = sqlParams;
    }
}