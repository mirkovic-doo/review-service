using FluentValidation;
using ReviewService.Controllers.Review.Requests;

namespace ReviewService.Contracts.Validators;

public class ReviewValidator : AbstractValidator<ReviewRequest>
{
    public ReviewValidator()
    {
        RuleFor(x => x.Rating)
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(5);
    }
}
