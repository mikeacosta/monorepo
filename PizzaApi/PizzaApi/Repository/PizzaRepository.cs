using PizzaApi.Contracts;
using PizzaApi.Entities;

namespace PizzaApi.Repository;

public class PizzaRepository : RepositoryBase<Pizza>, IPizzaRepository
{
    public PizzaRepository(PizzaApiDbContext dbContext) : base(dbContext)
    {
    }
}