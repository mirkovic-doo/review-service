using ReviewService.Domain;

namespace ReviewService.Controllers.Review.Responses;

public record ReviewResponse
{
    public Guid Id { get; set; }
    public Guid ReservationId { get; set; }
    public Guid RevieweeId { get; set; }
    public ReviewType Type { get; set; }
    public string Comment { get; set; }
    public double Rating { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public Guid CreatedById { get; set; }
    public Guid UpdatedById { get; set; }
}
