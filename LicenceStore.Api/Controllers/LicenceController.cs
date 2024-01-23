using LicenceStore.Application.Common.Dto.Licence;
using LicenceStore.Application.Licence.Commands;
using LicenceStore.Application.Licence.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LicenceStore.Api.Controllers;

[Route("licence")]
public class LicenceController : ApiControllerBase
{
    [HttpGet("GetOneLicence")]
    public async Task<ActionResult<LicenceDetailsDto>> GetOneLicence([FromQuery] GetOneLicenceQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpGet("GetAllLicences")]
    public async Task<ActionResult<LicenceDetailsDto>> GetAllLicences([FromQuery] GetAllLicencesQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpPost("CreateLicence")]
    public async Task<ActionResult<string>> CreateLicence(CreateLicenceCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpPost("UpdateLicence")]
    public async Task<ActionResult<string>> UpdateLicence(UpdateLicenceCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpDelete("DeleteLicence")]
    public async Task<ActionResult<string>> DeleteLicence(DeleteLicenceCommand command) =>
        Ok(await Mediator.Send(command));

    [HttpGet("GetPagedListLicence")]
    public async Task<ActionResult<LicencePagedListDto>> GetPagedListLicence([FromQuery] GetPagedListLicenceQuery query) =>
        Ok(await Mediator.Send(query));
}