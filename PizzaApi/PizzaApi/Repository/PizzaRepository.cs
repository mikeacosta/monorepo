using PizzaApi.Contracts;
using PizzaApi.Entities;

namespace PizzaApi.Repository;

public class PizzaRepository : RepositoryBase<Pizza>, IPizzaRepository
{
    public PizzaRepository(PizzaApiDbContext dbContext) : base(dbContext)
    {
    }
    
    public IEnumerable<Pizza> GetAllPizzas()
    {
        return FindAll()
            .OrderBy(p => p.Name)
            .ToList();
    }

    public Pizza? GetPizzaById(int id)
    {
        return FindByCondition(p => p.Id == id)
            .FirstOrDefault();
    }

    public void CreatePizza(Pizza pizza)
    {
        Create(pizza);
    }

    public void UpdatePizza(Pizza pizza)
    {
        Update(pizza);
    }

    public void DeletePizza(Pizza pizza)
    {
        Delete(pizza);
    }
}