namespace Company.API.Services;

public interface ICompaniesRepository
{
    Task<IEnumerable<Entities.Company>> GetCompaniesAsync();
    
    Task<Entities.Company?> GetCompanyAsync(int id);
}