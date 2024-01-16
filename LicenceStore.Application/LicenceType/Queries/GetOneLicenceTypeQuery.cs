using AutoMapper;
using LicenceStore.Application.Common.Dto.LicenceType;
using LicenceStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.LicenceType.Queries;

public record GetOneLicenceTypeQuery(string LicenceTypeId) : IRequest<LicenceTypeDetailsDto>;

public class GetOneLicenceTypeQueryHandler : IRequestHandler<GetOneLicenceTypeQuery, LicenceTypeDetailsDto>
{
    private readonly IMapper _mapper;

    public GetOneLicenceTypeQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<LicenceTypeDetailsDto> Handle(GetOneLicenceTypeQuery request, CancellationToken cancellationToken)
    {
        var licenceType = await DB.Find<Domain.Entities.LicenceType>()
            .OneAsync(request.LicenceTypeId, cancellation: cancellationToken);

        if (licenceType == null)
        {
            throw new NotFoundException("LicenceType not found");
        }

        return _mapper.Map<LicenceTypeDetailsDto>(licenceType);
    }
}