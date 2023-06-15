using UpdateIdentityValues.Common.Models;

namespace UpdateIdentityValues.Common.Interfaces;

public interface IProcess
{
    Task<List<ServerIdentityValuesModel>> SourceValues(List<ServerIdentityValuesModel> serverIdentityValuesModels);
    Task<List<ServerIdentityValuesModel>> DestinationInitialValues(List<ServerIdentityValuesModel> serverIdentityValuesModels);
    Task<List<ServerIdentityValuesModel>> DetermineFinalValues(List<ServerIdentityValuesModel> serverIdentityValuesModels);
    Task<List<ServerIdentityValuesModel>> UpdateDestinationValues(List<ServerIdentityValuesModel> serverIdentityValuesModels);
}