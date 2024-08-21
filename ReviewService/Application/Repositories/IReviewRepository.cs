using ReviewService.Domain;

namespace ReviewService.Application.Repositories;

public interface IReviewRepository : IBaseRepository<Review>
{
    Task<ICollection<Review>> GetMyReviewsAsync();
    Task<ICollection<Review>> GetRevieweeReviewsAsync(Guid revieweeId);
}
