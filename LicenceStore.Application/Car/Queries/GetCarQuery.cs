using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Car.Queries;

public record GetCarQuery(string CarName) : IRequest<string>;

public class GetCarQueryHandler : IRequestHandler<GetCarQuery, string>
{
    public async Task<string> Handle(GetCarQuery request, CancellationToken cancellationToken)
    {
        return request.CarName;
    }
}