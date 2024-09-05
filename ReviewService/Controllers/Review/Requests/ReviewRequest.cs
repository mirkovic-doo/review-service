using ReviewService.Domain;

namespace ReviewService.Controllers.Review.Requests;

public record ReviewRequest
{
    public Guid ReservationId { get; set; }
    public Guid RevieweeId { get; set; }
    public Guid HostId { get; set; }
    public ReviewType Type { get; set; }
    public string Comment { get; set; } = string.Empty;
    public double Rating { get; set; }
}
