using PizzaApi.Entities;

namespace PizzaApi.Contracts;

public interface IPizzaRepository : IRepositoryBase<Pizza>
{
    IEnumerable<Pizza> GetAllPizzas();
}