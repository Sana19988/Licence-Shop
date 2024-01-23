using AutoMapper;
using LicenceStore.Application.Common.Dto.Category;
using LicenceStore.Application.Common.Exceptions;
using MediatR;
using MongoDB.Bson;
using MongoDB.Entities;

namespace LicenceStore.Application.Category.Queries;

public record GetOneCategoryQuery(string CategoryId) : IRequest<CategoryDetailsDto>;

public class GetOneCategoryQueryHandler : IRequestHandler<GetOneCategoryQuery, CategoryDetailsDto>
{
    private readonly IMapper _mapper;

    public GetOneCategoryQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<CategoryDetailsDto> Handle(GetOneCategoryQuery request, CancellationToken cancellationToken)
    {
        var category = await DB.Find<Domain.Entities.Category>()
            .OneAsync(request.CategoryId, cancellation: cancellationToken);
        
        if (category == null)
            throw new NotFoundException("Category not found");
        
        return _mapper.Map<CategoryDetailsDto>(category);
    }
};