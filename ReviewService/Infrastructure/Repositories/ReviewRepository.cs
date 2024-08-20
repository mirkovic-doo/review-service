using ReviewService.Application.Repositories;
using ReviewService.Domain;
using ReviewService.Infrastructure;

namespace ReviewService.Infrastructure.Repositories;

public class ReviewRepository : BaseRepository<Review>, IBaseRepository<Review>, IReviewRepository
{
    private readonly ReviewDbContext dbContext;

    public ReviewRepository(ReviewDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }
}
