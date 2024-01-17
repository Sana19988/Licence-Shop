using LicenceStore.Application.Category.Commands;
using LicenceStore.Application.Category.Queries;
using LicenceStore.Application.Common.Dto.Category;
using Microsoft.AspNetCore.Mvc;

namespace LicenceStore.Api.Controllers;

[Route("category")]
public class CategoryController : ApiControllerBase
{
    [HttpGet("GetOneCategory")]
    public async Task<ActionResult<CategoryDetailsDto>> GetOneCategory([FromQuery] GetOneCategoryQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpGet("GetAllCategories")]
    public async Task<ActionResult<CategoryDetailsDto>> GetAllCategories([FromQuery] GetAllCategoriesQuery query) =>
        Ok(await Mediator.Send(query));
    
    [HttpPost("CreateCategory")]
    public async Task<ActionResult<string>> CreateCategory(CreateCategoryCommand command) =>
        Ok(await Mediator.Send(command));
    
    [HttpPut("UpdateCategory")]
    public async Task<ActionResult<string>> UpdateCategory(UpdateCategoryCommand command) =>
        Ok(await Mediator.Send(command));
    
    [HttpDelete("CreateCategory")]
    public async Task<ActionResult<string>> DeleteCategory(DeleteCategoryCommand command) =>
        Ok(await Mediator.Send(command));
}