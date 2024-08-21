using FluentValidation;
using ReviewService.Controllers.Review.Requests;

namespace ReviewService.Contracts.Validators;

public class ReviewValidator : AbstractValidator<ReviewRequest>
{
    public ReviewValidator()
    {
        RuleFor(x => x.Rating)
            .NotEmpty()
            .GreaterThanOrEqualTo(1)
            .LessThanOrEqualTo(5);

        RuleFor(x => x.RevieweeId)
            .NotEmpty();

        RuleFor(x => x.ReservationId)
            .NotEmpty();

        RuleFor(x => x.Type)
            .NotEmpty();
    }
}
