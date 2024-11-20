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
}