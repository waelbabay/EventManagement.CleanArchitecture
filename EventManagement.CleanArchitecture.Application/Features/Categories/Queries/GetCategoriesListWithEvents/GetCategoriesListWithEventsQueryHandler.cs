using AutoMapper;
using MediatR;
using EventManagement.CleanArchitecture.Application.Contracts.Persistence;

namespace EventManagement.CleanArchitecture.Application.Features.Categories.Queries.GetCategoriesListWithEvents
{
    public class GetCategoriesListWithEventsQueryHandler : IRequestHandler<GetCategoriesListWithEventsQuery, List<CategoryEventListVm>>
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoriesListWithEventsQueryHandler(IMapper mapper, ICategoryRepository categoryRepository)
        {
            _mapper = mapper;
            _categoryRepository = categoryRepository;
        }

        public async Task<List<CategoryEventListVm>> Handle(GetCategoriesListWithEventsQuery request, CancellationToken cancellationToken)
        {
            var categories = await _categoryRepository.GetCategoriesWithEvents(request.IncludeHistory);

            return _mapper.Map<List<CategoryEventListVm>>(categories);
        }
    }
}
