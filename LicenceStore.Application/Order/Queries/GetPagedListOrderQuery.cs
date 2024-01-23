using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.Order;
using LicenceStore.Application.Common.Extensions.Order;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Order.Queries;

public record GetPagedListOrderQuery(int PageNumber, int PageSize, string? SearchQuery) : IRequest<OrderPagedListDto>;

public class GetPagedListOrderQueryHandler : IRequestHandler<GetPagedListOrderQuery, OrderPagedListDto>
{
    private readonly IMapper _mapper;

    public GetPagedListOrderQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<OrderPagedListDto> Handle(GetPagedListOrderQuery request, CancellationToken cancellationToken)
    {
        var order = await DB.PagedSearch<Domain.Entities.Order>()
            .Sort(o => o.OrderCode, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);

        return _mapper.Map<OrderPagedListDto>(order.Results)
            .AddPagination(new PaginationDto(order.TotalCount, order.PageCount));
    }
}