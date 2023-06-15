using UpdateIdentityValues.Common.Models;

namespace UpdateIdentityValues.Common.Interfaces;

public interface IFlow
{
    Task<List<ServerIdentityValuesModel>> ConfigureRun();
    Task<List<ServerIdentityValuesModel>> Run(List<ServerIdentityValuesModel> serverIdentityValuesModels);
}