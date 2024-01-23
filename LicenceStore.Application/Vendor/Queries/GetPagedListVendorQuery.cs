using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.Vendor;
using LicenceStore.Application.Common.Extensions.Vendor;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Vendor.Queries;

public record GetPagedListVendorQuery(int PageNumber, int PageSize, string? SearchQuery) : IRequest<VendorPagedListDto>;

public class GetPagedListVendorQueryHandler : IRequestHandler<GetPagedListVendorQuery, VendorPagedListDto>
{
    private readonly IMapper _mapper;

    public GetPagedListVendorQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<VendorPagedListDto> Handle(GetPagedListVendorQuery request, CancellationToken cancellationToken)
    {
        var vendor = await DB.PagedSearch<Domain.Entities.Vendor>()
            .Sort(v => v.Name, MongoDB.Entities.Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);

        return _mapper.Map<VendorPagedListDto>(vendor.Results)
            .AddPagination(new PaginationDto(vendor.TotalCount, vendor.PageCount));
    }
}