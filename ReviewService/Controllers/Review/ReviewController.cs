using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReviewService.Application.Services;
using ReviewService.Authorization;
using ReviewService.Contracts.Data;
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

    [HttpGet("{id}", Name = nameof(GetById))]
    [ProducesResponseType(typeof(ReviewResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        var review = await reviewService.GetByIdAsync(id);

        return Ok(mapper.Map<ReviewResponse>(review));
    }

    [HttpGet("reviewee/{revieweeId}", Name = nameof(GetRevieweeReviews))]
    [ProducesResponseType(typeof(List<ReviewResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetRevieweeReviews([FromRoute] Guid revieweeId)
    {
        var reviews = await reviewService.GetRevieweeReviewsAsync(revieweeId);

        return Ok(mapper.Map<List<ReviewResponse>>(reviews));
    }

    [Authorize(nameof(AuthorizationLevel.Guest))]
    [HttpGet("my", Name = nameof(GetMyReviews))]
    [ProducesResponseType(typeof(List<ReviewResponse>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetMyReviews()
    {
        var reviews = await reviewService.GetMyReviewsAsync();

        return Ok(mapper.Map<List<ReviewResponse>>(reviews));
    }

    [Authorize(nameof(AuthorizationLevel.Guest))]
    [HttpPost(Name = nameof(CreateReview))]
    [ProducesResponseType(typeof(ReviewResponse), StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateReview([FromBody] ReviewRequest request)
    {
        var review = await reviewService.CreateAsync(mapper.Map<ReviewEntity>(request));

        return CreatedAtAction(nameof(CreateReview), mapper.Map<ReviewResponse>(review));
    }

    [Authorize(nameof(AuthorizationLevel.Guest))]
    [HttpPut(Name = nameof(UpdateReview))]
    [ProducesResponseType(typeof(ReviewResponse), StatusCodes.Status200OK)]
    public async Task<IActionResult> UpdateReview([FromBody] UpdateReviewRequest request)
    {
        var review = await reviewService.UpdateAsync(mapper.Map<UpdateReviewInput>(request));
        return Ok(review);
    }

    [HttpDelete("{id}", Name = nameof(DeleteReview))]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<IActionResult> DeleteReview([FromRoute] Guid id)
    {
        await reviewService.DeleteAsync(id);

        return Ok();
    }
}
