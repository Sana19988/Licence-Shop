using AutoMapper;
using LicenceStore.Application.Common.Dto;
using LicenceStore.Application.Common.Dto.User;
using LicenceStore.Application.Common.Extensions.User;
using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Users.Queries;

public record GetUserPagedListQuery(int PageSize, int PageNumber, string? SearchQuery) : IRequest<UserPagedListDto>;

public class GetUserPagedQueryHandler : IRequestHandler<GetUserPagedListQuery, UserPagedListDto>
{
    private readonly IMapper _mapper;

    public GetUserPagedQueryHandler(IMapper mapper)
    {
        _mapper = mapper;
    }

    public async Task<UserPagedListDto> Handle(GetUserPagedListQuery request, CancellationToken cancellationToken)
    {
        var res = await DB.PagedSearch<LicenceStore.Domain.Entities.ApplicationUser>()
            .Sort(b => b.Name, Order.Ascending)
            .ApplyFilters(request)
            .PageSize(request.PageSize)
            .PageNumber(request.PageNumber)
            .ExecuteAsync(cancellationToken);

        return _mapper.Map<UserPagedListDto>(res.Results)
            .AddPagination(new PaginationDto(res.TotalCount, res.PageCount));
    }


}    ;