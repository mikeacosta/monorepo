using UpdateIdentityValues.Common.Models;

namespace UpdateIdentityValues.Common.Interfaces;

public interface IIdentityValuesAccess
{
    Task<ServerIdentityValuesModel> FindIdentityValues(IdentityValuesFilterCriteria criteria);
    Task<int> SaveIdentityValues(ServerIdentityValuesModel serverIdentityValuesModel);
}