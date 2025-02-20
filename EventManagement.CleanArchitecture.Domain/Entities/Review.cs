using EventManagement.CleanArchitecture.Domain.Common;
using EventManagement.CleanArchitecture.Domain.Enums;

namespace EventManagement.CleanArchitecture.Domain.Entities
{
    public class Review : AuditableEntity
    {
        public Guid ReviewId { get; set; }
        public string Author { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string Comment { get; set; } = string.Empty;
        public string Language { get; set; } = string.Empty;
        public ReviewSentiment Sentiment { get; set; }
        public Guid EventId { get; set; }
        public Event Event { get; set; } = default!;
    }
}
