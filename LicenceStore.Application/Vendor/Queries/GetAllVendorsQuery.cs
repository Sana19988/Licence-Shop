using AutoMapper;
using LicenceStore.Application.Common.Dto.Vendor;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Vendor.Queries;

public record GetAllVendorsQuery() : IRequest<VendorListDto>;

public class GetAllVendorsQueryHandler : IRequestHandler<GetAllVendorsQuery, VendorListDto>
{
    private readonly IMapper _mapper;
    
    public GetAllVendorsQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<VendorListDto> Handle(GetAllVendorsQuery request, CancellationToken cancellationToken)
    {
        return _mapper.Map<VendorListDto>(await DB.Find<Domain.Entities.Vendor>()
            .ExecuteAsync(cancellation: cancellationToken));
    }
}