using LicenceStore.Application.Auth.Commands.BeginLoginCommand;
using LicenceStore.Application.Auth.Commands.CompleteLoginCommand;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LicenceStore.Application.Auth.Commands.BeginLoginCommand;
using LicenceStore.Application.Auth.Commands.CompleteLoginCommand;

namespace LicenceStore.Api.Controllers;

public class AuthController : ApiControllerBase
{
    [AllowAnonymous]
    [HttpPost("BeginLogin")]
    public async Task<ActionResult> BeginLogin(BeginLoginCommand command) => Ok(await Mediator.Send(command));

    [AllowAnonymous]
    [HttpGet("{validationToken}/CompleteLogin")]
    public async Task<ActionResult> CompleteLogin([FromRoute] string validationToken) => Ok(await Mediator.Send(new CompleteLoginCommand(validationToken)));
}
