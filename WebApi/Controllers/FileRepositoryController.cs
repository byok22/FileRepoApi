using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi;
using TodoApi.Controllers.Common;
using TodoApi.Controllers.Services;

[ApiController]
[Route("[controller]")]
public class SCUserController : ControllerBase, IActionResult
{
    private readonly ILogger<SCUserController> _logger;
    private readonly FileRepositoryService _service;

    public SCUserController(ILogger<SCUserController> logger, FileRepositoryService service)
    {
        _logger = logger;
        _service = service;
    }
   
    public Task ExecuteResultAsync(ActionContext context)
    {
        throw new NotImplementedException();
    }
    
    [Route("Create")] 
    [HttpPost(Name = "Create")]
    public async Task<IActionResult> Create([FromBody] FileRepositoryModel scUser)
    {
        _logger.LogInformation("CreateFileRepository");
        await _service.Create(scUser);
       
        return Ok(scUser);
    }

    
    [Route("Get/{id}")]
    [HttpGet]
    public async Task<IActionResult> Get(int id)
    {
        var item = await _service.Get(id);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }

    [Route("GetAll")]
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        _logger.LogInformation("GetAllFileRepositoryModel");
        var scUsers = await _service.GetAll();
        return Ok(scUsers);
    }
    [Route("Update")]
    [HttpPut]
    public async Task<IActionResult> Update([FromBody] FileRepositoryModel scUser)
    {
        await _service.Update(scUser);
        return Ok(scUser);
    }
    [Route("Delete/{id}")]
    [HttpDelete]
    public async Task<IActionResult> Delete(int id)
    {
        var item = await _service.Get(id);
        if (item == null)
        {
            return NotFound();
        }
        await _service.Delete(item);
        return Ok(item);
    }

    [Route("GetBySerialNumber/{serialNumber}")]
    [HttpGet]
    public async Task<IActionResult> GetBySerialNumber(string serialNumber)
    {
        var item = await _service.GetBySerialNumber(serialNumber);
        if (item == null)
        {
            return NotFound();
        }
        return Ok(item);
    }
    
}