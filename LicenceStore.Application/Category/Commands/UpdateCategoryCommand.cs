using Ardalis.GuardClauses;
using AutoMapper;
using LicenceStore.Application.Common.Dto.Category;
using MediatR;
using MongoDB.Entities;
using NotFoundException = LicenceStore.Application.Common.Exceptions.NotFoundException;

namespace LicenceStore.Application.Category.Commands;

public record UpdateCategoryCommand(UpdateCategoryDto Category) : IRequest<string>;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, string>
{
    private readonly IMapper _mapper;

    public UpdateCategoryCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<string> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await DB.Find<Domain.Entities.Category>()
            .OneAsync(request.Category.CategoryId, cancellation: cancellationToken);

        if (category == null)
        {
            throw new NotFoundException("Category not found");
        }

        _mapper.Map(request.Category, category);

        return "Category successfully updated!";
    }
}