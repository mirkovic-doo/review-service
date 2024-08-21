namespace ReviewService.Contracts.Data;

public record UpdateReviewInput
{
    public Guid Id { get; set; }
    public string Comment { get; set; }
    public double Rating { get; set; }
}
