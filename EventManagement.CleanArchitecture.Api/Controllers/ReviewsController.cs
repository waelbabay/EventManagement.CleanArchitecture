using EventManagement.CleanArchitecture.Application.Features.Reviews.Commands.CreateReview;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EventManagement.CleanArchitecture.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Name = "CreateReview")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Guid>> CreateReview(CreateReviewCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
