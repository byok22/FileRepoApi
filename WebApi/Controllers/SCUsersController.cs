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
    
    [Route("Create")] 
    [HttpPost(Name = "Create")]
    public async Task<IActionResult> CreateSCUser([FromBody] ScUser scUser)
    {
        _logger.LogInformation("CreateSCUser");
        await _service.Create(scUser);
       
        return Ok(scUser);
    }

    

    [Route("Get/{id}")]
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

    [Route("GetAll")]
    [HttpGet]
    public async Task<IActionResult> GetAllSCUsers()
    {
        _logger.LogInformation("GetAllSCUsers");
        var scUsers = await _service.GetAll();
        return Ok(scUsers);
    }
    [Route("Update")]
    [HttpPut]
    public async Task<IActionResult> UpdateSCUser([FromBody] ScUser scUser)
    {
        await _service.Update(scUser);
        return Ok(scUser);
    }
    [Route("Delete/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteSCUser(int id)
    {
        var scUser = await _service.Get(id);
        if (scUser == null)
        {
            return NotFound();
        }
        await _service.Delete(scUser);
        return Ok(scUser);
    }
    
}