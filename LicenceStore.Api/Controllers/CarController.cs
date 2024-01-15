using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LicenceStore.Application.Car.Commands;
using LicenceStore.Application.Car.Queries;

namespace LicenceStore.Api.Controllers;

[Route("car")]
[Authorize]
public class CarController : ApiControllerBase
{
    [HttpGet("GetOneCar")]
    public async Task<ActionResult> GetCar([FromQuery] GetCarQuery query) => Ok(await Mediator.Send(query));

    [HttpPost("CreateCar")]
    public async Task<ActionResult> CreateCar(CreateCarCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
