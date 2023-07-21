using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using PizzaApi.Contracts;
using PizzaApi.Entities;

namespace PizzaApi.Repository;

public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
{
    protected PizzaApiDbContext PizzaApiDbContext { get; set; } 
    public RepositoryBase(PizzaApiDbContext dbContext) 
    {
        PizzaApiDbContext = dbContext; 
    }
    public IQueryable<T> FindAll() => PizzaApiDbContext.Set<T>().AsNoTracking();
    public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => 
        PizzaApiDbContext.Set<T>().Where(expression).AsNoTracking();
    public void Create(T entity) => PizzaApiDbContext.Set<T>().Add(entity);
    public void Update(T entity) => PizzaApiDbContext.Set<T>().Update(entity);
    public void Delete(T entity) => PizzaApiDbContext.Set<T>().Remove(entity);
}