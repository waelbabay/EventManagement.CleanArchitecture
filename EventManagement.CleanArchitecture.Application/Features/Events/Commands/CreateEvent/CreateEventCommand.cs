using MediatR;

namespace EventManagement.CleanArchitecture.Application.Features.Events.Commands.CreateEvent
{
    public class CreateEventCommand : IRequest<Guid>
    {
        public string Name { get; set; } = string.Empty;
        public int Price { get; set; }
        public string Speaker { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Description { get; set; } = string.Empty;
        public Guid CategoryId { get; set; }
        public override string ToString()
        {
            return $"Event name: {Name}; Price: {Price}; By: {Speaker}; On: {Date.ToShortDateString()}; Description: {Description}";
        }
    }
}
