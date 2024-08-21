namespace ReviewService.Controllers.Review.Requests;

public record UpdateReviewRequest
{
    public Guid Id { get; set; }
    public string Comment { get; set; } = string.Empty;
    public double Rating { get; set; }
}
