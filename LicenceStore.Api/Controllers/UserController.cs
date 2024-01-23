using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using LicenceStore.Application.Administrator.Commands.CreateAdministratorCommand;
using LicenceStore.Application.Common.Constants;
using LicenceStore.Application.Common.Dto.User;
using LicenceStore.Application.Customer.Commands.CreateCustomerCommand;
using LicenceStore.Application.Salesman.Commands;
using LicenceStore.Application.Users.Commands;
using LicenceStore.Application.Users.Queries;
using LicenceStore.Domain.Entities;

namespace LicenceStore.Api.Controllers;

// [Authorize(Roles = $"{LicenceStoreAuthorization.Customer}, {LicenceStoreAuthorization.Administrator}, {LicenceStoreAuthorization.Salesman}")]
[Route("user")]
public class UserController : ApiControllerBase
{
    [HttpGet("CetOneUser")]
    public async Task<ActionResult<UserDetailsDto>> GetOneUser([FromQuery] GetOneUserQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpGet("CetAllUsers")]
    public async Task<ActionResult<List<ApplicationUser>>> GetAllUsers([FromQuery] GetAllUsersQuery query) =>
        Ok(await Mediator.Send(query));


    [HttpPut("UpdateUser")]
    public async Task<ActionResult<string>> UpdateUser(UpdateUserCommand command) 
        => Ok(await Mediator.Send(command));


    [HttpDelete("DeleteUser")]
    public async Task<ActionResult<string>> DeleteUser(DeleteUserCommand command)
        => Ok(await Mediator.Send(command));
    
    [HttpPost("CreateCustomer")]
    [Authorize(Roles = LicenceStoreAuthorization.Customer)]
    public async Task<ActionResult> CreateCustomer(CreateCustomerCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }

    [HttpPost("CreateAdministrator")]
    [Authorize(Roles = LicenceStoreAuthorization.Administrator)]
    public async Task<ActionResult> CreateAdministrator(CreateAdministratorCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
        
    [HttpPost("CreateSalesman")]
    [Authorize(Roles = LicenceStoreAuthorization.Salesman)]
    public async Task<ActionResult> CreateSalesman(CreateSalesmanCommand command)
    {
        await Mediator.Send(command);
        return Ok();
    }
    
    [HttpPut("PagedList")]
    public async Task<ActionResult> PagedList([FromQuery] GetUserPagedListQuery query) =>
        Ok(await Mediator.Send(query));
}
