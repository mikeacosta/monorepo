using AutoMapper;
using Company.API.Models;
using Company.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Company.API.Controllers;

[ApiController]
[Route("api/companies")]
public class CompaniesController : ControllerBase
{
    private readonly ICompaniesRepository _repository;
    private readonly IMapper _mapper;

    public CompaniesController(ICompaniesRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CompanyDto>>> GetCompanies()
    {
        var companies = await _repository.GetCompaniesAsync()
            ;
        var result = _mapper.Map<IEnumerable<CompanyDto>>(companies);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CompanyDto>> GetCompany(int id)
    {
        var company = await _repository.GetCompanyAsync(id);
        if (company == null)
            return NotFound();
        
        var dto = _mapper.Map<CompanyDto>(company);
        return Ok(dto);
    }
    
    [HttpPost]
    public async Task<ActionResult<CompanyDto>> PostCompany([FromBody] CompanyDto dto)
    {
        var entity = _mapper.Map<Entities.Company>(dto);
        var company = await _repository.CreateCompanyAsync(entity);
        var createdDto = _mapper.Map<CompanyDto>(company);
    
        return CreatedAtAction("PostCompany", new { id = createdDto.Id }, createdDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutCompany(int id, [FromBody] CompanyDto dto)
    {
        if (id != dto.Id)
            return BadRequest();
        
        var entity = await _repository.GetCompanyAsync(id);
        if (entity == null)
            return NotFound();

        await _repository.UpdateCompanyAsync(_mapper.Map(dto, entity));
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var company = await _repository.GetCompanyAsync(id);
        if (company == null)
            return NotFound();
        
        _repository.DeleteCompany(company);
        return NoContent();
    }
}