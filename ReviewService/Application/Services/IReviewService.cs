using ReviewService.Domain;

namespace ReviewService.Application.Services;

public interface IReviewService
{
    Task<Review> CreateAsync(Review review);
}
