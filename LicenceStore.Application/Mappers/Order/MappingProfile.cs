using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.Order;

namespace LicenceStore.Application.Mappers.Order;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CreateOrderDto, LicenceStore.Domain.Entities.Order>().ReverseMap();
        CreateMap<UpdateOrderDto, LicenceStore.Domain.Entities.Order>().ReverseMap();
        CreateMap<Domain.Entities.Order, OrderDetailsDto>().ConstructUsing(o => GetOrderDetails(o));
        CreateMap<IEnumerable<Domain.Entities.Order>, OrderPagedListDto>().ConstructUsing(o => GetOrderPagedList(o));
    }

    private static OrderDetailsDto GetOrderDetails(Domain.Entities.Order order)
    {
        return new OrderDetailsDto(order.OrderCode, order.Customer.UserName, order.TotalPrice, order.Status,
            new OrderInformationDto(order.Licences.Select(o => o.Name),
                order.Licences.Select(o => o.Owner.UserName))
        );
    }

    private static OrderPagedListDto GetOrderPagedList(IEnumerable<Domain.Entities.Order> orders)
    {
        var orderList = orders.Select(GetOrderDetails).ToList();

        return new OrderPagedListDto(orderList, new PaginationDto(0, 0));
    }
}