namespace LicenceStore.Application.Common.Dto.Licence;

public record LicenceListDto(IReadOnlyList<LicenceDetailsDto> licences);