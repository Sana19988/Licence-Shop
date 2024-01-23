namespace LicenceStore.Application.Common.Dto.Order;

public record OrderDetailsDto(long OrderCode, string? Customer, double TotalPrice, string Status,
    OrderInformationDto OrderInfo)
{
    internal OrderDetailsDto AddOrderInfo(OrderInformationDto orderInformationDto)
    {
        return this with { OrderInfo = orderInformationDto };
    }
}