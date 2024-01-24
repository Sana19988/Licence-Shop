using LicenceStore.Application.Administrator.Commands.CreateAdministratorCommand;
using LicenceStore.Application.Auth.Commands.BeginLoginCommand;
using LicenceStore.Application.Auth.Commands.CompleteLoginCommand;
using LicenceStore.Application.Common.Constants;
using LicenceStore.Application.Customer.Commands.CreateCustomerCommand;
using LicenceStore.Application.Salesman.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicenceStore.Api.Controllers;

public class AuthController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpPost("RegisterCustomer")]
    public async Task<ActionResult> RegisterCustomer(CreateCustomerCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [AllowAnonymous]
    [HttpPost("RegisterAdmin")]
    public async Task<ActionResult> RegisterAdministrator(CreateAdministratorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [AllowAnonymous]
    [HttpPost("RegisterSalesman")]
    public async Task<ActionResult> RegisterSalesman(CreateSalesmanCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [AllowAnonymous]
    [HttpPost("BeginLogin")]
    public async Task<ActionResult> BeginLogin(BeginLoginCommand command) => Ok(await Mediator.Send(command));

    [AllowAnonymous]
    [HttpGet("{validationToken}/CompleteLogin")]
    public async Task<ActionResult> CompleteLogin([FromRoute] string validationToken) => 
        Ok(await Mediator.Send(new CompleteLoginCommand(validationToken)));
}
