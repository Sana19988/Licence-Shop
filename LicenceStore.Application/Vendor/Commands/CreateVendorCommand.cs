using AutoMapper;
using LicenceStore.Application.Common.Dto.Vendor;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Vendor.Commands;

public record CreateVendorCommand(CreateVendorDto Vendor) : IRequest<string>;

public class CreateVendorCommandHandler : IRequestHandler<CreateVendorCommand, string>
{
    private readonly IMapper _mapper;

    public CreateVendorCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateVendorCommand request, CancellationToken cancellationToken)
    {
        var vendor = _mapper.Map<Domain.Entities.Vendor>(request.Vendor);
        await vendor.SaveAsync(cancellation: cancellationToken);

        return "Vendor successfully created!";
    }
}