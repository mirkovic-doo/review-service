namespace ReviewService.Controllers.Review.Requests;

public record ReviewRequest
{
    public Guid ReservationId { get; set; }
    public Guid PropertyId { get; set; }
    public string Comment { get; set; }
    public double Rating { get; set; }
}
