using LicenceStore.Application.Auth.Commands.BeginLoginCommand;
using LicenceStore.Application.Auth.Commands.CompleteLoginCommand;
using LicenceStore.Application.Common.Constants;
using LicenceStore.Application.Customer.Commands.CreateCustomerCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LicenceStore.Api.Controllers;

public class AuthController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpPost("Register")]
    public async Task<ActionResult> Register(CreateCustomerCommand command)
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
