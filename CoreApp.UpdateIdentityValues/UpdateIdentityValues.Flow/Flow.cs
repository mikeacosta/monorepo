using Microsoft.Extensions.Configuration;
using UpdateIdentityValues.Common.Interfaces;
using UpdateIdentityValues.Common.Models;

namespace UpdateIdentityValues.Flow;

public class Flow : IFlow
{
    public async Task<List<ServerIdentityValuesModel>> ConfigureRun()
    {
        await Task.Yield();
        var envName = System.Configuration.ConfigurationManager.AppSettings["EnvironmentName"];
        
        var configRoot = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .AddJsonFile($"appsettings.{envName}.json")
            .Build();
        
        var runConfig = configRoot.GetSection("UpdateIdentitySettings:RunConfig");
        var serverModelList = new List<ServerIdentityValuesModel>();
        runConfig.Bind(serverModelList);
        
        // populate IdentityValueModel list
        foreach (var serverModel in serverModelList)
        {
            var criteria = new IdentityValuesFilterCriteria()
            {
                DatabaseServerName = serverModel.ServerName,
                DatabaseName = serverModel.DatabaseName,
                ConnectionString = serverModel.ConnectionString
            };
            
            
        }
        
        return serverModelList;
    }

    public Task<List<ServerIdentityValuesModel>> Run(List<ServerIdentityValuesModel> serverIdentityValuesModels)
    {
        throw new NotImplementedException();
    }
}