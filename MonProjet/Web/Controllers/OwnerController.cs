using Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using AutoMapper;
using Entities.DTOs;

namespace Web.Controllers
{
    [Route("api/owners")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        private IRepositoryWrapper _repository;
        private readonly ILogger<OwnerController> _logger;
        private IMapper _mapper;

        public OwnerController(ILogger<OwnerController> logger,
            IRepositoryWrapper repository,
            IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOwners() 
        {
            try
            {
                var owners = await _repository.Owner.GetAllOwnersAsync();
                _logger.LogInformation($"Returned all owners from database.");
                var ownersResult = _mapper.Map<IEnumerable<OwnerDto>>(owners);
                return Ok(owners);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong inside GetAllOwners action: {ex.Message}");
                return StatusCode(500, "Internal server error");
            }
        }
        
        [HttpGet("{id}", Name = "OwnerById")] 
        public async Task<IActionResult> GetOwnerById(Guid id) 
        { 
            try 
            { 
                var owner = await _repository.Owner.GetOwnerByIdAsync(id); 
                if (owner == null) 
                { 
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db."); 
                    return NotFound(); 
                } 
                else 
                { 
                    _logger.LogInformation($"Returned owner with id: {id}");

                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult); 
                } 
            } 
            catch (Exception ex) 
            { 
                _logger.LogError($"Something went wrong inside GetOwnerById action: {ex.Message}"); 
                return StatusCode(500, "Internal server error"); 
            } 
        }
        
        [HttpGet("{id}/accounts")] 
        public async Task<IActionResult> GetOwnerWithDetails(Guid id) 
        { 
            try 
            { 
                var owner = await _repository.Owner.GetOwnerWithDetailsAsync(id); 
                if (owner == null) 
                { 
                    _logger.LogError($"Owner with id: {id}, hasn't been found in db."); 
                    return NotFound(); 
                } 
                else 
                { 
                    _logger.LogInformation($"Returned owner with details for id: {id}");

                    var ownerResult = _mapper.Map<OwnerDto>(owner);
                    return Ok(ownerResult); 
                } 
            } 
            catch (Exception ex) 
            { 
                _logger.LogError($"Something went wrong inside GetOwnerWithDetails action: {ex.Message}"); 
                return StatusCode(500, "Internal server error"); 
            }
        }
    }
}