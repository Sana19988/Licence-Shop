using LicenceStore.Application.Common.Dto.Order;
using LicenceStore.Application.Order.Commands;
using LicenceStore.Application.Order.Queries;
using Microsoft.AspNetCore.Mvc;

namespace LicenceStore.Api.Controllers;

[Route("order")]
public class OrderController : ApiControllerBase
{
    [HttpGet("GetOneOrder")]
    public async Task<ActionResult<OrderDetailsDto>> GetOneOrder([FromQuery] GetOneOrderQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpGet("GetAllOrders")]
    public async Task<ActionResult<OrderDetailsDto>> GetAllOrders([FromQuery] GetAllOrdersQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpPost("CreateOrder")]
    public async Task<ActionResult<string>> CreateOrder(CreateOrderCommand command) => 
        Ok(await Mediator.Send(command));
    
    [HttpPost("UpdateOrder")]
    public async Task<ActionResult<string>> UpdateOrder(UpdateOrderCommand command) => 
        Ok(await Mediator.Send(command));
    
    [HttpDelete("DeleteOrder")]
    public async Task<ActionResult<string>> DeleteOrder(DeleteOrderCommand command) => 
        Ok(await Mediator.Send(command));
    
    [HttpGet("GetPagedListOrder")]
    public async Task<ActionResult<OrderPagedListDto>> GetPagedListOrder([FromQuery] GetPagedListOrderQuery query) =>
        Ok(await Mediator.Send(query));
}