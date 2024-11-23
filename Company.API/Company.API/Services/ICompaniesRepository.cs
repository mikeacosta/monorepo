namespace Company.API.Services;

public interface ICompaniesRepository
{
    Task<IEnumerable<Entities.Company>> GetCompaniesAsync();
    
    Task<Entities.Company?> GetCompanyAsync(int id);
    
    Task<Entities.Company?> CreateCompanyAsync(Entities.Company company);
    
    Task UpdateCompanyAsync(Entities.Company company);
    
    void DeleteCompany(Entities.Company company);
}