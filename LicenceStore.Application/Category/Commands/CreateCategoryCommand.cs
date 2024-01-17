using AutoMapper;
using LicenceStore.Application.Common.Dto.Category;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Category.Commands;

public record CreateCategoryCommand(CreateCategoryDto Category) : IRequest<string>;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, string>
{
    private readonly IMapper _mapper;

    public CreateCategoryCommandHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<string> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = _mapper.Map<Domain.Entities.Category>(request.Category);
        await category.SaveAsync(cancellation: cancellationToken);

        return "Category successfully created!";
    }
}