using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.Category;
using LicenceStore.Application.Common.Extensions.Category;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Category.Queries;

public record GetPagedListCategoryQuery(int PageNumber, int PageSize, string? SearchQuery) : IRequest<CategoryPagedListDto>;

public class GetPagedListCategoryQueryHandler : IRequestHandler<GetPagedListCategoryQuery, CategoryPagedListDto>
{
    private readonly IMapper _mapper;

    public GetPagedListCategoryQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<CategoryPagedListDto> Handle(GetPagedListCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await DB.PagedSearch<Domain.Entities.Category>()
            .Sort(c => c.Name, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);

        return _mapper.Map<CategoryPagedListDto>(category.Results)
            .AddPagination(new PaginationDto(category.TotalCount, category.PageCount));
    }
}