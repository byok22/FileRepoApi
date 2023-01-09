using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi;
using TodoApi.Controllers.Common;
using TodoApi.Infrastructure.Persistance;

[ApiController]
[Route("[controller]")]
public class SCUserController : ControllerBase, IActionResult
{
    private readonly ILogger<SCUserController> _logger;
    private readonly IGenericService<ScUser> _service = new GenericService<ScUser>(); 

    public SCUserController(ILogger<SCUserController> logger)
    {
        _logger = logger;
    }
    public Task ExecuteResultAsync(ActionContext context)
    {
        throw new NotImplementedException();
    }
    
    [Route("CreateSCUser")] 
    [HttpPost(Name = "CreateSCUser")]
    public async Task<IActionResult> CreateSCUser([FromBody] ScUser scUser)
    {
        _logger.LogInformation("CreateSCUser");
        await _service.Create(scUser);
       
        return Ok(scUser);
    }

    

    [Route("GetSCUser/{id}")]
    [HttpGet]
    public async Task<IActionResult> GetSCUser(int id)
    {
        var scUser = await _service.Get(id);
        if (scUser == null)
        {
            return NotFound();
        }
        return Ok(scUser);
    }

    [Route("GetAllSCUsers")]
    [HttpGet]
    public async Task<IActionResult> GetAllSCUsers()
    {
        _logger.LogInformation("GetAllSCUsers");
        var scUsers = await _service.GetAll();
        return Ok(scUsers);
    }
    [Route("UpdateSCUser")]
    [HttpPut]
    public async Task<IActionResult> UpdateSCUser([FromBody] ScUser scUser)
    {
        await _service.Update(scUser);
        return Ok(scUser);
    }
    [Route("DeleteSCUser")]
    [HttpDelete]
    public async Task<IActionResult> DeleteSCUser([FromBody] ScUser scUser)
    {
        await _service.Delete(scUser);
        return Ok(scUser);
    }
}