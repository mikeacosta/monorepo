using CoreLibrary.Data.Dapper.Context;
using CoreLibrary.Data.Dapper.Query;
using UpdateIdentityValues.Common.Interfaces;
using UpdateIdentityValues.Common.Models;

namespace UpdateIdentityValues.DataAccess;

public class IdentityValuesAccess : IIdentityValuesAccess
{
    public async Task<ServerIdentityValuesModel> FindIdentityValues(IdentityValuesFilterCriteria criteria)
    {
        var dataContextService = new DataContextService(criteria.ConnectionString);
        var sqlString = "";
        var query = new QueryPacket(sqlString, criteria.DatabaseName);
        var results = await dataContextService.DataContext.GetRowAsync<ServerIdentityValuesModel>(query);
        return results;
    }

    public async Task<int> SaveIdentityValues(ServerIdentityValuesModel serverIdentityValuesModel)
    {
        var dataContextService = new DataContextService(serverIdentityValuesModel.ConnectionString);
        var count = 0;
        foreach (var model in serverIdentityValuesModel.IdentityValueModels)
        {
            var query = new QueryPacket(model.SqlCommandToSetValue, serverIdentityValuesModel.DatabaseName);
            await dataContextService.DataContext.ExecuteAsync(query);
            count++;
        }

        return count;
    }
}