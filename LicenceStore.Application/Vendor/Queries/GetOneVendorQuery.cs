using AutoMapper;
using LicenceStore.Application.Common.Dto.Vendor;
using LicenceStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Vendor.Queries;

public record GetOneVendorQuery(string VendorId) : IRequest<VendorDetailsDto>;

public class GetOneVendorQueryHandler : IRequestHandler<GetOneVendorQuery, VendorDetailsDto>
{
    private readonly IMapper _mapper;
    
    public GetOneVendorQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<VendorDetailsDto> Handle(GetOneVendorQuery request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Domain.Entities.Vendor>()
            .OneAsync(request.VendorId, cancellation: cancellationToken);

        if (vendor == null)
            throw new NotFoundException("Vendor not found");
        
        return _mapper.Map<VendorDetailsDto>(vendor); 
    }
}