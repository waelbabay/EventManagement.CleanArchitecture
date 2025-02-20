using MediatR;
using Microsoft.AspNetCore.Mvc;
using EventManagement.CleanArchitecture.Application.Features.Categories.Queries.GetCategoriesList;
using EventManagement.CleanArchitecture.Application.Features.Categories.Queries.GetCategoriesListWithEvents;

namespace EventManagement.CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Name = "GetAllCategories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategories()
        {
            var allCategories = await _mediator.Send(new GetCategoriesListQuery());

            return Ok(allCategories);
        }

        [HttpGet("withevents", Name = "GetAllCategoriesWithEvents")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<CategoryListVm>>> GetAllCategoriesWithEvents(bool includeHistory)
        {
            GetCategoriesListWithEventsQuery getCategoriesListWithEventsQuery = new GetCategoriesListWithEventsQuery
            {
                IncludeHistory = includeHistory
            };

            var allCategoriesWithEvents = await _mediator.Send(getCategoriesListWithEventsQuery);

            return Ok(allCategoriesWithEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok("Get Category By Id");
        }
    }
}
