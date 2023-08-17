using PizzaApi.Entities;
using PizzaApi.Models;

namespace PizzaApi.Contracts;

public interface IPizzaRepository : IRepositoryBase<Pizza>
{
    IEnumerable<Pizza> GetAllPizzas();
    Pizza? GetPizzaById(int id);
    void CreatePizza(Pizza pizza);
    void UpdatePizza(Pizza pizza);
}