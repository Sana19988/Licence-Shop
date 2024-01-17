using MediatR;
using MongoDB.Entities;

namespace LicenceStore.Application.Category.Commands;

public record DeleteCategoryCommand(string CategoryId) : IRequest<string>;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, string>
{
    public async Task<string> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        await DB.DeleteAsync<Domain.Entities.Category>(
            cat => cat.ID != null && cat.ID.Equals(request.CategoryId), cancellation: cancellationToken);

        return "Category successfully deleted!";
    }
};