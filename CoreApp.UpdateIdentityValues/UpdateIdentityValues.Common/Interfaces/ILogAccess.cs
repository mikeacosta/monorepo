using UpdateIdentityValues.Common.Models;

namespace UpdateIdentityValues.Common.Interfaces;

public interface ILogAccess
{
    Task<LogModel> SaveLog(LogModel logModel);
    Task<LogModel> FindLog(FindLogCriteria criteria);
}