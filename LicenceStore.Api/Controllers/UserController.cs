using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LicenceStore.Application.Administrator.Commands.CreateAdministratorCommand;
using LicenceStore.Application.Common.Constants;
using LicenceStore.Application.Customer.Commands.CreateCustomerCommand;

namespace LicenceStore.Api.Controllers;

// [Authorize(Roles = $"{RentalCarAuthorization.Customer}, {RentalCarAuthorization.Administrator}")]
public class UserController : ApiControllerBase
{
    [HttpPost("CreateCustomer")]
    [Authorize(Roles = RentalCarAuthorization.Customer)]
    public async Task<ActionResult> CreateCustomer(CreateCustomerCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("CreateAdministrator")]
    [Authorize(Roles = RentalCarAuthorization.Administrator)]
    public async Task<ActionResult> CreateAdministrator(CreateAdministratorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
}
