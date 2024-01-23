namespace LicenceStore.Application.Common.Dto.Order;

public record OrderInformationDto(IEnumerable<string> Licence, IEnumerable<string?> Salesman);