using FluentValidation;
using ReviewService.Controllers.Review.Requests;

namespace ReviewService.Contracts.Validators;

public class UpdateReviewValidator : AbstractValidator<UpdateReviewRequest>
{
    public UpdateReviewValidator()
    {
        RuleFor(x => x.Rating)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(5);
    }
}
