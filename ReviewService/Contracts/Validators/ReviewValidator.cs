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

        RuleFor(x => x.HostId)
            .NotEmpty();

        RuleFor(x => x.Type)
            .NotEmpty();

        RuleFor(x => x)
            .Must(x => (x.Type == Domain.ReviewType.Host && x.RevieweeId == x.HostId) || x.Type == Domain.ReviewType.Property)
            .WithMessage("Reviewee id and host id must be same in case of reviewing the host");
    }
}
