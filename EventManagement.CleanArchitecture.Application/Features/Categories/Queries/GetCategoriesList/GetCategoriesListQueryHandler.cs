using AutoMapper;
using MediatR;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;

namespace EventManagement.CleanArchitecture.Application.Features.Categories.Queries.GetCategoriesList
{
    internal class GetCategoriesListQueryHandler : IRequestHandler<GetCategoriesListQuery, List<CategoryListVm>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetCategoriesListQueryHandler(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<CategoryListVm>> Handle(GetCategoriesListQuery request, CancellationToken cancellationToken)
        {
            var categories = (await _categoryRepository.ListAllAsync()).OrderBy(c=>c.Name);

            return _mapper.Map<List<CategoryListVm>>(categories);
        }
    }
}
