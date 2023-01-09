using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoApi;
using TodoApi.Models;

[ApiController]
[Route("[controller]")]
public class CarsController : ControllerBase, IActionResult
{
    private readonly ILogger<CarsController> _logger;
    private readonly CarsContext _carsContext = new CarsContext();

 
    public Task ExecuteResultAsync(ActionContext context)
    {
        throw new NotImplementedException();
    }
    
    [Route("CreateCar")] 
    [HttpPost(Name = "CreateCar")]
    public async Task<IActionResult> CreateCar([FromBody] Car car)
    {
        _carsContext.Cars.Add(car);
        await _carsContext.SaveChangesAsync();
        return Ok(car);
    }

    

    [Route("GetCar")]
    [HttpGet]
    public async Task<IActionResult> GetCar(int id)
    {
        var car = await _carsContext.Cars.FindAsync(id);
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [Route("GetAllCars")]
    [HttpGet]
    public async Task<IActionResult> GetAllCars()
    {
        var cars = await _carsContext.Cars.ToListAsync();
        if (cars == null)
        {
            return NotFound();
        }
        return Ok(cars);
    }
    [Route("UpdateCar")]
    [HttpPut]
    public async Task<IActionResult> UpdateCar([FromBody] Car car)
    {
        _carsContext.Cars.Update(car);
        await _carsContext.SaveChangesAsync();
        return Ok(car);
    }

    [Route("GetCarByName")]
    [HttpGet]
    public async Task<IActionResult> GetCarByName(string CarModel)
    {
        var car = await _carsContext.Cars.Where(x => x.CarModel == CarModel).FirstOrDefaultAsync();
        if (car == null)
        {
            return NotFound();
        }
        return Ok(car);
    }

    [Route("GetAutoComplete")]
    [HttpGet]
    public async Task<IActionResult> GetAutoComplete(string CarModel)
    {
        var cars = await _carsContext.Cars.Where(x => x.CarModel.Contains(CarModel)).ToListAsync();
        if (cars == null)
        {
            return NotFound();
        }
        return Ok(cars);
    }

}

