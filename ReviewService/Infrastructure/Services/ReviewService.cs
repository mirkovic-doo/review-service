using AutoMapper;
using ReviewService.Application.Repositories;
using ReviewService.Application.Services;
using ReviewService.Contracts.Data;
using ReviewService.Domain;

namespace ReviewService.Infrastructure.Services;

public class ReviewService : IReviewService
{
    private readonly IMapper mapper;
    private readonly IReviewRepository reviewRepository;

    public ReviewService(IMapper mapper, IReviewRepository reviewRepository)
    {
        this.mapper = mapper;
        this.reviewRepository = reviewRepository;
    }

    public async Task<Review> CreateAsync(Review review)
    {
        return await reviewRepository.AddAsync(review);
    }

    public async Task DeleteAsync(Guid id)
    {
        var review = await reviewRepository.GetAsync(id);

        reviewRepository.Delete(review);
    }

    public async Task<Review> GetByIdAsync(Guid id)
    {
        return await reviewRepository.GetAsync(id);
    }

    public async Task<ICollection<Review>> GetMyReviewsAsync()
    {
        return await reviewRepository.GetMyReviewsAsync();
    }

    public async Task<ICollection<Review>> GetRevieweeReviewsAsync(Guid revieweeId)
    {
        return await reviewRepository.GetRevieweeReviewsAsync(revieweeId);
    }

    public async Task<Review> UpdateAsync(UpdateReviewInput updateReviewInput)
    {
        var review = await reviewRepository.GetAsync(updateReviewInput.Id);

        mapper.Map(updateReviewInput, review);

        return reviewRepository.Update(review);
    }
}
