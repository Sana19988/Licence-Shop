using LicenceStore.Application.Common.Dto.Licence;
using LicenceStore.Application.Common.Interfaces;
using LicenceStore.Domain.Entities;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Licence.Commands;

public record CreateLicenceCommand(CreateLicenceDto Licence) : IRequest<string>;

public record CreateLicenceCommandHandler : IRequestHandler<CreateLicenceCommand, string>
{
    private readonly IUserService _userService;

    public CreateLicenceCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<string> Handle(CreateLicenceCommand request, CancellationToken cancellationToken)
    {
        var vendor = await DB.Find<Vendor>()
            .OneAsync(request.Licence.VendorId, cancellationToken);

        if (vendor == null)
        {
            throw new Exception("Vendor not found");
        }

        var category = await DB.Find<Category>()
            .OneAsync(request.Licence.CategoryId, cancellationToken);

        if (category == null)
        {
            throw new Exception("Category not found");
        }
        
        var type = await DB.Find<LicenceType>()
            .OneAsync(request.Licence.TypeId, cancellationToken);

        if (type == null)
        {
            throw new Exception("Licence type not found");
        }

        var user = await _userService.GetUserAsync(request.Licence.OwnerId);

        var data = new Domain.Entities.Licence()
        {
            Name = request.Licence.Name,
            StartDate = request.Licence.StartDate,
            EndDate = request.Licence.EndDate,
            Vendor = new One<Vendor>(vendor),
            Category = new One<Category>(category),
            Type = new One<LicenceType>(type),
            IsSold = request.Licence.IsSold,
            Price = request.Licence.Price,
            Img = request.Licence.Img,
            Description = request.Licence.Description,
            Active = true
        };

        if (user != null)
        {
            data.Owner = user;
        }

        await data.SaveAsync(cancellation: cancellationToken);

        return "Licence successfully created!";

    }
}
