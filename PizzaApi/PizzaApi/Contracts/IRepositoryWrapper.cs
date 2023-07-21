namespace PizzaApi.Contracts;

public interface IRepositoryWrapper
{
    IPizzaRepository Pizza { get; }
    void Save();
}