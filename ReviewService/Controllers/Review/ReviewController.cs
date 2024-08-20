using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewService.Application.Services;
using ReviewService.Authorization;
using ReviewService.Controllers.Review.Requests;
using ReviewService.Controllers.Review.Responses;
using ReviewEntity = ReviewService.Domain.Review;

namespace ReviewService.Controllers.Review;

[Authorize]
[ApiController]
[Route("api/[controller]")]
[ProducesResponseType(typeof(string), StatusCodes.Status401Unauthorized)]
public class ReviewController : ControllerBase
{
    private readonly IMapper mapper;
    private readonly IReviewService reviewService;

    public ReviewController(
        IMapper mapper,
        IReviewService reviewService)
    {
        this.mapper = mapper;
        this.reviewService = reviewService;
    }

    [Authorize(nameof(AuthorizationLevel.Guest))]
    [HttpPost(Name = nameof(CreateReview))]
    [ProducesResponseType(typeof(ReviewResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateReview([FromBody] ReviewRequest request)
    {
        var review = await reviewService.CreateAsync(mapper.Map<ReviewEntity>(request));

        return CreatedAtAction(nameof(CreateReview), mapper.Map<ReviewResponse>(review));
    }
}
