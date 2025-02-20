using AutoMapper;
using EventManagement.CleanArchitecture.Application.Features.Categories.Commands.CreateCategory;
using EventManagement.CleanArchitecture.Application.Features.Categories.Queries.GetCategoriesList;
using EventManagement.CleanArchitecture.Application.Features.Categories.Queries.GetCategoriesListWithEvents;
using EventManagement.CleanArchitecture.Application.Features.Events.Commands.CreateEvent;
using EventManagement.CleanArchitecture.Application.Features.Events.Commands.UpdateEvent;
using EventManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventDetail;
using EventManagement.CleanArchitecture.Application.Features.Events.Queries.GetEventsList;
using EventManagement.CleanArchitecture.Application.Features.Reviews.Commands.CreateReview;
using EventManagement.CleanArchitecture.Application.Features.Reviews.Queries.GetEventReviewsList;
using EventManagement.CleanArchitecture.Domain.Entities;

namespace EventManagement.CleanArchitecture.Application.Profiles
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Event, EventListVm>().ReverseMap();
            CreateMap<Event, EventDetailVm>().ReverseMap();
            CreateMap<Event, CategoryEventDto>();
            CreateMap<CreateEventCommand, Event>();
            CreateMap<UpdateEventCommand, Event>();


            CreateMap<Category, Features.Events.Queries.GetEventDetail.CategoryDto>().ReverseMap();
            CreateMap<Category, CategoryListVm>().ReverseMap();
            CreateMap<Category, CategoryEventListVm>().ReverseMap();
            CreateMap<Category, Features.Categories.Commands.CreateCategory.CategoryDto>().ReverseMap();
            CreateMap<CreateCategoryCommand, Category>();

            CreateMap<CreateReviewCommand, Review>();
            CreateMap<Review, EventReviewsListVm>();
        }
    }
}
