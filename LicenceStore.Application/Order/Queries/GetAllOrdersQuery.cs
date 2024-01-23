using AutoMapper;
using LicenceStore.Application.Common.Dto.Order;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Order.Queries;

public record GetAllOrdersQuery() : IRequest<List<OrderDetailsDto>>;

public class GetAllOrdersQueryHandler : IRequestHandler<GetAllOrdersQuery, List<OrderDetailsDto>>
{
    private readonly IMapper _mapper;

    public GetAllOrdersQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<List<OrderDetailsDto>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
        var orders = await DB.Find<LicenceStore.Domain.Entities.Order>()
            .ManyAsync(o => o.Active == true, cancellationToken);
        
        return await _mapper.Map<Task<List<OrderDetailsDto>>>(orders);
    }
};