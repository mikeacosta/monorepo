using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PizzaApi.Contracts;
using PizzaApi.Entities;
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
    public IActionResult GetAllPizzas()
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

    [HttpGet("{id}", Name = "PizzaById")]
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

    [HttpPost]
    public IActionResult CreatePizza([FromBody] PizzaForCreationDto dto)
    {
        try
        {
            if (dto is null)
                return BadRequest("Pizza object sent from client is null");

            if (!ModelState.IsValid)
                return BadRequest("Invalid model object");

            var pizza = _mapper.Map<Pizza>(dto);
            
            _repository.Pizza.Create(pizza);
            _repository.Save();

            var createdDto = _mapper.Map<PizzaDto>(pizza);
            return CreatedAtRoute("PizzaById", new { id = createdDto.Id }, createdDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }

    [HttpPut("{id}")]
    public IActionResult UpdatePizza(int id, [FromBody] PizzaForUpdateDto pizza)
    {
        try
        {
            if (pizza is null)
            {
                return BadRequest("Pizza object is null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid model object");
            }
            var pizzaEntity = _repository.Pizza.GetPizzaById(id);
            if (pizzaEntity is null)
            {
                return NotFound();
            }
            _mapper.Map(pizza, pizzaEntity);
            _repository.Pizza.UpdatePizza(pizzaEntity);
            _repository.Save();
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}