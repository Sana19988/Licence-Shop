using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.LicenceType;
using LicenceStore.Application.Common.Extensions.LicenceType;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.LicenceType.Queries;

public record GetPagedListLicenceTypeQuery(int PageNumber, int PageSize, string? SearchQuery) : IRequest<LicenceTypePagedListDto>;

public class GetPagedListLicenceTypeQueryHandler : IRequestHandler<GetPagedListLicenceTypeQuery, LicenceTypePagedListDto>
{
    private readonly IMapper _mapper;

    public GetPagedListLicenceTypeQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<LicenceTypePagedListDto> Handle(GetPagedListLicenceTypeQuery request, CancellationToken cancellationToken)
    {
        var licenceT = await DB.PagedSearch<Domain.Entities.LicenceType>()
            .Sort(c => c.Name, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);

        return _mapper.Map<LicenceTypePagedListDto>(licenceT.Results)
            .AddPagination(new PaginationDto(licenceT.TotalCount, licenceT.PageCount));
    }
};