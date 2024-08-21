using Microsoft.EntityFrameworkCore;
using ReviewService.Application.Repositories;
using ReviewService.Domain;

namespace ReviewService.Infrastructure.Repositories;

public class ReviewRepository : BaseRepository<Review>, IBaseRepository<Review>, IReviewRepository
{
    public ReviewRepository(ReviewDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<Review> GetAsync(Guid id)
    {
        var review = await base.GetAsync(id);

        if (review.CreatedById != dbContext.CurrentUserId)
        {
            throw new Exception($"Entity with {id} not found");
        }

        return review;
    }

    public async Task<ICollection<Review>> GetMyReviewsAsync()
    {
        return await dbContext.Reviews.Where(r => r.CreatedById == dbContext.CurrentUserId || r.UpdatedById == dbContext.CurrentUserId).ToListAsync();
    }

    public async Task<ICollection<Review>> GetRevieweeReviewsAsync(Guid revieweeId)
    {
        return await dbContext.Reviews.Where(r => r.RevieweeId == revieweeId).ToListAsync();
    }
}
