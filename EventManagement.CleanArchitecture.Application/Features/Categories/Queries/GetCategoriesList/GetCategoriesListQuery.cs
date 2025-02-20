using MediatR;

namespace EventManagement.CleanArchitecture.Application.Features.Categories.Queries.GetCategoriesList
{
    public class GetCategoriesListQuery : IRequest<List<CategoryListVm>>
    {
    }
}
