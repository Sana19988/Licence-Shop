using AutoMapper;
using LicenceStore.Application.Common.Dto.Vendor;
using LicenceStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Vendor.Commands;

public record UpdateVendorCommand(UpdateVendorDto Vendor) : IRequest<string>;

public class UpdateVendorCommandHandler : IRequestHandler<UpdateVendorCommand, string>
{
    private readonly IMapper _mapper;

    public UpdateVendorCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<string> Handle(UpdateVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Domain.Entities.Vendor>()
            .OneAsync(request.Vendor.VendorId, cancellation: cancellationToken);

        if (vendor == null)
            throw new NotFoundException("Vendor not found");

        _mapper.Map(request.Vendor, vendor);
        await vendor.SaveAsync(cancellation: cancellationToken);

        return "Vendor successfully updated!";
    }
}