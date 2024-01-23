namespace LicenceStore.Application.Common.Dto.Order;

public record UpdateOrderDto(string OrderId, IEnumerable<string?> Customer, IEnumerable<string?> Licences, double? TotalPrice, string? Status);