using ReviewService.Application.Repositories;
using ReviewService.Application.Services;
using ReviewService.Domain;

namespace ReviewService.Infrastructure.Services;

public class ReviewService : IReviewService
{
    private readonly IReviewRepository reviewRepository;

    public ReviewService(IReviewRepository reviewRepository)
    {
        this.reviewRepository = reviewRepository;
    }

    public async Task<Review> CreateAsync(Review review)
    {
        return await reviewRepository.AddAsync(review);
    }
}
