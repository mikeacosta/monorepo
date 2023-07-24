using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaApi.Contracts;
using PizzaApi.Models;

namespace PizzaApi.Controllers;

[Route("api/pizza")]
[ApiController]
public class PizzaController : ControllerBase
{
    private readonly IRepositoryWrapper _repository;
    private readonly IMapper _mapper;

    public PizzaController(IRepositoryWrapper repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    [HttpGet]
    public IActionResult GetAllOwners()
    {
        try
        {
            var pizzas = _repository.Pizza.GetAllPizzas();
            var pizzasResult = _mapper.Map<IEnumerable<PizzaDto>>(pizzas);
            return Ok(pizzasResult); 
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpGet("{id}")]
    public IActionResult GetPizzaById(int id)
    {
        try
        {
            var pizza = _repository.Pizza.GetPizzaById(id);
            if (pizza == null)
                return NotFound();

            var pizzaDto = _mapper.Map<PizzaDto>(pizza);
            return Ok(pizzaDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}