using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.Licence;
using LicenceStore.Application.Common.Extensions.Licence;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Licence.Queries;

public record GetPagedListLicenceQuery(int PageNumber, int PageSize, string? SearchQuery) : IRequest<LicencePagedListDto>;

public class GetPagedListLicenceQueryHandler : IRequestHandler<GetPagedListLicenceQuery, LicencePagedListDto>
{
    private readonly IMapper _mapper;

    public GetPagedListLicenceQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<LicencePagedListDto> Handle(GetPagedListLicenceQuery request, CancellationToken cancellationToken)
    {
        var licence = await DB.PagedSearch<Domain.Entities.Licence>()
            .Sort(c => c.Name, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);

        return _mapper.Map<LicencePagedListDto>(licence.Results)
            .AddPagination(new PaginationDto(licence.TotalCount, licence.PageCount));
    }
};