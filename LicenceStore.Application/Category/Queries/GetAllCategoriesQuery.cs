using AutoMapper;
using LicenceStore.Application.Common.Dto.Category;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Category.Queries;

public record GetAllCategoriesQuery : IRequest<List<CategoryDetailsDto>>;

public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, List<CategoryDetailsDto>>
{
    private readonly IMapper _mapper;

    public GetAllCategoriesQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }
    
    public async Task<List<CategoryDetailsDto>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
    {
        var categories = await DB.Find<LicenceStore.Domain.Entities.Category>()
            .ManyAsync(cat => cat.Active == true, cancellationToken);
        
        return await _mapper.Map<Task<List<CategoryDetailsDto>>>(categories);
    }
}