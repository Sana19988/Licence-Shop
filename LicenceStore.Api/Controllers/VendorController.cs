using LicenceStore.Application.Common.Dto.Vendor;
using LicenceStore.Application.Vendor.Commands;
using LicenceStore.Application.Vendor.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LicenceStore.Api.Controllers;

[Route("vendor")]
public class VendorController : ApiControllerBase
{
    [HttpGet("GetOneVendor")]
    public async Task<ActionResult<VendorDetailsDto>> GetVendor([FromQuery] GetOneVendorQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpGet("GetAllVendors")]
    public async Task<ActionResult<VendorListDto>> GetAllVendors([FromQuery] GetAllVendorsQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpPost("CreateVendor")]
    public async Task<ActionResult<string>> CreateVendor(CreateVendorCommand command) => 
        Ok(await Mediator.Send(command));
    
    [HttpPut("UpdateVendor")]
    public async Task<ActionResult<string>> UpdateVendor(UpdateVendorCommand command) => 
        Ok(await Mediator.Send(command));

    [HttpDelete("DeleteVendor")]
    public async Task<ActionResult<string>> DeleteVendor(DeleteVendorCommand command) =>
        Ok(await Mediator.Send(command));
    
}