using LicenceStore.Application.Common.Dto.LicenceType;
using LicenceStore.Application.LicenceType.Commands;
using LicenceStore.Application.LicenceType.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LicenceStore.Api.Controllers;

[Route("licenceType")]
public class LicenceTypeController : ApiControllerBase
{
    [HttpGet("GetOneLicenceType")]
    public async Task<ActionResult<LicenceTypeDetailsDto>> GetOneLicenceType([FromQuery] GetOneLicenceTypeQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpGet("GetAllLicenceTypes")]
    public async Task<ActionResult<LicenceTypeDetailsDto>> GetAllLicences([FromQuery] GetAllLicenceTypesQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpPost("CreateLicenceType")]
    public async Task<ActionResult<string>> CreateLicenceType(CreateLicenceTypeCommand command) =>
        Ok(await Mediator.Send(command));
   
    [HttpPut("UpdateLicenceType")]
    public async Task<ActionResult<string>> UpdateLicenceType(UpdateLicenceTypeCommand command) =>
        Ok(await Mediator.Send(command));
    
    [HttpDelete("CreateLicenceType")]
    public async Task<ActionResult<string>> DeleteLicenceType(DeleteLicenceTypeCommand command) =>
        Ok(await Mediator.Send(command));
    
    [HttpGet("GetPagedListLicenceType")]
    public async Task<ActionResult<LicenceTypePagedListDto>> GetPagedListLicenceType([FromQuery] GetPagedListLicenceTypeQuery query) =>
        Ok(await Mediator.Send(query));
}