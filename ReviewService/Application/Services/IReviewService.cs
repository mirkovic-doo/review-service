using ReviewService.Contracts.Data;
using ReviewService.Domain;

namespace ReviewService.Application.Services;

public interface IReviewService
{
    Task<Review> GetByIdAsync(Guid id);
    Task<ICollection<Review>> GetMyReviewsAsync();
    Task<ICollection<Review>> GetRevieweeReviewsAsync(Guid revieweeId);
    Task<Review> CreateAsync(Review review, Guid hostId);
    Task<Review> UpdateAsync(UpdateReviewInput updateReviewInput);
    Task DeleteAsync(Guid id);
}
