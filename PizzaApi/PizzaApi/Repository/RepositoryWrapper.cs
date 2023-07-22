using PizzaApi.Contracts;
using PizzaApi.Entities;

namespace PizzaApi.Repository;

public class RepositoryWrapper : IRepositoryWrapper
{
    private PizzaApiDbContext _dbContext;
    private IPizzaRepository _pizza;

    public RepositoryWrapper(PizzaApiDbContext dbContext, IPizzaRepository pizza)
    {
        _dbContext = dbContext;
        _pizza = pizza;
    }

    public IPizzaRepository Pizza => _pizza ?? new PizzaRepository(_dbContext);

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}