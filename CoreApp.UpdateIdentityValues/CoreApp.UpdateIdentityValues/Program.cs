using System.Configuration;
using Microsoft.Extensions.Configuration;
using UpdateIdentityValues.Common.Models;
using UpdateIdentityValues.Flow;

class Program
{
    static async Task Main(string[] args)
    {
        // var envName = System.Configuration.ConfigurationManager.AppSettings["EnvironmentName"];
        // Console.WriteLine($"Environemnt Name is: {envName}");
        //
        // var configRoot = new ConfigurationBuilder()
        //     .AddJsonFile("appsettings.json")
        //     .AddJsonFile($"appsettings.{envName}.json")
        //     .Build();
        
        // var configSection = configBuilder.GetSection("ServerIdentityValuesConfig");
        // var testVal = configSection["Run"] ?? null;
        //
        // if (testVal != null)
        //     Console.WriteLine(testVal);

        // var runConfig = configRoot.GetSection("UpdateIdentitySettings:RunConfig");
        // //var serverIdentityValuesConfig = configRoot["ServerIdentityValuesConfig"];
        // var list = new List<ServerIdentityValuesModel>();
        // runConfig.Bind(list);
        
        // Console.WriteLine(list.Count);

        var flow = new Flow();
        var serverIdentityValuesModelList = await flow.ConfigureRun();
        // await flow.Run(serverIdentityValuesModelList);
        
        Console.WriteLine("hey");
        Console.WriteLine(serverIdentityValuesModelList.Count);
    }
}